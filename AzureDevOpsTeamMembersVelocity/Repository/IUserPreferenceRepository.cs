using AzureDevOpsTeamMembersVelocity.Settings;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Repository
{
    /// <summary>
    /// Interface used to abstract the store of users preferences
    /// </summary>
    public interface IUserPreferenceRepository
    {
        /// <summary>
        /// Get an implementation of AbstractSettings
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Task<T> GetAsync<T>() where T : AbstractSettings;

        /// <summary>
        /// Set an implementation of AbstractSettings
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Task SetAsync<T>(T settings) where T : AbstractSettings;
    }
}
