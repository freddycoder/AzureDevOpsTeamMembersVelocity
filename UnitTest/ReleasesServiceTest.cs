using AzureDevOpsTeamMembersVelocity.Services;
using System.Threading.Tasks;
using UnitTest.AutoData;
using Xunit;
using static UnitTest.Constante;

namespace UnitTest
{
    public class ReleasesServiceTest
    {
        [Theory, AutoVelocityData]
        public async Task ListReleases(ReleasesService sut)
        {
            var (releasesList, errorMessage) = await sut.ListReleases(organization, teamProject);

            Assert.Null(errorMessage);
            Assert.NotNull(releasesList);
            Assert.Equal(17, releasesList.Count);
            Assert.Equal(17, releasesList.Value.Count);
        }
    }
}
