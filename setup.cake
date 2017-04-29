#load nuget:https://www.myget.org/F/cake-contrib/api/v2?package=Cake.Recipe&prerelease

Environment.SetVariableNames();

BuildParameters.SetParameters(context: Context, 
                            buildSystem: BuildSystem,
                            sourceDirectoryPath: "./src",
                            title: "Cake.Squirrel",
                            repositoryOwner: "phillipsj",
                            repositoryName: "Cake.Squirrel",
                            appVeyorAccountName: "phillipsj");

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context,
                            dupFinderExcludePattern: new string[] { 
                                BuildParameters.RootDirectoryPath + "/src/Cake.Squirrel.Tests/*.cs", BuildParameters.RootDirectoryPath + "/src/Cake.Squirrel/SquirrelAliases.cs" },
                            testCoverageFilter: "+[*]* -[xunit.*]* -[Cake.Core]* -[Cake.Testing]* -[*.Tests]* ",
                            testCoverageExcludeByAttribute: "*.ExcludeFromCodeCoverage*",
                            testCoverageExcludeByFile: "*/*Designer.cs;*/*.g.cs;*/*.g.i.cs");
Build.Run();