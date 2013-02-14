namespace BugTrackerToRedmineApp
{
    partial class FrmTransferStatuses
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
            this.btnTransferSelectedStatuses = new System.Windows.Forms.Button();
            this.grdRStatuses = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.grdBTStatuses = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdRStatuses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBTStatuses)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTransferSelectedStatuses
            // 
            this.btnTransferSelectedStatuses.Location = new System.Drawing.Point(627, 224);
            this.btnTransferSelectedStatuses.Name = "btnTransferSelectedStatuses";
            this.btnTransferSelectedStatuses.Size = new System.Drawing.Size(171, 36);
            this.btnTransferSelectedStatuses.TabIndex = 9;
            this.btnTransferSelectedStatuses.Text = "Transfer Selected Statuses";
            this.btnTransferSelectedStatuses.UseVisualStyleBackColor = true;
            this.btnTransferSelectedStatuses.Click += new System.EventHandler(this.btnTransferSelectedStatuses_Click);
            // 
            // grdRStatuses
            // 
            this.grdRStatuses.AllowUserToAddRows = false;
            this.grdRStatuses.AllowUserToDeleteRows = false;
            this.grdRStatuses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRStatuses.Location = new System.Drawing.Point(12, 278);
            this.grdRStatuses.Name = "grdRStatuses";
            this.grdRStatuses.ReadOnly = true;
            this.grdRStatuses.Size = new System.Drawing.Size(785, 168);
            this.grdRStatuses.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Redmine Statuses";
            // 
            // grdBTStatuses
            // 
            this.grdBTStatuses.AllowUserToAddRows = false;
            this.grdBTStatuses.AllowUserToDeleteRows = false;
            this.grdBTStatuses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBTStatuses.Location = new System.Drawing.Point(12, 39);
            this.grdBTStatuses.Name = "grdBTStatuses";
            this.grdBTStatuses.ReadOnly = true;
            this.grdBTStatuses.Size = new System.Drawing.Size(785, 168);
            this.grdBTStatuses.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "BugTracker Statuses";
            // 
            // FrmTransferStatuses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 457);
            this.Controls.Add(this.btnTransferSelectedStatuses);
            this.Controls.Add(this.grdRStatuses);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grdBTStatuses);
            this.Controls.Add(this.label1);
            this.Name = "FrmTransferStatuses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transfer Statuses";
            this.Load += new System.EventHandler(this.FrmTransferStatuses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdRStatuses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBTStatuses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTransferSelectedStatuses;
        private System.Windows.Forms.DataGridView grdRStatuses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grdBTStatuses;
        private System.Windows.Forms.Label label1;
    }
}