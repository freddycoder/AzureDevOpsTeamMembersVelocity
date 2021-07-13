using AngleSharp.Html.Dom;
using AzureDevOpsTeamMembersVelocity;
using IntegrationTest.ApplicationFactory;
using IntegrationTest.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTest
{
    public class EnvrionmentVariableUserScenario : IClassFixture<CookieAuthTeamVelocityWebAppFactory<Startup>>
    {
        private readonly TeamVelocityWebAppFactory<Startup> _factory;

        public EnvrionmentVariableUserScenario(CookieAuthTeamVelocityWebAppFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task TestAuthenticationOk()
        {
            var client = _factory.CreateClient();

            var loginPage = await client.GetAsync("/");

            Assert.Equal("http://localhost/Login", loginPage.RequestMessage.RequestUri.AbsoluteUri);

            var content = await HtmlHelpers.GetDocumentAsync(loginPage);

            var page = await client.SendAsync(
                (IHtmlFormElement)content.QuerySelector("form[id='account']"),
                (IHtmlButtonElement)content.QuerySelector("button[id='login_btn']"),
                new Dictionary<string, string>
                {
                    { "Email", "test@integ.com" },
                    { "Password", "123" }
                });

            Assert.Equal("http://localhost/", page.RequestMessage.RequestUri.AbsoluteUri);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("any@mail.com", "123")]
        [InlineData("test@integ.com", "")]
        [InlineData("test@integ.com", "1234")]
        public async Task TestAuthenticationBadLogin(string username, string password)
        {
            var client = _factory.CreateClient();

            var loginPage = await client.GetAsync("/");

            Assert.Equal("http://localhost/Login", loginPage.RequestMessage.RequestUri.AbsoluteUri);

            var content = await HtmlHelpers.GetDocumentAsync(loginPage);

            var page = await client.SendAsync(
                (IHtmlFormElement)content.QuerySelector("form[id='account']"),
                (IHtmlButtonElement)content.QuerySelector("button[class='btn btn-primary']"),
                new Dictionary<string, string>
                {
                    { "Email", username },
                    { "Password", password }
                });

            Assert.Equal("http://localhost/Login", page.RequestMessage.RequestUri.AbsoluteUri);
        }
    }
}
