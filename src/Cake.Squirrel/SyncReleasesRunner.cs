using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Squirrel {
    /// <summary>
    /// The SyncReleases runner.
    /// </summary>
    public class SyncReleasesRunner : Tool<SyncReleasesSettings> {
        /// <summary>
        /// Initializes a new instance of the <see cref="SyncReleasesRunner"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        public SyncReleasesRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
            IToolLocator tools) : base(fileSystem, environment, processRunner, tools) { }

        /// <summary>
        /// Executes SyncReleases with the specificed parameters.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Run(SyncReleasesSettings settings) {
            if (settings == null) {
                throw new ArgumentNullException(nameof(settings));
            }

            Run(settings, GetArguments(settings));
        }

        /// <summary>
        ///  Executes SyncReleases with the specificed parameters.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="processSettings">The process settings.</param>
        public void Run(SyncReleasesSettings settings, ProcessSettings processSettings) {
            if (settings == null) {
                throw new ArgumentNullException(nameof(settings));
            }
            if (settings == null) {
                throw new ArgumentNullException(nameof(processSettings));
            }
            Run(settings, GetArguments(settings), processSettings, null);
        }
        
        private ProcessArgumentBuilder GetArguments(SyncReleasesSettings settings) {
            var builder = new ProcessArgumentBuilder();
            if (settings.ReleaseDirectory != null) {
                builder.Append("--releaseDir {0}", settings.ReleaseDirectory.FullPath);
            }
            if (!string.IsNullOrWhiteSpace(settings.Url)) {
                builder.Append("--url {0}", settings.Url);
            }
            if (!string.IsNullOrWhiteSpace(settings.Token)) {
                builder.Append("--token {0}", settings.Token);
            }

            return builder;
        }

        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        /// <returns>The name of the tool.</returns>
        protected override string GetToolName() {
            return "SyncReleases";
        }

        /// <summary>
        /// Gets the possible names of the tool executable.
        /// </summary>
        /// <returns>List of possible executable names.</returns>
        protected override IEnumerable<string> GetToolExecutableNames() {
            return new[] {"SyncReleases.exe"};
        }
    }
}
