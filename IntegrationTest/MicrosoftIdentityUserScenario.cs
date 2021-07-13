using AngleSharp.Html.Dom;
using AzureDevOpsTeamMembersVelocity;
using IntegrationTest.ApplicationFactory;
using IntegrationTest.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTest
{
    public class MicrosoftIdentityUserScenario : IClassFixture<MicrosoftIdentityTeamVelocityWebAppFactory<Startup>>
    {
        private readonly TeamVelocityWebAppFactory<Startup> _factory;

        public MicrosoftIdentityUserScenario(MicrosoftIdentityTeamVelocityWebAppFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task TestCreateAccountOk()
        {
            var client = _factory.CreateClient();

            var loginPage = await client.GetAsync("/");

            Assert.Equal("http://localhost/identity/account/login?returnUrl=/", loginPage.RequestMessage.RequestUri.AbsoluteUri);

            var content = await HtmlHelpers.GetDocumentAsync(loginPage);

            var registerNewUserLink = (IHtmlAnchorElement)content.QuerySelector("a[id='register-new-user']");

            Assert.Equal("Register as a new user", registerNewUserLink.TextContent);
            Assert.Equal("http://localhost/Identity/Account/Register?returnUrl=%2F", registerNewUserLink.Href);

            var page = await client.GetAsync(registerNewUserLink.Href);

            Assert.Equal("http://localhost/Identity/Account/Register?returnUrl=%2F", page.RequestMessage.RequestUri.AbsoluteUri);

            content = await HtmlHelpers.GetDocumentAsync(page);

            const string email = "abc@def.com";
            const string password = "$tringPassw0r2";

            page = await client.SendAsync(
                (IHtmlFormElement)content.QuerySelector("form[id='register-form']"),
                (IHtmlButtonElement)content.QuerySelector("button[id='register_btn']"),
                new Dictionary<string, string>
                {
                    { "Input.Email", email },
                    { "Input.Password", password },
                    { "Input.ConfirmPassword", password }
                });

            Assert.Equal($"http://localhost/Identity/Account/RegisterConfirmation?email={email}&returnUrl=%2F", page.RequestMessage.RequestUri.AbsoluteUri);

            content = await HtmlHelpers.GetDocumentAsync(page);

            var confirmEmailLink = (IHtmlAnchorElement)content.QuerySelector("a[id='confirm-link']");

            page = await client.GetAsync(confirmEmailLink.Href);

            content = await HtmlHelpers.GetDocumentAsync(page);

            var loginLink = (IHtmlAnchorElement)content.QuerySelector("a[id='login']");

            page = await client.GetAsync(loginLink.Href);

            content = await HtmlHelpers.GetDocumentAsync(page);

            page = await client.SendAsync(
                (IHtmlFormElement)content.QuerySelector("form[id='account']"),
                (IHtmlButtonElement)content.QuerySelector("button[id='login_btn']"),
                new Dictionary<string, string>
                {
                    { "Input.Email", email },
                    { "Input.Password", password }
                });

            Assert.Equal("http://localhost/", page.RequestMessage.RequestUri.AbsoluteUri);
        }
    }
}
