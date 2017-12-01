// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainForm.Designer.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.ApplicationRenamer.UI.Windows
{
    /// <summary>
    /// Windows form UI, main form
    /// </summary>
    public partial class MainForm
    {
        /// <summary>
        /// Browse button
        /// </summary>
        private System.Windows.Forms.Button browseButton;

        /// <summary>
        /// Cancel link label
        /// </summary>
        private System.Windows.Forms.LinkLabel cancelLinkLabel;

        /// <summary>
        /// Case sensitive checkbox
        /// </summary>
        private System.Windows.Forms.CheckBox caseSensitiveCheckBox;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// File contents checkbox
        /// </summary>
        private System.Windows.Forms.CheckBox fileContentCheckBox;

        /// <summary>
        /// File names checkbox
        /// </summary>
        private System.Windows.Forms.CheckBox fileNamesCheckBox;

        /// <summary>
        /// Directory browser dialog
        /// </summary>
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;

        /// <summary>
        /// "from" label
        /// </summary>
        private System.Windows.Forms.Label fromLabel;

        /// <summary>
        /// "from" textbox
        /// </summary>
        private System.Windows.Forms.TextBox fromTextBox;

        /// <summary>
        /// An "Open directory" button
        /// </summary>
        private System.Windows.Forms.Button openRootDirectoryButton;

        /// <summary>
        /// Progress bar
        /// </summary>
        private System.Windows.Forms.ProgressBar progressBar;

        /// <summary>
        /// Root directory label
        /// </summary>
        private System.Windows.Forms.Label rootDirectoryLabel;

        /// <summary>
        /// Root directory TextBox
        /// </summary>
        private System.Windows.Forms.TextBox rootDirectoryTextBox;

        /// <summary>
        /// Start button
        /// </summary>
        private System.Windows.Forms.Button startButton;

        /// <summary>
        /// "to" label
        /// </summary>
        private System.Windows.Forms.Label toLabel;

        /// <summary>
        /// "to" textbox
        /// </summary>
        private System.Windows.Forms.TextBox toTextBox;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.browseButton = new System.Windows.Forms.Button();
            this.rootDirectoryLabel = new System.Windows.Forms.Label();
            this.rootDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.toLabel = new System.Windows.Forms.Label();
            this.fromLabel = new System.Windows.Forms.Label();
            this.fileContentCheckBox = new System.Windows.Forms.CheckBox();
            this.fileNamesCheckBox = new System.Windows.Forms.CheckBox();
            this.caseSensitiveCheckBox = new System.Windows.Forms.CheckBox();
            this.toTextBox = new System.Windows.Forms.TextBox();
            this.fromTextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cancelLinkLabel = new System.Windows.Forms.LinkLabel();
            this.openRootDirectoryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(314, 23);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(35, 23);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // rootDirectoryLabel
            // 
            this.rootDirectoryLabel.AutoSize = true;
            this.rootDirectoryLabel.Location = new System.Drawing.Point(12, 9);
            this.rootDirectoryLabel.Name = "rootDirectoryLabel";
            this.rootDirectoryLabel.Size = new System.Drawing.Size(75, 13);
            this.rootDirectoryLabel.TabIndex = 0;
            this.rootDirectoryLabel.Text = "Root Directory";
            // 
            // rootDirectoryTextBox
            // 
            this.rootDirectoryTextBox.BackColor = System.Drawing.Color.White;
            this.rootDirectoryTextBox.Location = new System.Drawing.Point(12, 25);
            this.rootDirectoryTextBox.Name = "rootDirectoryTextBox";
            this.rootDirectoryTextBox.ReadOnly = true;
            this.rootDirectoryTextBox.Size = new System.Drawing.Size(296, 20);
            this.rootDirectoryTextBox.TabIndex = 1;
            this.rootDirectoryTextBox.TextChanged += new System.EventHandler(this.RootDirectoryTextBox_TextChanged);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 152);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(393, 34);
            this.progressBar.TabIndex = 11;
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Location = new System.Drawing.Point(12, 87);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(20, 13);
            this.toLabel.TabIndex = 6;
            this.toLabel.Text = "To";
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Location = new System.Drawing.Point(12, 48);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(30, 13);
            this.fromLabel.TabIndex = 4;
            this.fromLabel.Text = "From";
            // 
            // fileContentCheckBox
            // 
            this.fileContentCheckBox.AutoSize = true;
            this.fileContentCheckBox.Checked = true;
            this.fileContentCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fileContentCheckBox.Location = new System.Drawing.Point(323, 129);
            this.fileContentCheckBox.MaximumSize = new System.Drawing.Size(82, 17);
            this.fileContentCheckBox.MinimumSize = new System.Drawing.Size(82, 17);
            this.fileContentCheckBox.Name = "fileContentCheckBox";
            this.fileContentCheckBox.Size = new System.Drawing.Size(82, 17);
            this.fileContentCheckBox.TabIndex = 10;
            this.fileContentCheckBox.Text = "File Content";
            this.fileContentCheckBox.UseVisualStyleBackColor = true;
            this.fileContentCheckBox.CheckedChanged += new System.EventHandler(this.SaveSettings);
            // 
            // fileNamesCheckBox
            // 
            this.fileNamesCheckBox.AutoSize = true;
            this.fileNamesCheckBox.Checked = true;
            this.fileNamesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fileNamesCheckBox.Location = new System.Drawing.Point(239, 129);
            this.fileNamesCheckBox.Name = "fileNamesCheckBox";
            this.fileNamesCheckBox.Size = new System.Drawing.Size(78, 17);
            this.fileNamesCheckBox.TabIndex = 9;
            this.fileNamesCheckBox.Text = "File Names";
            this.fileNamesCheckBox.UseVisualStyleBackColor = true;
            this.fileNamesCheckBox.CheckedChanged += new System.EventHandler(this.SaveSettings);
            // 
            // caseSensitiveCheckBox
            // 
            this.caseSensitiveCheckBox.AutoSize = true;
            this.caseSensitiveCheckBox.Checked = true;
            this.caseSensitiveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.caseSensitiveCheckBox.Enabled = false;
            this.caseSensitiveCheckBox.Location = new System.Drawing.Point(12, 129);
            this.caseSensitiveCheckBox.Name = "caseSensitiveCheckBox";
            this.caseSensitiveCheckBox.Size = new System.Drawing.Size(96, 17);
            this.caseSensitiveCheckBox.TabIndex = 8;
            this.caseSensitiveCheckBox.Text = "Case Sensitive";
            this.caseSensitiveCheckBox.UseVisualStyleBackColor = true;
            this.caseSensitiveCheckBox.CheckedChanged += new System.EventHandler(this.SaveSettings);
            // 
            // toTextBox
            // 
            this.toTextBox.Location = new System.Drawing.Point(12, 103);
            this.toTextBox.Name = "toTextBox";
            this.toTextBox.Size = new System.Drawing.Size(393, 20);
            this.toTextBox.TabIndex = 7;
            this.toTextBox.Text = "TO";
            this.toTextBox.TextChanged += new System.EventHandler(this.SaveSettings);
            this.toTextBox.GotFocus += new System.EventHandler(this.ToTextBox_GotFocus);
            this.toTextBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ToTextBox_MouseUp);
            // 
            // fromTextBox
            // 
            this.fromTextBox.Location = new System.Drawing.Point(12, 64);
            this.fromTextBox.Name = "fromTextBox";
            this.fromTextBox.Size = new System.Drawing.Size(393, 20);
            this.fromTextBox.TabIndex = 5;
            this.fromTextBox.Text = "FROM";
            this.fromTextBox.TextChanged += new System.EventHandler(this.SaveSettings);
            this.fromTextBox.GotFocus += new System.EventHandler(this.FromTextBox_GotFocus);
            this.fromTextBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FromTextBox_MouseUp);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 188);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(393, 31);
            this.startButton.TabIndex = 12;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // cancelLinkLabel
            // 
            this.cancelLinkLabel.AutoSize = true;
            this.cancelLinkLabel.Enabled = false;
            this.cancelLinkLabel.Location = new System.Drawing.Point(365, 222);
            this.cancelLinkLabel.Name = "cancelLinkLabel";
            this.cancelLinkLabel.Size = new System.Drawing.Size(40, 13);
            this.cancelLinkLabel.TabIndex = 13;
            this.cancelLinkLabel.TabStop = true;
            this.cancelLinkLabel.Text = "Cancel";
            this.cancelLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CancelLinkLabel_LinkClicked);
            // 
            // openRootDirectoryButton
            // 
            this.openRootDirectoryButton.Location = new System.Drawing.Point(355, 23);
            this.openRootDirectoryButton.Name = "openRootDirectoryButton";
            this.openRootDirectoryButton.Size = new System.Drawing.Size(50, 23);
            this.openRootDirectoryButton.TabIndex = 3;
            this.openRootDirectoryButton.Text = "Open";
            this.openRootDirectoryButton.UseVisualStyleBackColor = true;
            this.openRootDirectoryButton.Click += new System.EventHandler(this.OpenRootDirectoryButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 242);
            this.Controls.Add(this.openRootDirectoryButton);
            this.Controls.Add(this.cancelLinkLabel);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.rootDirectoryLabel);
            this.Controls.Add(this.rootDirectoryTextBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.toLabel);
            this.Controls.Add(this.fromLabel);
            this.Controls.Add(this.fileContentCheckBox);
            this.Controls.Add(this.fileNamesCheckBox);
            this.Controls.Add(this.caseSensitiveCheckBox);
            this.Controls.Add(this.toTextBox);
            this.Controls.Add(this.fromTextBox);
            this.Controls.Add(this.startButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(433, 281);
            this.MinimumSize = new System.Drawing.Size(433, 281);
            this.Name = "MainForm";
            this.Text = "Application Renamer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
