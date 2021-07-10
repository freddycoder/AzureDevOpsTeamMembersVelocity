using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;
using AzureDevOpsTeamMembersVelocity.Proxy;
using AzureDevOpsTeamMembersVelocity.Repository;
using NSubstitute;
using System;
using System.IO.Abstractions;
using UnitTest.AutoData.Customization;

namespace UnitTest.AutoData
{
    public class AutoVelocityData : AutoDataAttribute
    {
        public AutoVelocityData() : this(() => new Fixture())
        {

        }

        public AutoVelocityData(Func<IFixture> fixtureFactory) : base(() =>
        {
            var fixture = fixtureFactory();

            fixture.Customize(new AutoNSubstituteCustomization())
                   .Customize(new ProxyCustomization());

            fixture.Register<IUserPreferenceRepository>(() => new MockUserPreferenceRepository());

            fixture.Freeze<IFile>();

            return fixture;
        })
        {
            
        }
    }
}
