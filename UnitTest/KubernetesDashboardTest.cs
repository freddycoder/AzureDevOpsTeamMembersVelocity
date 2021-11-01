using AzureDevOpsTeamMembersVelocity.Pages;
using UnitTest.AutoData;
using Xunit;

namespace UnitTest
{
    public class KubernetesDashboardTest
    {
        [Theory, AutoVelocityData]
        public void Test(KubernetesDashboard sut)
        {
            Assert.NotNull(sut);
        }
    }
}
