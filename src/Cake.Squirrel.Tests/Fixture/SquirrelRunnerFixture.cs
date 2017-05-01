using Cake.Core.IO;
using Cake.Testing.Fixtures;

namespace Cake.Squirrel.Tests.Fixture {
    internal sealed class SquirrelRunnerFixture : ToolFixture<SquirrelSettings> {
        public FilePath NuGetPath { get; set; }

        public SquirrelRunnerFixture() : base("Squirrel.exe") {
            NuGetPath = "Package.nupkg";
        }

        protected override void RunTool() {
            var tool = new SquirrelRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Run(NuGetPath, Settings);
        }
    }
}
