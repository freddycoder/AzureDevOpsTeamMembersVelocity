using AzureDevOpsTeamMembersVelocity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using UnitTest.AutoData;
using Xunit;

namespace UnitTest
{
    public class StartupTest
    {
        [Theory, AutoVelocityData]
        public void Constructor_BuildStartup_ConfigurationIsAssigned(IConfiguration configuration)
        {
            var startup = new Startup(configuration);

            Assert.Equal(configuration, startup.Configuration);
        }

        [Theory, AutoVelocityData]
        public void ConfigureServices_ExecuteMethod_NoException(Startup sut)
        {
            var servicesCollection = new ServiceCollection();
            Assert.Empty(servicesCollection);

            sut.ConfigureServices(servicesCollection);

            Assert.NotEmpty(servicesCollection);
        }

        [Theory, AutoVelocityData]
        public void Configure_ExecuteMethod_NoException(IWebHostEnvironment webHostEnvir, IConfiguration configuration, Startup sut)
        {
            var servicesCollection = new ServiceCollection();
            Assert.Empty(servicesCollection);
            sut.ConfigureServices(servicesCollection);
            servicesCollection.AddSingleton(sp => NSubstitute.Substitute.For<IHostApplicationLifetime>());
            servicesCollection.AddSingleton(sp => configuration);
            var provider = servicesCollection.BuildServiceProvider();
            var app = new ApplicationBuilder(provider, NSubstitute.Substitute.For<IFeatureCollection>());
            Assert.NotNull(app.ServerFeatures);

            sut.Configure(app,
                          webHostEnvir,
                          provider,
                          provider.GetRequiredService<ILogger<Startup>>());

            Assert.NotEmpty(servicesCollection);
        }
    }
}
