FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MockK8s/MockK8s.csproj", "MockK8s/"]
COPY ["AzureDevOpsTeamMembersVelocity/AzureDevOpsTeamMembersVelocity.csproj", "AzureDevOpsTeamMembersVelocity/"]
COPY ["UnitTest/UnitTest.csproj", "UnitTest/"]
COPY ["IntegrationTest/IntegrationTest.csproj", "IntegrationTest/"]
RUN dotnet restore "MockK8s/MockK8s.csproj"
RUN dotnet restore "AzureDevOpsTeamMembersVelocity/AzureDevOpsTeamMembersVelocity.csproj"
RUN dotnet restore "UnitTest/UnitTest.csproj"
RUN dotnet restore "IntegrationTest/IntegrationTest.csproj"
COPY . .
WORKDIR /src/UnitTest
RUN dotnet test
WORKDIR /src/IntegrationTest
RUN dotnet test
WORKDIR "/src/AzureDevOpsTeamMembersVelocity"
RUN dotnet build "AzureDevOpsTeamMembersVelocity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AzureDevOpsTeamMembersVelocity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AzureDevOpsTeamMembersVelocity.dll"]