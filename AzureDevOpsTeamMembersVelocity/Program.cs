using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.DataProtection;
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
                try
                {
                    logger.LogInformation("Load settings from file : AzureDevOpsTeamMemberVelocity.json");

                    var settings = host.Services.GetRequiredService<TeamMembersVelocitySettings>();

                    var dataProtector = host.Services.GetRequiredService<IDataProtectionProvider>()
                                                     .CreateProtector(nameof(AzureDevOpsTeamMembersVelocity));

                    var jsonString = dataProtector.Unprotect(File.ReadAllText("AzureDevOpsTeamMemberVelocity.json"));

                    var savedSettings = JsonSerializer.Deserialize<TeamMembersVelocitySettings>(jsonString);

                    settings.Organisation = savedSettings?.Organisation;
                    settings.TeamProject = savedSettings?.TeamProject;
                    settings.Team = savedSettings?.Team;
                    settings.ApiKey = savedSettings?.ApiKey;
                }
                catch (Exception e)
                {
                    logger.LogCritical(e, "Error reading settings from disk");
                }
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

        public static readonly JsonSerializerOptions SerializerOptions = InitSettings();

        private static JsonSerializerOptions InitSettings()
        {
            var settings = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = true
            };

            settings.Converters.Add(new JsonStringEnumConverter());

            return settings;
        }
    }
}
