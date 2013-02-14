namespace BugTrackerToRedmineApp
{
    partial class FrmTransferBugs
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
            this.btnTransferSelectedBugs = new System.Windows.Forms.Button();
            this.grdBTBugs = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lstConsole = new System.Windows.Forms.ListBox();
            this.btnClearConsole = new System.Windows.Forms.Button();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdBTBugs)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTransferSelectedBugs
            // 
            this.btnTransferSelectedBugs.Location = new System.Drawing.Point(898, 310);
            this.btnTransferSelectedBugs.Name = "btnTransferSelectedBugs";
            this.btnTransferSelectedBugs.Size = new System.Drawing.Size(171, 36);
            this.btnTransferSelectedBugs.TabIndex = 12;
            this.btnTransferSelectedBugs.Text = "Transfer Selected Bugs";
            this.btnTransferSelectedBugs.UseVisualStyleBackColor = true;
            this.btnTransferSelectedBugs.Click += new System.EventHandler(this.btnTransferSelectedBugs_Click);
            // 
            // grdBTBugs
            // 
            this.grdBTBugs.AllowUserToAddRows = false;
            this.grdBTBugs.AllowUserToDeleteRows = false;
            this.grdBTBugs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBTBugs.Location = new System.Drawing.Point(9, 35);
            this.grdBTBugs.Name = "grdBTBugs";
            this.grdBTBugs.ReadOnly = true;
            this.grdBTBugs.Size = new System.Drawing.Size(1060, 269);
            this.grdBTBugs.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Bugs";
            // 
            // lstConsole
            // 
            this.lstConsole.FormattingEnabled = true;
            this.lstConsole.Items.AddRange(new object[] {
            "Console"});
            this.lstConsole.Location = new System.Drawing.Point(9, 365);
            this.lstConsole.Name = "lstConsole";
            this.lstConsole.Size = new System.Drawing.Size(1060, 264);
            this.lstConsole.TabIndex = 13;
            // 
            // btnClearConsole
            // 
            this.btnClearConsole.Location = new System.Drawing.Point(9, 328);
            this.btnClearConsole.Name = "btnClearConsole";
            this.btnClearConsole.Size = new System.Drawing.Size(126, 31);
            this.btnClearConsole.TabIndex = 14;
            this.btnClearConsole.Text = "Clear Console";
            this.btnClearConsole.UseVisualStyleBackColor = true;
            this.btnClearConsole.Click += new System.EventHandler(this.btnClearConsole_Click);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(74, 9);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(128, 17);
            this.chkSelectAll.TabIndex = 15;
            this.chkSelectAll.Text = "Select  / UnSelect All";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // FrmTransferBugs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 644);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.btnClearConsole);
            this.Controls.Add(this.lstConsole);
            this.Controls.Add(this.btnTransferSelectedBugs);
            this.Controls.Add(this.grdBTBugs);
            this.Controls.Add(this.label1);
            this.Name = "FrmTransferBugs";
            this.Text = "FrmTransferBugs";
            this.Load += new System.EventHandler(this.FrmTransferBugs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdBTBugs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTransferSelectedBugs;
        private System.Windows.Forms.DataGridView grdBTBugs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstConsole;
        private System.Windows.Forms.Button btnClearConsole;
        private System.Windows.Forms.CheckBox chkSelectAll;
    }
}