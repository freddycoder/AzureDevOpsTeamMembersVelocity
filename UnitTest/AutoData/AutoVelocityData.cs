using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;
using System;
using System.IO.Abstractions;

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

            fixture.Customize(new AutoNSubstituteCustomization());

            fixture.Freeze<IFile>();

            return fixture;
        })
        {
            
        }
    }
}
