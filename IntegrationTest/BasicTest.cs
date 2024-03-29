using AzureDevOpsTeamMembersVelocity;
using IntegrationTest.ApplicationFactory;
using IntegrationTest.Helpers;
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
        [InlineData("/PullRequest")]
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
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
            Assert.Equal($"http://localhost{url}", response.RequestMessage.RequestUri.AbsoluteUri);
            // There is no error message display to the user
            var content = await HtmlHelpers.GetDocumentAsync(response);
            var message = content.QuerySelector("li[class='list-group-item list-group-item-danger']");
            Assert.Null(message?.InnerHtml);
        }
    }
}
