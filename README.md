# Cake.Squirrel

A Cake Addin for [Squirrel.Windows](https://github.com/Squirrel/Squirrel.Windows).

[![Build status](https://ci.appveyor.com/api/projects/status/6bv8xgvgr5acpdki?svg=true)](https://ci.appveyor.com/project/cakecontrib/cake-squirrel)

[![cakebuild.net](https://img.shields.io/badge/WWW-cakebuild.net-blue.svg)](http://cakebuild.net/)

[![Join the chat at https://gitter.im/cake-build/cake](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/cake-build/cake?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

## Functionality

Supports all the current command line options provided by Squirrel.Windows

```cmd
Usage: Squirrel.exe command [OPTS]
Manages Squirrel packages

Commands
      --releasify=VALUE      Update or generate a releases directory with a
                               given NuGet package
Options:
  -h, -?, --help             Display Help and exit
  -r, --releaseDir=VALUE     Path to a release directory to use with releasify
  -p, --packagesDir=VALUE    Path to the NuGet Packages directory for C# apps
      --bootstrapperExe=VALUE
                             Path to the Setup.exe to use as a template
  -g, --loadingGif=VALUE     Path to an animated GIF to be displayed during
                               installation
  -i, --icon=VALUE           Path to an ICO file that will be used for icon
                               shortcuts
      --setupIcon=VALUE      Path to an ICO file that will be used for the
                               Setup executable's icon
  -n, --signWithParams=VALUE Sign the installer via SignTool.exe with the
                               parameters given
  -s, --silent               Silent install
  -l, --shortcut-locations=VALUE
                             Comma-separated string of shortcut locations, e.g.
                               'Desktop,StartMenu'
      --no-msi               Don't generate an MSI package
```

## Usage

To use the addin just add it to Cake call the aliases and configure any settings you want.

```csharp
#tool "Squirrel.Windows"
#addin Cake.Squirrel

...

// How to package with no settings
Task("PackageNoSettings")
	.Does(() => {
		Squirrel(GetFile("Package.nupkg"));
	});
	
// How to package with the settings
Task("PackageWithSettings")
	.Does(() => {
		var settings = new SquirrelSettings();
		settings.NoMsi = true;
		settings.Silent = true;
		
		Squirrel(GetFile("Package.nupkg", settings));
	});
```

Thats it.

Hope you enjoy using.

## Support

If you would like to support this project, there are several opportunities. Pull Requests, bug reports, documentation, promotion, and encouragement are all great ways. If you would like to contribute monetarily, you can [Buy Me a Coffee](https://www.buymeacoffee.com/aQPnJ73O8).
