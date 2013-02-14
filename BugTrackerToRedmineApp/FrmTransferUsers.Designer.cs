namespace BugTrackerToRedmineApp
{
    partial class FrmTransferUsers
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
            this.label1 = new System.Windows.Forms.Label();
            this.grdBTUsers = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.grdRUsers = new System.Windows.Forms.DataGridView();
            this.btnTransferSelectedUsers = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdBTUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "BugTracker Users";
            // 
            // grdBTUsers
            // 
            this.grdBTUsers.AllowUserToAddRows = false;
            this.grdBTUsers.AllowUserToDeleteRows = false;
            this.grdBTUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBTUsers.Location = new System.Drawing.Point(9, 44);
            this.grdBTUsers.Name = "grdBTUsers";
            this.grdBTUsers.ReadOnly = true;
            this.grdBTUsers.Size = new System.Drawing.Size(785, 168);
            this.grdBTUsers.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Redmine Users";
            // 
            // grdRUsers
            // 
            this.grdRUsers.AllowUserToAddRows = false;
            this.grdRUsers.AllowUserToDeleteRows = false;
            this.grdRUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRUsers.Location = new System.Drawing.Point(9, 283);
            this.grdRUsers.Name = "grdRUsers";
            this.grdRUsers.ReadOnly = true;
            this.grdRUsers.Size = new System.Drawing.Size(785, 168);
            this.grdRUsers.TabIndex = 3;
            // 
            // btnTransferSelectedUsers
            // 
            this.btnTransferSelectedUsers.Location = new System.Drawing.Point(624, 229);
            this.btnTransferSelectedUsers.Name = "btnTransferSelectedUsers";
            this.btnTransferSelectedUsers.Size = new System.Drawing.Size(171, 36);
            this.btnTransferSelectedUsers.TabIndex = 4;
            this.btnTransferSelectedUsers.Text = "Transfer Selected Users";
            this.btnTransferSelectedUsers.UseVisualStyleBackColor = true;
            this.btnTransferSelectedUsers.Click += new System.EventHandler(this.btnTransferSelectedUsers_Click);
            // 
            // FrmTransferUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 491);
            this.Controls.Add(this.btnTransferSelectedUsers);
            this.Controls.Add(this.grdRUsers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grdBTUsers);
            this.Controls.Add(this.label1);
            this.Name = "FrmTransferUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transfer Users";
            this.Load += new System.EventHandler(this.FrmTransferUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdBTUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdBTUsers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grdRUsers;
        private System.Windows.Forms.Button btnTransferSelectedUsers;
    }
}