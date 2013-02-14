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
            ((System.ComponentModel.ISupportInitialize)(this.grdBTUsers)).BeginInit();
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
            // FrmTransferUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 491);
            this.Controls.Add(this.grdBTUsers);
            this.Controls.Add(this.label1);
            this.Name = "FrmTransferUsers";
            this.Text = "Transfer Users";
            this.Load += new System.EventHandler(this.FrmTransferUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdBTUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdBTUsers;
    }
}