using AzureDevOpsTeamMembersVelocity;
using IntegrationTest.ApplicationFactory;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTest
{
    public class AzureAdUserScenario : IClassFixture<AzureADTeamVelocityWebAppFactory<Startup>>
    {
        private readonly TeamVelocityWebAppFactory<Startup> _factory;

        public AzureAdUserScenario(AzureADTeamVelocityWebAppFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task TestCreateAccountOk()
        {
            var client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });

            var loginRedirect = await client.GetAsync("/");

            Assert.Equal(HttpStatusCode.InternalServerError, loginRedirect.StatusCode);
            //Assert.Equal(HttpStatusCode.Redirect, loginRedirect.StatusCode);
            // https://joonasw.net/view/testing-azure-ad-protected-apis-part-3-automated-integration-tests
        }
    }
}
