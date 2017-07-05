using System;
using Cake.Core;
using Cake.Squirrel.Tests.Fixture;
using Cake.Testing;
using Should;
using Xunit;

namespace Cake.Squirrel.Tests {
    public class SyncReleasesRunnerTests {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null() {
            // Given
            var fixture = new SyncReleasesRunnerFixture();
            fixture.Settings = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("settings");
        }

        [Fact]
        public void Should_Throw_If_SyncReleasesl_Executable_Was_Not_Found() {
            // Given
            var fixture = new SyncReleasesRunnerFixture();
            fixture.GivenDefaultToolDoNotExist();

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            result.ShouldBeType<CakeException>().Message.ShouldEqual("SyncReleases: Could not locate executable.");
        }

        [Theory]
        [InlineData("/bin/tools/Squirrel/SyncReleases.exe", "/bin/tools/Squirrel/SyncReleases.exe")]
        [InlineData("./tools/Squirrel/SyncReleases.exe", "/Working/tools/Squirrel/SyncReleases.exe")]
        public void Should_Use_SyncReleases_Executable_From_Tool_Path_If_Provided(string toolPath, string expected) {
            // Given
            var fixture = new SyncReleasesRunnerFixture();
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
            var fixture = new SyncReleasesRunnerFixture();
            fixture.GivenProcessCannotStart();

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            result.ShouldBeType<CakeException>().Message.ShouldEqual("SyncReleases: Process was not started.");
        }

        [Fact]
        public void Should_Throw_If_Process_Has_A_Non_Zero_Exit_Code() {
            // Given
            var fixture = new SyncReleasesRunnerFixture();
            fixture.GivenProcessExitsWithCode(1);

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            result.ShouldBeType<CakeException>()
                .Message.ShouldEqual("SyncReleases: Process returned an error (exit code 1).");
        }

        [Fact]
        public void Should_Find_SyncReleases_Executable_If_Tool_Path_Not_Provided() {
            // Given
            var fixture = new SyncReleasesRunnerFixture();

            // When
            var result = fixture.Run();

            // Then
            result.Path.FullPath.ShouldEqual("/Working/tools/SyncReleases.exe");
        }

        [Fact]
        public void Should_Add_Url_To_Arguments() {
            // Given 
            var fixture = new SyncReleasesRunnerFixture();
            fixture.Settings.Url = "https://google.com";

            // When
            var result = fixture.Run();

            // Then
            result.Args.ShouldEqual("--url https://google.com");
        }
    }
}
