using AutoFixture;
using AzureDevOpsTeamMembersVelocity.Proxy;
using NSubstitute;
using RichardSzalay.MockHttp;
using System.IO;
using System.Net.Http;

namespace UnitTest.AutoData.Customization
{
    public class ProxyCustomization : ICustomization
    {
        /// <summary>
        /// Customize the IHttpClientFactory to use MockHttpMessageHandler and
        /// register a implementation for IDevOpsProxy
        /// </summary>
        /// <param name="fixture"></param>
        public void Customize(IFixture fixture)
        {
            fixture.Register(() =>
            {
                var factorySubstitute = Substitute.For<IHttpClientFactory>();

                factorySubstitute.CreateClient(Arg.Is(nameof(DevOpsProxy)))
                                 .Returns(mockHttpClient);

                return factorySubstitute;
            });

            fixture.Register<IDevOpsProxy>(() => fixture.Create<DevOpsProxy>());
        }

        private static readonly HttpClient mockHttpClient = GetMockHttpMessageHandler_WithExampleMapped();

        private static HttpClient GetMockHttpMessageHandler_WithExampleMapped()
        {
            var handler = new MockHttpMessageHandler();

            handler.When("https://vsrm.dev.azure.com/fabrikam/MyFirstProject/_apis/release/releases?api-version=6.0")
                   .Respond("application/json", File.ReadAllText(Path.Combine(Constante.ExampleFolder, "releaseslist1.json")));

            return new HttpClient(handler);
        }
    }
}
