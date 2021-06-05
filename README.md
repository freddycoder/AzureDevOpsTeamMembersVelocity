# AzureDevOpsTeamMembersVelocity
A app that fetch task history and tell the actual velocity of each member base on past sprint

## Beta stage
The app can list you each member and calculate the total of working hours for each members of a team based on a selected sprint.

To try the app, you'll need to create an access token inside your azure devops account.

To build and run the app, execute to folling commands in the AzureDevOpsTeamMembersVelocity folder

```
dotnet restore
dotnet run
```

## TODO

- Show more information about the sprint (summary, title, dates)
- Show estimated capacity for each member
- Show real capacity for each member