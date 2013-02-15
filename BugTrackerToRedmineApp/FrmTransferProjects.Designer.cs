namespace BugTrackerToRedmineApp
{
    partial class FrmTransferProjects
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
            this.btnTransferSelectedProjects = new System.Windows.Forms.Button();
            this.grdRProjects = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.grdBTProjects = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdRProjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBTProjects)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTransferSelectedProjects
            // 
            this.btnTransferSelectedProjects.Location = new System.Drawing.Point(621, 246);
            this.btnTransferSelectedProjects.Name = "btnTransferSelectedProjects";
            this.btnTransferSelectedProjects.Size = new System.Drawing.Size(171, 36);
            this.btnTransferSelectedProjects.TabIndex = 14;
            this.btnTransferSelectedProjects.Text = "Transfer Selected Projects";
            this.btnTransferSelectedProjects.UseVisualStyleBackColor = true;
            this.btnTransferSelectedProjects.Click += new System.EventHandler(this.btnTransferSelectedProjects_Click);
            // 
            // grdRProjects
            // 
            this.grdRProjects.AllowUserToAddRows = false;
            this.grdRProjects.AllowUserToDeleteRows = false;
            this.grdRProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRProjects.Location = new System.Drawing.Point(6, 300);
            this.grdRProjects.Name = "grdRProjects";
            this.grdRProjects.ReadOnly = true;
            this.grdRProjects.Size = new System.Drawing.Size(785, 168);
            this.grdRProjects.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Redmine Proejcts";
            // 
            // grdBTProjects
            // 
            this.grdBTProjects.AllowUserToAddRows = false;
            this.grdBTProjects.AllowUserToDeleteRows = false;
            this.grdBTProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBTProjects.Location = new System.Drawing.Point(6, 61);
            this.grdBTProjects.Name = "grdBTProjects";
            this.grdBTProjects.ReadOnly = true;
            this.grdBTProjects.Size = new System.Drawing.Size(785, 168);
            this.grdBTProjects.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "BugTracker Projects";
            // 
            // FrmTransferProjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 478);
            this.Controls.Add(this.btnTransferSelectedProjects);
            this.Controls.Add(this.grdRProjects);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grdBTProjects);
            this.Controls.Add(this.label1);
            this.Name = "FrmTransferProjects";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transfer Projects";
            this.Load += new System.EventHandler(this.FrmTransferProjects_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdRProjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBTProjects)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTransferSelectedProjects;
        private System.Windows.Forms.DataGridView grdRProjects;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grdBTProjects;
        private System.Windows.Forms.Label label1;
    }
}