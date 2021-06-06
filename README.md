# AzureDevOpsTeamMembersVelocity

A app that fetch task history and tell informations about velocity of each member base on a sprint

## Dependency

```
.net5.0
```

## Run the app

To run the app you need to have docker install on your computer. Otherwise, you'll need to build it yourself using the dotnet cli or visual studio.

```
docker run -p 45000:80 erabliereapi/azuredevopsteammembersvelocity:initial
```

Then go to : http://localhost:45000

## Build the app

### Using dotnet cli

Using the command line

```
git clone https://github.com/freddycoder/AzureDevOpsTeamMembersVelocity.git
cd AzureDevOpsTeamMembersVelocity
dotnet restore
dotnet run
```

Then go to : http://localhost:5000 or https://localhost:5001

### Using docker

```
git clone https://github.com/freddycoder/AzureDevOpsTeamMembersVelocity.git
docker build -t azuredevopsteammembersvelocity:initial .
docker run -p 45000:80 azuredevopsteammembersvelocity:initial
```

Then go to : http://localhost:45000

## Push new image to docker hub

```
docker build -t <username>/azuredevopsteammembersvelocity:<tag> .
docker push <username>/azuredevopsteammembersvelocity:<tag> .
```

To try the app, you'll need to create an access token inside your azure devops account.

The app can list you each member and calculate the total of working hours for each members of a team based on a selected sprint.

### Additional information

The code documentation can be found inside the wiki at https://github.com/freddycoder/AzureDevOpsTeamMembersVelocity/wiki/Code-documentation

### Additionnal links

Generate html from from c# xml documentation

http://varus.io/vsdoc-2-md/
