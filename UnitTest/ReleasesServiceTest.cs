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
            if (releasesList is null)
            {
                return;
            }
            Assert.Equal(17, releasesList.Count);
            Assert.NotNull(releasesList.Value);
            if (releasesList.Value is null)
            {
                return;
            }
            Assert.Equal(17, releasesList.Value.Count);
        }
    }
}
