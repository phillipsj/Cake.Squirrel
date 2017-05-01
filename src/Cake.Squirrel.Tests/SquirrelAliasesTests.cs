using Cake.Squirrel.Tests.Fixture;
using System;
using Xunit;
using Should;
using NSubstitute;
using Cake.Core;

namespace Cake.Squirrel.Tests {
    public class SquirrelAliasesTests {
        [Fact]
        public void Should_Throw_If_Context_Is_Null() {
            // Given
            var fixture = new SquirrelRunnerFixture();

            // When
            var result = Record.Exception(() => SquirrelAliases.Squirrel(null, fixture.NuGetPath, fixture.Settings));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("context");
        }

        [Fact]
        public void Should_Throw_If_NuGet_Package_Is_Null() {
            // Given
            var fixture = new SquirrelRunnerFixture();
            var context = Substitute.For<ICakeContext>();

            // When
            var result = Record.Exception(() => SquirrelAliases.Squirrel(context, null, fixture.Settings));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("nugetPackage");
        }

        [Fact]
        public void Should_Throw_If_Settings_Are_Null() {
            // Given
            var fixture = new SquirrelRunnerFixture();
            var context = Substitute.For<ICakeContext>();

            // When
            var result = Record.Exception(() => SquirrelAliases.Squirrel(context, fixture.NuGetPath, null));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("settings");
        }
    }
}
