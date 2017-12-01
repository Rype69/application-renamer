// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainForm.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.ApplicationRenamer.UI.Windows
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// Windows form UI, main form
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Cancelled flag
        /// </summary>
        private bool cancelled;

        /// <summary>
        /// Denotes whether or not the form.load event has occurred
        /// </summary>
        private bool loaded;

        /// <summary>
        /// Indicates whether the <see cref="fromTextBox"/> is already focused.
        /// </summary>
        private bool fromTextBoxAlreadyFocused;

        /// <summary>
        /// An instance of a settings file
        /// </summary>
        private readonly ISettingsFile settingsFile;

        /// <summary>
        /// Indicates whether the <see cref="toTextBox"/> is already focused.
        /// </summary>
        private bool toTextBoxAlreadyFocused;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class. 
        /// </summary>
        public MainForm() : this(IocContainer.Resolver.Resolve<ISettingsFile>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class. 
        /// </summary>
        /// <param name="settingsFile">
        /// An instance of a settings file
        /// </param>
        public MainForm(ISettingsFile settingsFile)
        {
            if (settingsFile == null)
            {
                throw new ArgumentNullException(nameof(settingsFile));
            }

            this.settingsFile = settingsFile;

            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the cancelled flag
        /// </summary>
        public bool Cancelled
        {
            get
            {
                return this.cancelled;
            }
            set
            {
                this.cancelled = value;
                if (value)
                {
                    this.progressBar.Value = 0;
                }
            }
        }

        /// <summary>
        /// Gets a set of directory paths
        /// </summary>
        private IList<string> DirectoryPaths => Utilities.IO.Directory.GetDirectories(this.rootDirectoryTextBox.Text);

        /// <summary>
        /// Gets a set of file paths
        /// </summary>
        private IList<string> FilePaths => Utilities.IO.Directory.GetFiles(this.rootDirectoryTextBox.Text);

        /// <summary>
        /// Occurs when the <see cref="browseButton"/> control is clicked.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An <see cref="EventArgs" /> object that contains the event data. </param>
        public void BrowseButton_Click(object sender, EventArgs e)
        {
            var result = this.folderBrowserDialog1.ShowDialog();
            if ((result == DialogResult.OK))
            {
                this.rootDirectoryTextBox.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        /// <summary>
        /// Occurs when the <see cref="cancelLinkLabel"/> control is clicked.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An <see cref="EventArgs" /> object that contains the event data. </param>
        private void CancelLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Cancelled = true;
        }

        /// <summary>
        /// Occurs when the <see cref="fromTextBox"/> control receives focus.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An <see cref="EventArgs" /> object that contains the event data. </param>
        private void FromTextBox_GotFocus(object sender, EventArgs e)
        {
            // Select all text only if the mouse isn't down.
            // This makes tabbing to the textbox give focus.
            if (MouseButtons != MouseButtons.None)
            {
                return;
            }

            this.fromTextBox.SelectAll();
            this.fromTextBoxAlreadyFocused = true;
        }

        /// <summary>
        /// Occurs when the mouse pointer is over the <see cref="fromTextBox"/>
        /// control and a mouse button is released.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An <see cref="EventArgs" /> object that contains the event data. </param>
        private void FromTextBox_MouseUp(object sender, MouseEventArgs e)
        {
            // Web browsers like Google Chrome select the text on mouse up.
            // They only do it if the textbox isn't already focused,
            // and if the user hasn't selected all text.
            if (this.fromTextBoxAlreadyFocused || this.fromTextBox.SelectionLength != 0)
            {
                return;
            }

            this.fromTextBoxAlreadyFocused = true;
            this.fromTextBox.SelectAll();
        }

        /// <summary>
        /// Reads the contents of the settings file, if it exists, and sets the values of the UI components
        /// </summary>
        private void LoadSettings()
        {
            // Read the contents of the settings file
            this.settingsFile.Load();

            // rootDirectoryTextBox
            this.rootDirectoryTextBox.Text = this.settingsFile.Data.RootDirectoryPath;

            // fromTextBox
            this.fromTextBox.Text = this.settingsFile.Data.FromText;

            // toTextBox
            this.toTextBox.Text = this.settingsFile.Data.ToText;

            // caseSensitiveCheckBox
            this.caseSensitiveCheckBox.Checked = this.settingsFile.Data.CaseSensitive ?? true;

            // fileNamesCheckBox
            this.fileNamesCheckBox.Checked = this.settingsFile.Data.FileNames;

            // fileContentCheckBox
            this.fileContentCheckBox.Checked = this.settingsFile.Data.FileContent;
        }

        /// <summary>
        /// Occurs before a form is displayed for the first time.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">A <see cref="EventArgs"/> containing event data</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // For some reason the size is capped to 869 x 492
            this.LoadSettings();
            this.loaded = true;
        }

        /// <summary>
        /// Attempts to open a file explorer window
        /// </summary>
        /// <param name="directoryPath">The path to open</param>
        private void OpenFileExplorerWindow(string directoryPath)
        {
            if (string.IsNullOrWhiteSpace(directoryPath))
            {
                MessageBox.Show("Please specify a directory path.");
                return;
            }

            switch (Directory.Exists(directoryPath))
            {
                case true:
                    using (var pr = new Process())
                    {
                        pr.StartInfo.FileName = "EXPLORER";
                        pr.StartInfo.Arguments = $"/n, /e, \"{directoryPath}\"";
                        pr.Start();
                    }

                    break;
                case false:
                    MessageBox.Show($"Cannot find directory \"{directoryPath}\"");
                    break;
            }
        }

        /// <summary>
        /// Occurs when the <see cref="openRootDirectoryButton"/> control is clicked.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An <see cref="System.EventArgs" /> object that contains the event data. </param>
        private void OpenRootDirectoryButton_Click(object sender, EventArgs e)
        {
            this.OpenFileExplorerWindow(this.rootDirectoryTextBox.Text);
        }

        /// <summary>
        /// Renames files and dirs
        /// </summary>
        private void RenameObjects()
        {
            foreach (var filePath in this.FilePaths)
            {
                if (this.Cancelled)
                {
                    continue;
                }

                var fileInfo = new FileInfo(filePath);
                var newFileName = fileInfo.Name.Replace(this.fromTextBox.Text, this.toTextBox.Text);
                fileInfo.MoveTo($"{fileInfo.DirectoryName}\\{newFileName}");
            }
            foreach (var directoryPath in this.DirectoryPaths)
            {
                if (this.Cancelled)
                {
                    continue;
                }

                var directoryInfo = new DirectoryInfo(directoryPath);
                var newDirName = directoryInfo.Name.Replace(this.fromTextBox.Text, this.toTextBox.Text);
                var newDirPath = directoryInfo.Parent == null
                    ? newDirName
                    : $"{directoryInfo.Parent?.FullName}\\{newDirName}";

                if (directoryInfo.FullName != newDirPath)
                {
                    directoryInfo.MoveTo(newDirPath);
                }
            }
        }

        /// <summary>
        /// Replaces file content 
        /// </summary>
        private void ReplaceFileContent()
        {
            foreach (var fileName in this.FilePaths)
            {
                if (this.Cancelled)
                {
                    continue;
                }

                var strContents = Utilities.IO.File.Read(fileName);
                if (strContents.Contains(this.fromTextBox.Text))
                {
                    strContents = strContents.Replace(this.fromTextBox.Text, this.toTextBox.Text);
                }

                Utilities.IO.File.Delete(fileName);
                Utilities.IO.File.Write(strContents, fileName);
            }
        }

        /// <summary>
        /// Occurs when the <see cref="TextBox.Text"/> property value of the <see cref="rootDirectoryTextBox"/> changes.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An <see cref="EventArgs" /> object that contains the event data. </param>
        private void RootDirectoryTextBox_TextChanged(object sender, EventArgs e)
        {
            this.rootDirectoryTextBox.ForeColor = SystemColors.WindowText;

            if (!Directory.Exists(this.rootDirectoryTextBox.Text))
            {
                this.rootDirectoryTextBox.ForeColor = Color.Red;
            }

            this.SaveSettings(sender, e);
        }

        /// <summary>
        /// Saves the UI settings to file
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An <see cref="EventArgs" /> object that contains the event data. </param>
        public void SaveSettings(object sender, EventArgs e)
        {
            // Only save values if the form has loaded
            if (!this.loaded)
            {
                return;
            }

            // Code should be exclusive to only one thread
            lock (new object())
            {
                // rootDirectoryTextBox
                this.settingsFile.Data.RootDirectoryPath = this.rootDirectoryTextBox.Text;

                // fromTextBox
                this.settingsFile.Data.FromText = this.fromTextBox.Text;

                // toTextBox
                this.settingsFile.Data.ToText = this.toTextBox.Text;

                // caseSensitiveCheckBox
                this.settingsFile.Data.CaseSensitive = this.caseSensitiveCheckBox.Checked;

                // fileNamesCheckBox
                this.settingsFile.Data.FileNames = this.fileNamesCheckBox.Checked;

                // fileContentCheckBox
                this.settingsFile.Data.FileContent = this.fileContentCheckBox.Checked;

                // Write to file
                this.settingsFile.Save();
            }
        }

        /// <summary>
        /// Occurs when the <see cref="startButton"/> control is clicked.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An <see cref="EventArgs" /> object that contains the event data. </param>
        private void StartButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.rootDirectoryTextBox.Text))
            {
                MessageBox.Show("Please specify a root directory.");
                return;
            }

            if (!Directory.Exists(this.rootDirectoryTextBox.Text))
            {
                MessageBox.Show($"Cannot find directory \"{this.rootDirectoryTextBox.Text}\"");
                return;
            }

            if (string.IsNullOrWhiteSpace(this.fromTextBox.Text))
            {
                MessageBox.Show("Please specify a \"from\" string.");
                return;
            }

            if (string.IsNullOrWhiteSpace(this.toTextBox.Text))
            {
                MessageBox.Show("Please specify a \"to\" string.");
                return;
            }

            if (!string.IsNullOrEmpty(this.fromTextBox.Text.Trim()) && !string.IsNullOrEmpty(this.fromTextBox.Text.Trim()))
            {
                this.startButton.Enabled = false;
                this.cancelLinkLabel.Enabled = true;
                this.fileContentCheckBox.Enabled = false;
                this.fileNamesCheckBox.Enabled = false;

                if (this.fileContentCheckBox.Checked)
                {
                    this.ReplaceFileContent();
                }

                if (this.fileNamesCheckBox.Checked)
                {
                    this.RenameObjects();
                }
            }

            this.startButton.Enabled = true;
            this.cancelLinkLabel.Enabled = false;
            this.fileContentCheckBox.Enabled = true;
            this.fileNamesCheckBox.Enabled = true;
        }

        /// <summary>
        /// Occurs when the <see cref="toTextBox"/> control receives focus.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An <see cref="EventArgs" /> object that contains the event data. </param>
        private void ToTextBox_GotFocus(object sender, EventArgs e)
        {
            // Select all text only if the mouse isn't down.
            // This makes tabbing to the textbox give focus.
            if (MouseButtons != MouseButtons.None)
            {
                return;
            }

            this.toTextBox.SelectAll();
            this.toTextBoxAlreadyFocused = true;
        }

        /// <summary>
        /// Occurs when the mouse pointer is over the <see cref="toTextBox"/>
        /// control and a mouse button is released.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An <see cref="EventArgs" /> object that contains the event data. </param>
        private void ToTextBox_MouseUp(object sender, MouseEventArgs e)
        {
            // Web browsers like Google Chrome select the text on mouse up.
            // They only do it if the textbox isn't already focused,
            // and if the user hasn't selected all text.
            if (this.toTextBoxAlreadyFocused || this.toTextBox.SelectionLength != 0)
            {
                return;
            }

            this.toTextBoxAlreadyFocused = true;
            this.toTextBox.SelectAll();
        }
    }
}
