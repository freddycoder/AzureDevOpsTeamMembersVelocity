using AzureDevOpsTeamMembersVelocity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.AutoData;
using Xunit;
using static UnitTest.Constante;

namespace UnitTest
{
    public class GitServiceTest
    {
        [Theory, AutoVelocityData]
        public async Task GetPullRequestThreadComments(GitService gitService)
        {
            var (pr, error) = await gitService.GetComments(
                organization, new Guid("3411ebc1-d5aa-464f-9615-0b527bc66719"), 22);

            Assert.Null(error);
            Assert.NotNull(pr);
        }

        [Theory, AutoVelocityData]
        public async Task HttpClientNotFound(GitService gitService)
        {
            var (pr, error) = await gitService.GetComments(
                Guid.NewGuid().ToString(), Guid.NewGuid(), DateTime.Now.Year);

            Assert.NotNull(error);
            Assert.Null(pr);
        }
    }
}
