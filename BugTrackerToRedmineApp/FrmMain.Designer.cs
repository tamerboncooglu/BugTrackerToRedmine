﻿namespace BugTrackerToRedmineApp
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTransferUsers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTransferUsers
            // 
            this.btnTransferUsers.Location = new System.Drawing.Point(38, 27);
            this.btnTransferUsers.Name = "btnTransferUsers";
            this.btnTransferUsers.Size = new System.Drawing.Size(141, 41);
            this.btnTransferUsers.TabIndex = 0;
            this.btnTransferUsers.Text = "Transfer Users";
            this.btnTransferUsers.UseVisualStyleBackColor = true;
            this.btnTransferUsers.Click += new System.EventHandler(this.btnTransferUsers_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 371);
            this.Controls.Add(this.btnTransferUsers);
            this.Name = "FrmMain";
            this.Text = "BugTracker 2 Redmine";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTransferUsers;
    }
}

