using System;

namespace PolyDeploy.DeployClient
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Spectre.Console;

    public class Renderer : IRenderer
    {
        private readonly IAnsiConsole console;

        public Renderer(IAnsiConsole console)
        {
            this.console = console;
        }

        public void Welcome()
        {
            this.console.Write(new FigletText("PolyDeploy").Color(Color.Orange1));
        }

        public async Task RenderFileUploadsAsync(IEnumerable<(string file, Task uploadTask)> uploads)
        {
            if (this.console.Profile.Capabilities.Interactive)
            {
                // TODO: actually show upload progress
                await this.console.Progress()
                    .StartAsync(async context =>
                    {
                        await Task.WhenAll(uploads.Select(async upload =>
                        {
                            var progressTask = context.AddTask(upload.file);
                            await upload.uploadTask;
                            progressTask.Increment(100);
                            progressTask.StopTask();
                        }));
                    });
            }
            else
            {
                await Task.WhenAll(uploads.Select(async upload =>
                {
                    await upload.uploadTask;
                    this.console.Write(new Markup($"{upload.file} upload complete"));
                }));
            }
        }

        public void RenderInstallationOverview(SortedList<int, SessionResponse?> packageFiles)
        {
            var tree = new Tree(new Markup(":file_folder: [yellow]Packages[/]"));
            foreach (var packageFile in packageFiles.Values)
            {
                if (packageFile == null)
                {
                    continue;
                }

                var fileNode = tree.AddNode(new Markup($":page_facing_up: [aqua]{packageFile.Name}[/]"));
                if (packageFile.Packages == null)
                {
                    continue;
                }

                foreach (var package in packageFile.Packages)
                {
                    if (package == null)
                    {
                        continue;
                    }

                    var packageNode = fileNode.AddNode(new Markup($":wrapped_gift: [lime]{package.Name}[/] [grey]{package.VersionStr}[/]"));
                    if (package.Dependencies == null)
                    {
                        continue;
                    }

                    foreach (var dependency in package.Dependencies)
                    {
                        if (dependency == null)
                        {
                            continue;
                        }

                        if (string.IsNullOrEmpty(dependency.DependencyVersion) && !dependency.IsPackageDependency)
                        {
                            packageNode.AddNode(new Markup($"Depends on :wrapped_gift: [lime]Platform Version[/] [grey]{dependency.PackageName}[/]"));
                        }
                        else
                        {
                            packageNode.AddNode(new Markup($"Depends on :wrapped_gift: [lime]{dependency.PackageName}[/] [grey]{dependency.DependencyVersion}[/]"));
                        }
                    }
                }
            }

            this.console.Write(tree);
        }

        public void RenderListOfFiles(IEnumerable<string> files)
        {
            var fileTree = new Tree(new Markup(":file_folder: [yellow]Packages[/]"));
            fileTree.AddNodes(files.Select(f => new Markup($":page_facing_up: [aqua]{f}[/]")));

            this.console.Write(fileTree);
        }

        public void RenderInstallationStatus(SortedList<int, SessionResponse?> packageFiles)
        {
            foreach (var file in packageFiles.Values)
            {
                if (file?.Name is null) continue;
                if (file.Success && !SucceededPackageFiles.Contains(file.Name))
                {
                    this.console.Write(new Markup($":check_mark_button: [aqua]{file.Name}[/] [green]Succeeded[/]"));
                    this.console.WriteLine();
                    SucceededPackageFiles.Add(file.Name);
                }

                if (file.Failures?.Any() == true && !FailedPackageFiles.Contains(file.Name))
                {
                    var failureTree = new Tree(new Markup($":cross_mark: [aqua]{file.Name}[/] [red]Failed[/]"));
                    failureTree.AddNodes(file.Failures.Where(f => f != null).Select(f => f!));
                    this.console.Write(failureTree);
                    FailedPackageFiles.Add(file.Name);
                }
            }
        }

        public void RenderError(string message, Exception exception)
        {
            this.console.WriteLine(message);
            this.console.WriteException(exception);
        }

        private readonly HashSet<string> SucceededPackageFiles = new HashSet<string>();
        private readonly HashSet<string> FailedPackageFiles = new HashSet<string>();
    }
}
