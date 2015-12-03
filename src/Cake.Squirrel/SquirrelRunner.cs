using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Squirrel {
    /// <summary>
    /// The Squirrel package runner.
    /// </summary>
    public class SquirrelRunner : Tool<SquirrelSettings> {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="SquirrelRunner"/> class.
        /// </summary>
        /// <param name="fileSystem"></param>
        /// <param name="environment"></param>
        /// <param name="globber"></param>
        /// <param name="processRunner"></param>
        public SquirrelRunner(IFileSystem fileSystem, ICakeEnvironment environment, IGlobber globber, IProcessRunner processRunner)
            : base(fileSystem, environment, processRunner, globber) {}


        public void Run(FilePath nugetPackage, SquirrelSettings settings) {
            if (nugetPackage == null) {
                throw new ArgumentNullException(nameof(nugetPackage));
            }

            if (settings == null) {
                throw new ArgumentNullException(nameof(settings));
            }

            Run(settings, GetArguments(nugetPackage, settings));
        }

        private ProcessArgumentBuilder GetArguments(FilePath nugetPackage, SquirrelSettings settings) {
            var builder = new ProcessArgumentBuilder();
            builder.Append("--releasify {0}", nugetPackage.FullPath);

            if (settings.ReleaseDirectory != null) {
                builder.Append("--releaseDir {0}", settings.ReleaseDirectory.FullPath);
            }
            if (settings.PackagesDirectory != null) {
                builder.Append("--packagesDir {0}", settings.PackagesDirectory.FullPath);
            }
            if (settings.BootstrapperExe != null) {
                builder.Append("--bootstrapperExe {0}", settings.BootstrapperExe.FullPath);
            }
            if (settings.LoadingGif != null) {
                builder.Append("--loadingGif {0}", settings.LoadingGif.FullPath);
            }
            if (settings.Icon != null) {
                builder.Append("--icon {0}", settings.Icon.FullPath);
            }
            if (settings.SetupIcon != null) {
                builder.Append("--setupIcon {0}", settings.SetupIcon.FullPath);
            }
            if (!string.IsNullOrEmpty(settings.SigningParameters)) {
                builder.Append("--signWithParams {0}", settings.SigningParameters);
            }
            if (settings.Silent) {
                builder.Append("--silent");
            }
            if (settings.NoMsi) {
                builder.Append("--no-msi");
            }

            return builder;
        }

        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        /// <returns>The name of the tool.</returns>
        protected override IEnumerable<string> GetToolExecutableNames() {
            return new[] {"Squirrel.exe"};
        }

        /// <summary>
        /// Gets the possible names of the tool executable.
        /// </summary>
        /// <returns>List of possible executable names.</returns>
        protected override string GetToolName() {
            return "Squirrel";
        }
    }
}
