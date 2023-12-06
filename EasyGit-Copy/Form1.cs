using EasyGit_Copy.Utilities;

namespace EasyGit_Copy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string repoUrl = "",
            rootLocationPath = "",
            projectName = "",
            ghUsername = "";

        private void btnCopyProject_Click(object sender, EventArgs e)
        {
            var gitHubOperations = new GitHubOperations(new GitHubOperationsProps()
            {
                ProjectName = projectName,
                RepoUrl = repoUrl,
                RootLocationPath = rootLocationPath,
            });
            gitHubOperations.LogOutput += OnLogOutput;
            gitHubOperations.PerformGitHubOperationsAsync();
        }

        private void OnLogOutput(string log)
        {
            textBox1.Text = log + "\n";

        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Dosya Konumu Seç";
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFolder = folderBrowserDialog.SelectedPath;
                    txtLocation.Text = selectedFolder;
                }
            }
        }

        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            projectPath.Text = "Proje Konumu: ";
            projectPath.Text = Path.Combine(txtLocation.Text, projectName);
            rootLocationPath = txtLocation.Text;
        }

        private void txtProjectName_TextChanged(object sender, EventArgs e)
        {
            projectName = Slug.GenerateSlug(txtProjectName.Text);
            projectPath.Text = "Proje Konumu: ";
            projectPath.Text += Path.Combine(txtLocation.Text, projectName);

        }

        private void txtGithubUrl_TextChanged(object sender, EventArgs e)
        {
            repoUrl = txtGithubUrl.Text;
        }

        private void txtGithubUrl_Leave(object sender, EventArgs e)
        {
            if (repoUrl != null)
            {
                //ghUsername = repoUrl.Replace("https://", "").Split('/', '\\')[1];

                //  MessageBox.Show(ghUsername);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Control.CheckForIllegalCrossThreadCalls = false;
        }
    }
}


