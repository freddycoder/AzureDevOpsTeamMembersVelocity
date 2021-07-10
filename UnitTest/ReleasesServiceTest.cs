using AzureDevOpsTeamMembersVelocity.Services;
using System.Threading.Tasks;
using UnitTest.AutoData;
using Xunit;

namespace UnitTest
{
    public class ReleasesServiceTest
    {
        [Theory, AutoVelocityData]
        public async Task ListReleases(ReleasesService sut)
        {
            const string organization = "fabrikam";
            const string teamProject = "MyFirstProject";

            var (releasesList, errorMessage) = await sut.ListReleases(organization, teamProject);

            Assert.Null(errorMessage);
            Assert.NotNull(releasesList);
            Assert.Equal(17, releasesList.Count);
            Assert.Equal(17, releasesList.Value.Count);
        }
    }
}
