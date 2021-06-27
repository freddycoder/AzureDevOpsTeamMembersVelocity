using AzureDevOpsTeamMembersVelocity.Settings;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Repository
{
    /// <summary>
    /// Use file system to get and to store user preference
    /// </summary>
    public class UserPreferenceFromFileSystemRepository : IUserPreferenceRepository
    {
        private readonly ILogger<UserPreferenceFromFileSystemRepository> _logger;
        private readonly IDataProtector _dataProtection;
        private readonly Dictionary<Type, AbstractSettings> _memory;

        /// <summary>
        /// Constructor with dependencies
        /// </summary>
        /// <param name="dataProtectionProvider"></param>
        /// <param name="logger"></param>
        public UserPreferenceFromFileSystemRepository(IDataProtectionProvider dataProtectionProvider, ILogger<UserPreferenceFromFileSystemRepository> logger)
        {
            _logger = logger;
            _dataProtection = dataProtectionProvider.CreateProtector(nameof(AzureDevOpsTeamMembersVelocity));
            _memory = new ();
        }

        /// <summary>
        /// Get settings from disk
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task<T> GetAsync<T>() where T : AbstractSettings
        {
            if (_memory.TryGetValue(typeof(T), out var settings) && settings != null)
            {
                return (T)settings;
            }

            var fileName = GetFileName<T>();

            _logger.LogInformation($"Load settings from file : {fileName}");

            if (File.Exists(fileName))
            {
                try
                {
                    var jsonString = _dataProtection.Unprotect(await File.ReadAllTextAsync(fileName));

                    var settingsDeserialized = JsonSerializer.Deserialize<T>(jsonString, Program.SerializerOptions);

                    if (settingsDeserialized == null)
                    {
                        throw new InvalidDataException($"After the desiralization of '{fileName}', the instanse deserialized was null");
                    }

                    StoreInMemory(settingsDeserialized);

                    return settingsDeserialized;
                }
                catch (Exception e)
                {
                    _logger.LogCritical(e, "Error reading settings from disk");
                }
            }
            else
            {
                _logger.LogInformation($"No settings found : {fileName}");
            }

            return Activator.CreateInstance<T>();
        }

        /// <summary>
        /// Persist the settings on disk
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="settings"></param>
        /// <returns></returns>
        public async Task SetAsync<T>(T settings) where T : AbstractSettings
        {
            if (settings.AsChanged() == false)
            {
                return;
            }

            var fileName = GetFileName<T>();

            _logger.LogInformation($"Save settings to file : {fileName}");

            try
            {
                var settingsSerialized = JsonSerializer.Serialize(settings);

                var encryptedText = _dataProtection.Protect(settingsSerialized);

                await File.WriteAllTextAsync(fileName, encryptedText);
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, e.Message);
            }

            StoreInMemory(settings);
        }

        private void StoreInMemory<T>(T settings) where T : AbstractSettings
        {
            if (settings != null)
            {
                try
                {
                    if (_memory.ContainsKey(typeof(T)))
                    {
                        _memory[typeof(T)] = settings;
                    }
                    else
                    {
                        _memory.Add(typeof(T), settings);
                    }
                }
                catch (Exception e)
                {
                    _logger.LogCritical(e, e.Message);
                }
            }
        }

        private static string GetFileName<T>()
        {
            return typeof(T).Name switch
            {
                nameof(TeamMembersVelocitySettings) => "AzureDevOpsTeamMemberVelocity.json",
                _ => $"{typeof(T).Name}.json",
            };
        }
    }
}
