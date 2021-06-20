# AzureDevOpsTeamMembersVelocity

A app that fetch task history and tell informations about velocity of each member base on a sprint.

To use the app, you'll need to create an access token inside your azure devops account.

The app can list you each member and calculate the total of working hours, capacity estimated, real capacity, and history for each members of a sprint.

## Run the app

To run the app you need to have docker install on your computer. Otherwise, you'll need to build it yourself using the dotnet cli or visual studio.

```
docker run -p 45000:80 erabliereapi/azuredevopsteammembersvelocity:initial
```

Then go to : http://localhost:45000

Demo : https://youtu.be/Ecl3QeIxSfM

## Run the app with authentication

### 1. Environment variable user

Only a username
```
docker run -e COOKIEAUTH_USER=admin@teamvelocity.com -p 45000:80 azuredevopsteammembersvelocity:auth
```

A username and a password
```
docker run -e COOKIEAUTH_USER=admin@teamvelocity.com -e COOKIEAUTH_PASSWORD=admin -p 45000:80 azuredevopsteammembersvelocity:auth
```

### 2. Microsoft Identity self hosted

Use the default asp.net scafolding Identity pages and logic
```
docker run -e USE_IDENTITY=true -e -p 45000:80 azuredevopsteammembersvelocity:auth
```

### 3. AzureAD

You must register the app inside AzureAD first.

For example you can register an app with 
- Single Tenant
- Redirect url : https://localhost:45000/signin-oidc

After registrer the app, go to the Authentication page off the newly created app.

Set front-chanel logout to : https://localhost:45001/signout-oidc

Select the tokens you would like to be issued by the authorization endpoint: ```ID tokens```

And save the settings. Now the AzureAD authentication will work with the container.

This one is a little bit more complicated since we must use https.

For this on we are going to use a script inside this repo, and also use the docker compose file from this repo.
```
./setup-docker-ssl.ps1

docker compose up -d
```

### Note on https

To use https with other authentication method that AzureAD, you can hack the docker-compose.yaml file to fit with the environment variable of the authentication method you want to use. Then you can launch the script ```setup-docker-ssl.ps1``` and run ```docker compose up -d```.

## Build the app

### Dependency

```
.net5.0
```

### Using dotnet cli

```
git clone https://github.com/freddycoder/AzureDevOpsTeamMembersVelocity.git
cd AzureDevOpsTeamMembersVelocity
cd AzureDevOpsTeamMembersVelocity
dotnet restore
dotnet run
```

Then go to : http://localhost:5000 or https://localhost:5001

### Using docker

```
git clone https://github.com/freddycoder/AzureDevOpsTeamMembersVelocity.git
cd AzureDevOpsTeamMembersVelocity
docker build -t azuredevopsteammembersvelocity:auth .
docker run -p 45000:80 azuredevopsteammembersvelocity:auth
```

Then go to : http://localhost:45000

## Push new image to docker hub

```
docker build -t <username>/azuredevopsteammembersvelocity:<tag> .
docker push <username>/azuredevopsteammembersvelocity:<tag>
```

### Additional information

The code documentation can be found inside the wiki at https://github.com/freddycoder/AzureDevOpsTeamMembersVelocity/wiki/Code-documentation

### Additionnal links

Generate html from from c# xml documentation

http://varus.io/vsdoc-2-md/
