using Cake.Squirrel.Tests.Fixture;
using System;
using Xunit;
using Should;
using Cake.Core;
using Cake.Testing;

namespace Cake.Squirrel.Tests {
    public class SquirrelRunnerTests {
        [Fact]
        public void Should_Throw_NuGet_Package_Is_Null() {
            // Given
            var fixture = new SquirrelRunnerFixture();
            fixture.NuGetPath = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("nugetPackage");
        }

        [Fact]
        public void Should_Throw_If_Settings_Are_Null() {
            // Given
            var fixture = new SquirrelRunnerFixture();
            fixture.Settings = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("settings");
        }

        [Fact]
        public void Should_Throw_If_Squirrel_Executable_Was_Not_Found() {
            // Given
            var fixture = new SquirrelRunnerFixture();
            fixture.GivenDefaultToolDoNotExist();

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            result.ShouldBeType<CakeException>().Message.ShouldEqual("Squirrel: Could not locate executable.");
        }

        [Theory]
        [InlineData("/bin/tools/Squirrel/Squirrel.exe", "/bin/tools/Squirrel/Squirrel.exe")]
        [InlineData("./tools/Squirrel/Squirrel.exe", "/Working/tools/Squirrel/Squirrel.exe")]
        public void Should_Use_Squirrel_Executable_From_Tool_Path_If_Provided(string toolPath, string expected) {
            // Given
            var fixture = new SquirrelRunnerFixture();
            fixture.Settings.ToolPath = toolPath;
            fixture.GivenSettingsToolPathExist();

            // When
            var result = fixture.Run();

            // Then
            result.Path.FullPath.ShouldEqual(expected);
        }

        [Fact]
        public void Should_Throw_If_Process_Was_Not_Started() {
            // Given
            var fixture = new SquirrelRunnerFixture();
            fixture.GivenProcessCannotStart();

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            result.ShouldBeType<CakeException>().Message.ShouldEqual("Squirrel: Process was not started.");
        }

        [Fact]
        public void Should_Throw_If_Process_Has_A_Non_Zero_Exit_Code() {
            // Given
            var fixture = new SquirrelRunnerFixture();
            fixture.GivenProcessExitsWithCode(1);

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            result.ShouldBeType<CakeException>()
                .Message.ShouldEqual("Squirrel: Process returned an error (exit code 1).");
        }

        [Fact]
        public void Should_Find_Squirrel_Executable_If_Tool_Path_Not_Provided() {
            // Given
            var fixture = new SquirrelRunnerFixture();

            // When
            var result = fixture.Run();

            // Then
            result.Path.FullPath.ShouldEqual("/Working/tools/Squirrel.exe");
        }

        [Fact]
        public void Should_Add_NuGet_Package_To_Arguments() {
            // Given 
            var fixture = new SquirrelRunnerFixture();

            // When
            var result = fixture.Run();

            // Then
            result.Args.ShouldEqual("--releasify \"Package.nupkg\"");
        }

        [Fact]
        public void Should_Include_No_Delta_Flag_To_Arguments()
        {
            // Given 
            var fixture = new SquirrelRunnerFixture();

            // When
            fixture.Settings.NoDelta = true;
            var result = fixture.Run();

            // Then
            result.Args.ShouldEqual("--releasify \"Package.nupkg\" --no-delta");
        }
    }
}
