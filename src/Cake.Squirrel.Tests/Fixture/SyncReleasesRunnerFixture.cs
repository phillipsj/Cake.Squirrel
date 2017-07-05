using Cake.Testing.Fixtures;

namespace Cake.Squirrel.Tests.Fixture {
    internal sealed class SyncReleasesRunnerFixture : ToolFixture<SyncReleasesSettings> {
        public SyncReleasesRunnerFixture() : base("SyncReleases.exe") { }

        protected override void RunTool() {
            var tool = new SyncReleasesRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Run(Settings);
        }
    }
}
