using AzureDevOpsTeamMembersVelocity.Repository;
using AzureDevOpsTeamMembersVelocity.Settings;
using System;
using System.Threading.Tasks;

namespace UnitTest.AutoData
{
    internal class MockUserPreferenceRepository : IUserPreferenceRepository
    {
        public Task<T> GetAsync<T>() where T : AbstractSettings
        {
            return Task.FromResult(Activator.CreateInstance<T>());
        }

        public Task SetAsync<T>(T settings) where T : AbstractSettings
        {
            return Task.CompletedTask;
        }
    }
}