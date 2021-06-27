using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AzureDevOpsTeamMembersVelocity.Extensions;
using AzureDevOpsTeamMembersVelocity.Repository;
using AzureDevOpsTeamMembersVelocity.Services;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AzureDevOpsTeamMembersVelocity
{
    /// <summary>
    /// The entry point of the program. It also contains settings to use for System.Text.Json serialization.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The entry point of the program
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            host.Run();
        }

        /// <summary>
        /// Create the host builder with some default settings
        /// </summary>
        /// <param name="args">Main method args</param>
        /// <returns>A new HostBuilder</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        /// <summary>
        /// System.Text.Json SerializerOptions to use in serialization in the app.
        /// </summary>
        public static readonly JsonSerializerOptions SerializerOptions = InitSettings();

        private static JsonSerializerOptions InitSettings()
        {
            var settings = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = true
            };

            settings.Converters.Add(new JsonSubjectDescriptorConverter());

            settings.Converters.Add(new JsonStringEnumConverter());

            return settings;
        }
    }
}
