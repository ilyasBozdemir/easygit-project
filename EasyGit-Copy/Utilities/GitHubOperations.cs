using System.Diagnostics;

namespace EasyGit_Copy.Utilities
{
    public class GitHubOperations
    {
        public GitHubOperations(string destinationPath,string rootLocationPath, string repoUrl, string projectName)
        {
            this.DestinationPath = destinationPath;
            this.RepoUrl = repoUrl;
            this.RootLocationPath = rootLocationPath;
            this.ProjectName = projectName;
        }
        public string DestinationPath { get; set; }
        public string RootLocationPath { get; set; }
        
        public string RepoUrl { get; set; }
        public string ProjectName { get; set; }

        public event Action<string> LogOutput;


        public void PerformGitHubOperations()
        {
           // var tempDirectoryPathInfo = CreateDirectory(DestinationPath);

            //DeleteDirectory(tempDirectoryPathInfo);
        }


        private void DeleteDirectory(DirectoryInfo directoryInfo)
        {
            if (directoryInfo.Exists)
                directoryInfo.Delete(true);
        }

        private DirectoryInfo CreateDirectory(string directoryName)
        {
           return Directory.CreateDirectory(directoryName);
        }

        private void CreateDirectoryWithCmd(string directoryName,string workingDir)
        {
            RunCmdCommand($"mkdir {directoryName}",workingDir);
        }

        private void CloneRepository(string repoUrl, string workingDir)
        {
            RunCmdCommand($"git clone {repoUrl}",  workingDir);
        }
        private void RunCmdCommand(string command,string workingDir)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false, // UseShellExecute'yi false olarak ayarla
                Verb = "runas",
                CreateNoWindow = true,
                WorkingDirectory = workingDir
            };

            process.StartInfo = startInfo;
            process.Start();

            // CMD'ye komutu yaz
            process.StandardInput.WriteLine(command);
            process.StandardInput.WriteLine(command);
            process.StandardInput.Flush();
            process.StandardInput.Close();

            // Çıktıları oku
            string output = process.StandardOutput.ReadToEnd();
       
            string error = process.StandardError.ReadToEnd();

            // Çalışmayı bekle
            process.WaitForExit();

            // Event'i tetikle, ana formdaki ListBox'a çıktıyı eklemek için
            LogOutput?.Invoke($"\n{output}\n\n{error}");

        }

        private void CopyDirectory(string sourcePath, string destinationPath)
        {
            if (!Directory.Exists(DestinationPath))
            {
                Directory.CreateDirectory(DestinationPath);
            }

            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, destinationPath));
            }

            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, destinationPath), true);
            }
        }

    }
}
