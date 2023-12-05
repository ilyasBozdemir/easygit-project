namespace EasyGit_Copy
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCopyProject = new Button();
            txtGithubUrl = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtProjectName = new TextBox();
            label3 = new Label();
            txtLocation = new TextBox();
            projectPath = new Label();
            browseButton = new Button();
            groupBox1 = new GroupBox();
            textBox1 = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCopyProject
            // 
            btnCopyProject.Location = new Point(304, 497);
            btnCopyProject.Name = "btnCopyProject";
            btnCopyProject.Size = new Size(99, 52);
            btnCopyProject.TabIndex = 0;
            btnCopyProject.Text = "Kopyala";
            btnCopyProject.UseVisualStyleBackColor = true;
            btnCopyProject.Click += btnCopyProject_Click;
            // 
            // txtGithubUrl
            // 
            txtGithubUrl.Location = new Point(27, 69);
            txtGithubUrl.Name = "txtGithubUrl";
            txtGithubUrl.Size = new Size(306, 23);
            txtGithubUrl.TabIndex = 0;
            txtGithubUrl.TextChanged += txtGithubUrl_TextChanged;
            txtGithubUrl.Leave += txtGithubUrl_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 41);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 2;
            label1.Text = "Github Url";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 174);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 4;
            label2.Text = "Proje Adı";
            // 
            // txtProjectName
            // 
            txtProjectName.Location = new Point(27, 202);
            txtProjectName.Name = "txtProjectName";
            txtProjectName.Size = new Size(306, 23);
            txtProjectName.TabIndex = 3;
            txtProjectName.TextChanged += txtProjectName_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 103);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 6;
            label3.Text = "Lokasyon";
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(27, 131);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(306, 23);
            txtLocation.TabIndex = 1;
            txtLocation.TextChanged += txtLocation_TextChanged;
            // 
            // projectPath
            // 
            projectPath.AutoSize = true;
            projectPath.Location = new Point(27, 250);
            projectPath.Name = "projectPath";
            projectPath.Size = new Size(91, 15);
            projectPath.TabIndex = 7;
            projectPath.Text = "[Proje Konumu]";
            // 
            // browseButton
            // 
            browseButton.BackColor = SystemColors.Control;
            browseButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            browseButton.ForeColor = Color.Black;
            browseButton.Location = new Point(352, 134);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(40, 23);
            browseButton.TabIndex = 2;
            browseButton.Text = "...";
            browseButton.UseVisualStyleBackColor = false;
            browseButton.Click += browseButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(projectPath);
            groupBox1.Controls.Add(btnCopyProject);
            groupBox1.Controls.Add(browseButton);
            groupBox1.Controls.Add(txtGithubUrl);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtProjectName);
            groupBox1.Controls.Add(txtLocation);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(424, 578);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.WindowText;
            textBox1.ForeColor = SystemColors.Control;
            textBox1.Location = new Point(27, 287);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(387, 189);
            textBox1.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(438, 639);
            Controls.Add(groupBox1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EasyGit Copy";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnCopyProject;
        private TextBox txtGithubUrl;
        private Label label1;
        private Label label2;
        private TextBox txtProjectName;
        private Label label3;
        private TextBox txtLocation;
        private Label projectPath;
        private Button browseButton;
        private GroupBox groupBox1;
        private TextBox textBox1;
    }
}