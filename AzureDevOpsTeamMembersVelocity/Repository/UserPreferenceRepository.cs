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

        /// <summary>
        /// Set the preference type into the repository. If null is passed, 
        /// the function immediatly return. nothing append. If the value 
        /// already in the repository, the object is replace
        /// </summary>
        /// <typeparam name="T">The type of the preference</typeparam>
        /// <param name="settings">The instance to save</param>
        public void Set<T>(T settings)
        {
            if (settings == null) return;

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
