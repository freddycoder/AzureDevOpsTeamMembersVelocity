# Generate certificat for https
# Source: https://github.com/freddycoder/ErabliereApi/blob/master/deploiement-local.ps1
# Source: https://github.com/mjarosie/IdentityServerDockerHttpsDemo/blob/master/generate_self_signed_cert.ps1
# Source: https://stackoverflow.com/a/62060315
# Generate self-signed certificate to be used by IdentityServer.
# When using localhost - API cannot see the IdentityServer from within the docker-compose'd network.
# You have to run this script as Administrator (open Powershell by right click -> Run as Administrator).

$ErrorActionPreference = "Stop"

Write-Output "******************************************************"
Write-Output "Make sure to run the script as administrator"
Write-Output "******************************************************"

$rootCN = "ErabliereAPIDockerSSLSetup"
$webApiCNs = "localhost"

$alreadyExistingCertsRoot = Get-ChildItem -Path Cert:\LocalMachine\My -Recurse | Where-Object {$_.Subject -eq "CN=$rootCN"}
$alreadyExistingCertsApi = Get-ChildItem -Path Cert:\LocalMachine\My -Recurse | Where-Object {$_.Subject -eq ("CN={0}" -f $webApiCNs[0])}

if ($alreadyExistingCertsRoot.Count -eq 1) {
    Write-Output "Skipping creating Root CA certificate as it already exists."
    $testRootCA = [Microsoft.CertificateServices.Commands.Certificate] $alreadyExistingCertsRoot[0]
} else {
    $testRootCA = New-SelfSignedCertificate -Subject $rootCN -KeyUsageProperty Sign -KeyUsage CertSign -CertStoreLocation Cert:\LocalMachine\My
}

if ($alreadyExistingCertsApi.Count -eq 1) {
    Write-Output "Skipping creating API certificate as it already exists."
    $webApiCert = [Microsoft.CertificateServices.Commands.Certificate] $alreadyExistingCertsApi[0]
} else {
    # Create a SAN cert for both web-api and localhost.
    $webApiCert = New-SelfSignedCertificate -DnsName $webApiCNs -Signer $testRootCA -CertStoreLocation Cert:\LocalMachine\My
}

# Export it for docker container to pick up later.
$password = ConvertTo-SecureString -String "password" -Force -AsPlainText

$rootCertPathPfx = $PWD.Path + "\" + "certs"
$webApiCertPath = $PWD.Path + "\" + "AzureDevOpsTeamMembersVelocity\certs"

[System.IO.Directory]::CreateDirectory($rootCertPathPfx) | Out-Null
[System.IO.Directory]::CreateDirectory($webApiCertPath) | Out-Null

Export-PfxCertificate -Cert $testRootCA -FilePath "$rootCertPathPfx\aspnetapp-root-cert.pfx" -Password $password | Out-Null
Export-PfxCertificate -Cert $webApiCert -FilePath "$webApiCertPath\aspnetapp-web-api.pfx" -Password $password | Out-Null

# Export .cer to be converted to .crt to be trusted within the Docker container.
$rootCertPathCer = "certs\aspnetapp-root-cert.cer"
Export-Certificate -Cert $testRootCA -FilePath $rootCertPathCer -Type CERT | Out-Null

# Trust it on your host machine.
$store = New-Object System.Security.Cryptography.X509Certificates.X509Store "Root","LocalMachine"
$store.Open("ReadWrite")

$rootCertAlreadyTrusted = ($store.Certificates | Where-Object {$_.Subject -eq "CN=$rootCN"} | Measure-Object).Count -eq 1

if ($rootCertAlreadyTrusted -eq $false) {
    $message = "Adding the root CA certificate to the trust store. (" + $rootCertPathPfx + "\aspnetapp-root-cert.pfx)"
    Write-Output $message
    $certBytes = [System.IO.File]::ReadAllBytes($rootCertPathPfx + "\aspnetapp-root-cert.pfx");
    $testRootCACert = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2($certBytes, $password)
    $store.Add($testRootCACert)
}

$store.Close()

Write-Output "SSL is now setup !"

Write-Output "Last step is to enter your Tenant Id and your Client Id."

Write-Output "Please enter your Tenant ID"

$tenantId = Read-Host

Write-Output "Please enter your Client ID"

$clientId = Read-Host

$envPath = $PWD.Path + "\" + ".env"

$newLine = [System.Environment]::NewLine;

$envContent = "TENANT_ID=" + $tenantId + $newLine
$envContent = $envContent + "CLIENT_ID=" + $clientId

Write-Output $envContent

$Utf8NoBomEncoding = New-Object System.Text.UTF8Encoding $False
[System.IO.File]::WriteAllText($envPath, $envContent, $Utf8NoBomEncoding);

Write-Output "You can now launch the app with : docker compose up -d"