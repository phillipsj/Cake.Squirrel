using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;

namespace Cake.Squirrel {
    /// <summary>
    /// Contains functionality related to running Squirrel.
    /// </summary>
    [CakeAliasCategory("Squirrel")]
    public static class SquirrelAliases
    {
        /// <summary>
        /// Runs Squirrel Releasify against the specified NuGet package.
        /// </summary>
        /// <example>
        /// <code>
        /// Task("PackageNoSettings")
        ///  .Does(() => {
        ///    Squirrel(GetFile("Package.nupkg"));
        /// });
        /// </code>
        /// </example>
        /// <param name="context">The context.</param>
        /// <param name="nugetPackage">NuGet package to releasify.</param>
        [CakeMethodAlias]
        public static void Squirrel(this ICakeContext context, FilePath nugetPackage) {
            Squirrel(context, nugetPackage, new SquirrelSettings());
        }

        /// <summary>
        /// Runs Squirrel Releasify against the specified NuGet package
        /// using the specified settings.
        /// </summary>
        /// <example>
        /// <code>
        /// Task("PackageWithSettings")
        ///  .Does(() => {
        ///    var settings = new SquirrelSettings();
        ///    settings.NoMsi = true;
        ///    settings.Silent = true;
        /// 
        ///    Squirrel(GetFile("Package.nupkg", settings));
        /// });
        /// </code>
        /// </example>
        /// <param name="context">The context.</param>
        /// <param name="nugetPackage">NuGet package to releasify.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void Squirrel(this ICakeContext context, FilePath nugetPackage, SquirrelSettings settings) {
            if (context == null) {
                throw new ArgumentNullException(nameof(context));
            }
            if (nugetPackage == null) {
                throw new ArgumentNullException(nameof(nugetPackage));
            }
            var runner = new SquirrelRunner(context.FileSystem, context.Environment, context.Globber, context.ProcessRunner);
            runner.Run(nugetPackage, settings);
        }
    }
}
