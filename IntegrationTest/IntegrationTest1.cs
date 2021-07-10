using AzureDevOpsTeamMembersVelocity;
using IntegrationTest.ApplicationFactory;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTest
{
    public class BasicTests : IClassFixture<TeamVelocityWebAppFactory<Startup>>
    {
        private readonly TeamVelocityWebAppFactory<Startup> _factory;

        public BasicTests(TeamVelocityWebAppFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/SprintAnalysis")]
        [InlineData("/Git")]
        [InlineData("/CodeBot")]
        [InlineData("/Releases")]
        [InlineData("/Nuget")]
        [InlineData("/Kubernetes")]
        [InlineData("/NonExistingPage")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
