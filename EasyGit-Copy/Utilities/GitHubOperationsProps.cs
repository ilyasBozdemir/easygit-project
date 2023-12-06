using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyGit_Copy.Utilities
{
    public class GitHubOperationsProps
    {
        public string RootLocationPath { get; set; }
        public string ProjectName { get; set; }

        public string DestinationPath => $"{RootLocationPath}/{ProjectName}";

        public string RepoUrl { get; set; }

        public GitHubOperationsProps(string rootLocationPath, string projectName, string repoUrl)
        {
            this.RootLocationPath = rootLocationPath;
            this.ProjectName = projectName;
            this.RepoUrl = repoUrl;
        }

        public GitHubOperationsProps() { }
    }

}


