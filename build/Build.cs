using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

[CheckBuildProjectConfigurations]
[UnsetVisualStudioEnvironmentVariables]
internal class Build : NukeBuild
{
	[Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
	private readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

	[GitRepository]
	private readonly GitRepository GitRepository;

	[GitVersion]
	private readonly GitVersion GitVersion;

	[Solution]
	private readonly Solution Solution;

	private AbsolutePath SourceDirectory => RootDirectory / "src";

	private AbsolutePath TestsDirectory => RootDirectory / "tests";

	private AbsolutePath OutputDirectory => RootDirectory / "output";

	Target Clean => _ => _
		.Before(Restore)
		.Executes(() =>
		{
			SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
			TestsDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
			EnsureCleanDirectory(OutputDirectory);
		});

	Target Restore => _ => _
		.Executes(() =>
		{
			DotNetRestore(s => s
				.SetProjectFile(Solution));
		});

	private Target RunTests => _ => _
		.DependsOn(Compile)
		.Executes(() =>
		{
			DotNetTest(s => s
				.SetProjectFile(TestsDirectory + "/VkScript.Parser.Tests")
				.SetFramework("netcoreapp3.1")
				.SetConfiguration(Configuration)
				.SetNoBuild(false));
		});

	Target Compile => _ => _
		.DependsOn(Restore)
		.Executes(() =>
		{
			DotNetBuild(s => s
				.SetProjectFile(Solution)
				.SetConfiguration(Configuration)
				.SetAssemblyVersion(GitVersion.AssemblySemVer)
				.SetFileVersion(GitVersion.AssemblySemFileVer)
				.SetInformationalVersion(GitVersion.InformationalVersion)
				.EnableNoRestore());
		});

	/// Support plugins are available for:
	/// - JetBrains ReSharper        https://nuke.build/resharper
	/// - JetBrains Rider            https://nuke.build/rider
	/// - Microsoft VisualStudio     https://nuke.build/visualstudio
	/// - Microsoft VSCode           https://nuke.build/vscode
	public static int Main() => Execute<Build>(x => x.RunTests);
}