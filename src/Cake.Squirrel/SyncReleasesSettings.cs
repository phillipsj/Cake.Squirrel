using System;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Squirrel {
    /// <summary>
    /// Contains settings used by <see cref="SyncReleasesRunner"/>.
    /// </summary>
    public class SyncReleasesSettings : ToolSettings {
        /// <summary>
        ///     Gets or sets the release directory path to download to.
        /// </summary>
        public DirectoryPath ReleaseDirectory { get; set; }

        /// <summary>
        /// Gets or sets the URL to the remote releases folder. When pointing to GitHub, use the URL 
        /// to the repository root page, else point to an existing remote Releases folder
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the OAth token to use as login credentials.
        /// </summary>
        public string Token { get; set; }
    }
}
