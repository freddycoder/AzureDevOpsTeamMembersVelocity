using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
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

            if (File.Exists("AzureDevOpsTeamMemberVelocity.json"))
            {
                Console.WriteLine("Load settings from file : AzureDevOpsTeamMemberVelocity.json");

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
                Console.WriteLine("No settings found : AzureDevOpsTeamMemberVelocity.json");
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
