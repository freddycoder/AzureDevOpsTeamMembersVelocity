using AzureDevOpsTeamMembersVelocity;
using AzureDevOpsTeamMembersVelocity.Repository;
using AzureDevOpsTeamMembersVelocity.Settings;
using System.IO.Abstractions;
using System.Text.Json;
using System.Threading.Tasks;
using UnitTest.AutoData;
using Xunit;

namespace UnitTest
{
    public class AppSettingsTest
    {
        [Theory, AutoVelocityData]
        public async Task GetAsync_GetSettings_AsChangedInitialFalse(UserPreferenceFromFileSystemRepository userPreference)
        {
            var settings = await userPreference.GetAsync<GitPageSettings>();

            Assert.False(settings.AsChanged());
            Assert.True(settings.AsNotChanged());
        }

        [Theory, AutoVelocityData]
        public async Task GetAsync_GetSettingsAndDoChange_AsChangedTrue(UserPreferenceFromFileSystemRepository userPreference,
                                                                        IFixture fixture)
        {
            var settings = await userPreference.GetAsync<GitPageSettings>();

            settings.PullRequest = fixture.Create<int>();

            Assert.True(settings.AsChanged());
            Assert.False(settings.AsNotChanged());
        }

        [Theory, AutoVelocityData]
        public async Task GetAsync_GetSettingsTrickChange_AsChangedTrue(UserPreferenceFromFileSystemRepository userPreference,
                                                                        IFixture fixture)
        {
            var settings = await userPreference.GetAsync<GitPageSettings>();

            settings.PullRequest = fixture.Create<int>();
            settings.Repository = settings.Repository;

            Assert.True(settings.AsChanged());
            Assert.False(settings.AsNotChanged());
        }

        [Theory, AutoVelocityData]
        public async Task GetAsync_GetSettingsNoChangeButAssignation_AsChangedTrue(UserPreferenceFromFileSystemRepository userPreference)
        {
            var settings = await userPreference.GetAsync<GitPageSettings>();

            settings.PullRequest = settings.PullRequest;
            settings.Repository = settings.Repository;

            Assert.False(settings.AsChanged());
            Assert.True(settings.AsNotChanged());
        }

        [Theory, AutoVelocityData]
        public async Task GetAsync_GetSettingsSavedBefore_AsNotChanged(UserPreferenceFromFileSystemRepository userPreference, 
                                                                       IFile file,
                                                                       GitPageSettings gitPageSettings)
        {
            int callToReadAllTextAsync = 0;
            file.Exists($"{nameof(GitPageSettings)}.json").Returns(true);
            file.ReadAllTextAsync($"{nameof(GitPageSettings)}.json").Returns(callInfo =>
            {
                return Task.Run(() =>
                {
                    callToReadAllTextAsync++;

                    return JsonSerializer.Serialize(gitPageSettings, Program.SerializerOptions);
                });
            });

            var settings = await userPreference.GetAsync<GitPageSettings>();

            Assert.Equal(1, callToReadAllTextAsync);
            Assert.False(settings.AsChanged());
            Assert.True(settings.AsNotChanged());
        }
    }
}
