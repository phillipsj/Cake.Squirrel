using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Squirrel {
    /// <summary>
    /// Contains settings used by <see cref="SquirrelRunner"/>.
    /// </summary>
    public class SquirrelSettings : ToolSettings {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SquirrelSettings"/> class.
        /// </summary>
        public SquirrelSettings() {}

        /// <summary>
        ///     Gets or sets the release directory location.
        /// </summary>
        /// <value>
        ///     Path to a release directory to use with releasify.
        /// </value>
        public DirectoryPath ReleaseDirectory { get; set; }

        /// <summary>
        ///     Gets or sets the packages directory location.
        /// </summary>
        /// <value>
        ///     Path to the NuGet Packages directory for C# apps
        /// </value>
        public DirectoryPath PackagesDirectory { get; set; }

        /// <summary>
        ///     Gets or sets the Setup.exe for boostrapping.
        /// </summary>
        /// <value>
        ///     Path to the Setup.exe to use as a template
        /// </value>
        public DirectoryPath BootstrapperExe { get; set; }

        /// <summary>
        ///     Gets or sets the filepath to the loading gif.
        /// </summary>
        /// <value>
        ///     Path to an animated GIF to be displayed during installation.
        /// </value>
        public FilePath LoadingGif { get; set; }

        /// <summary>
        ///     Gets or sets the filepath to the icon for shortcuts.
        /// </summary>
        /// <value>
        ///     Path to an ICO file that will be used for icon shortcuts.
        /// </value>
        public FilePath Icon { get; set; }

        /// <summary>
        ///     Gets or sets the filepath to the setup executable's icon.
        /// </summary>
        /// <value>
        ///     Path to an ICO file that will be used for the Setup executable's icon.
        /// </value>
        public FilePath SetupIcon { get; set; }

        /// <summary>
        ///     Gets or sets the parameters to be passed to SignTool.exe.
        /// </summary>
        /// <value>
        ///     Sign the installer via SignTool.exe with the parameters given
        /// </value>
        public string SigningParameters { get; set; }

        /// <summary>
        ///     Gets or sets if it should be a silent install.
        /// </summary>
        /// <value>
        ///     <c>true</c> if a silent install; otherwise, <c>false</c>.
        /// </value>
        public bool Silent { get; set; }

        /// <summary>
        ///     Gets or sets shortcut locations.
        /// </summary>
        /// <value>
        ///     Comma-separated string of shortcut locations, e.g. 'Desktop,StartMenu'.
        /// </value>
        public string ShortCutLocations { get; set; }

        /// <summary>
        ///     Gets or sets if an MSI package should be created.
        /// </summary>
        /// <value>
        ///     <c>true</c> to not generate an MSI package; otherwise, <c>false</c>.
        /// </value>
        public bool NoMsi { get; set; }

        /// <summary>
        ///     Gets or sets the required .NET framework version
        /// </summary>
        /// <value>
        ///     .NET framework version, e.g. net461
        /// </value>
        public string FrameworkVersion { get; set; }
    }
}
