FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AzureDevOpsTeamMembersVelocity/AzureDevOpsTeamMembersVelocity.csproj", "AzureDevOpsTeamMembersVelocity/"]
COPY ["UnitTest/UnitTest.csproj", "UnitTest/"]
RUN dotnet restore "AzureDevOpsTeamMembersVelocity/AzureDevOpsTeamMembersVelocity.csproj"
RUN dotnet restore "UnitTest/UnitTest.csproj"
COPY . .
WORKDIR /src/UnitTest
RUN dotnet test
WORKDIR "/src/AzureDevOpsTeamMembersVelocity"
RUN dotnet build "AzureDevOpsTeamMembersVelocity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AzureDevOpsTeamMembersVelocity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AzureDevOpsTeamMembersVelocity.dll"]