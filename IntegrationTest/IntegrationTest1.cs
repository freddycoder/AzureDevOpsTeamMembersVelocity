using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTest
{
    public class BasicTests
    : IClassFixture<WebApplicationFactory<AzureDevOpsTeamMembersVelocity.Startup>>
    {
        private readonly WebApplicationFactory<AzureDevOpsTeamMembersVelocity.Startup> _factory;

        public BasicTests(WebApplicationFactory<AzureDevOpsTeamMembersVelocity.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Git")]
        [InlineData("/SprintAnalysis")]
        [InlineData("/CodeBot")]
        [InlineData("/Nuget")]
        [InlineData("/Kubernetes")]
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
