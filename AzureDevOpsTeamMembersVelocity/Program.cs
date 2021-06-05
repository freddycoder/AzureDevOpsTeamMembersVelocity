using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AzureDevOpsTeamMembersVelocity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var logger = host.Services.GetRequiredService<ILogger<Program>>();

            if (File.Exists("AzureDevOpsTeamMemberVelocity.json"))
            {
                logger.LogInformation("Load settings from file : AzureDevOpsTeamMemberVelocity.json");

                var settings = host.Services.GetRequiredService<TeamMembersVelocitySettings>();

                var savedSettings = JsonSerializer.Deserialize<TeamMembersVelocitySettings>(File.ReadAllText("AzureDevOpsTeamMemberVelocity.json"));

                settings.Organisation = savedSettings.Organisation;
                settings.TeamProject = savedSettings.TeamProject;
                settings.Team = savedSettings.Team;
                settings.Board = savedSettings.Board;
                settings.ApiKey = savedSettings.ApiKey;
            }
            else
            {
                logger.LogInformation("No settings found : AzureDevOpsTeamMemberVelocity.json");
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static readonly JsonSerializerOptions SerializerOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = true
        };
    }
}
