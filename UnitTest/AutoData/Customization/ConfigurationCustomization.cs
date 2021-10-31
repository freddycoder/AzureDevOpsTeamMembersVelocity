using AutoFixture;
using Microsoft.Extensions.Configuration;

namespace UnitTest.AutoData.Customization
{
    public class ConfigurationCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Register<IConfiguration>(() => new ConfigurationBuilder()
                                                        .AddJsonFile("appsettings.json")
                                                        .Build());

            fixture.Freeze<IConfiguration>();
        }
    }
}
