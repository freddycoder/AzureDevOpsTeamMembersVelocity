using System;
using System.Collections.Generic;

namespace AzureDevOpsTeamMembersVelocity.Repository
{
    public class UserPreferenceRepository : IUserPreferenceRepository
    {
        public Dictionary<Type, object> SavedSettings { get; }

        public UserPreferenceRepository()
        {
            SavedSettings = new Dictionary<Type, object>();
        }

        public T Get<T>()
        {
            if (SavedSettings.TryGetValue(typeof(T), out object settings))
            {
                return (T) settings;
            }

            return Activator.CreateInstance<T>();
        }

        public void Set<T>(T settings)
        {
            if (SavedSettings.ContainsKey(typeof(T)) == false)
            {
                SavedSettings.Add(typeof(T), settings);
            }
            else
            {
                SavedSettings[typeof(T)] = settings;
            }
        }
    }
}
