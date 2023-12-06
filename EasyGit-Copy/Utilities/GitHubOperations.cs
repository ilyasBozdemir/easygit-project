using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace EasyGit_Copy.Utilities
{
    public class GitHubOperations
    {
        public GitHubOperations(GitHubOperationsProps gitHubOperationsProps)
        {
            GitHubOperationsProps = gitHubOperationsProps;
        }


        public GitHubOperationsProps GitHubOperationsProps { get; set; }

        public event Action<string> LogOutput;



        private (string Owner, string Repo) GetGitHubRepoInfo(string repoUrl)
        {
            Uri uri;
            if (Uri.TryCreate(repoUrl, UriKind.Absolute, out uri))
            {
                string[] segments = uri.Segments;
                if (segments.Length >= 2)
                {
                    string owner = segments[1].Trim('/');
                    string repo = segments[2].Trim('/');

                    return (owner, repo);
                }
            }

            return (null, null);
        }



        public async void PerformGitHubOperationsAsync()
        {
            var (owner, repo) = GetGitHubRepoInfo(GitHubOperationsProps.RepoUrl);

            List<string> commands = new List<string>
            {
                $"mkdir {GitHubOperationsProps.ProjectName}",
                $"cd {GitHubOperationsProps.ProjectName}",
                $"git clone {GitHubOperationsProps.RepoUrl}",
            };


            await RunCmdCommand(commands, GitHubOperationsProps.RootLocationPath);


            string packageJsonPath = Path.Combine(GitHubOperationsProps.RootLocationPath, GitHubOperationsProps.ProjectName, repo, "package.json");
            EditPackageName(packageJsonPath, GitHubOperationsProps.ProjectName, repo);

            // Repo dizinine geçiş yaptıktan sonra repo oluştur ve push yap
            string createRepoCommand = $"gh repo create {GitHubOperationsProps.ProjectName} --public";
            string pushCommand = $"git remote add origin https://github.com/{owner}/{GitHubOperationsProps.ProjectName}.git && git push -u origin main";

            List<string> repoCommands = new List<string>
            {
                $"cd {GitHubOperationsProps.ProjectName}", // Repo dizinine geç
                createRepoCommand,
                pushCommand
            };

            await RunCmdCommand(repoCommands, GitHubOperationsProps.RootLocationPath);

        }

        private void EditPackageName(string packageJsonPath, string newPackageName, string oldProjectName)
        {

            string packageJsonContent = File.ReadAllText(packageJsonPath);

            string modifiedPackageJsonContent = packageJsonContent.Replace($"\"name\": \"{oldProjectName}\"", $"\"name\": \"{newPackageName}\"");

            File.WriteAllText(packageJsonPath, modifiedPackageJsonContent);
        }

        private async Task RunCmdCommand(List<string> commands, string workingDir)
        {
            try
            {

                if (commands.Count == 0)
                {
                    Console.WriteLine("No commands to run.");
                    return;
                }

                await Task.Run(() =>
                {
                    Process process = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        Verb = "runas",
                        CreateNoWindow = true,
                        WorkingDirectory = workingDir
                    };

                    process.StartInfo = startInfo;
                    process.Start();

                    foreach (var command in commands)
                    {
                        process.StandardInput.WriteLine(command);
                    }

                    process.StandardInput.Flush();
                    process.StandardInput.Close();


                    // Çıktıları oku
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    // Çalışmayı bekle
                    process.WaitForExit();

                    // Event'i tetikle, ana formdaki ListBox'a çıktıyı eklemek için
                    LogOutput?.Invoke($"\n{output}\n\n{error}");
                });



            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }


    }
}
