namespace FilesInspector
{
    partial class ProgressView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            tittle = new Label();
            progressBar1 = new ProgressBar();
            lblStatus = new Label();
            btnSeeResults = new Button();
            SuspendLayout();
            // 
            // tittle
            // 
            tittle.AutoSize = true;
            tittle.Font = new Font("Impact", 24F);
            tittle.Location = new Point(103, 46);
            tittle.Name = "tittle";
            tittle.Size = new Size(461, 48);
            tittle.TabIndex = 0;
            tittle.Text = "KAGT DAT–BOM Comparator";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(76, 227);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(514, 29);
            progressBar1.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(266, 175);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(135, 20);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Preparing analysis...";
            lblStatus.Click += lblStatus_Click;
            // 
            // btnSeeResults
            // 
            btnSeeResults.BackColor = Color.Green;
            btnSeeResults.Enabled = false;
            btnSeeResults.Font = new Font("Consolas", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSeeResults.ForeColor = SystemColors.Control;
            btnSeeResults.Location = new Point(242, 321);
            btnSeeResults.Name = "btnSeeResults";
            btnSeeResults.Size = new Size(182, 64);
            btnSeeResults.TabIndex = 3;
            btnSeeResults.Text = "View Inspection Results";
            btnSeeResults.UseVisualStyleBackColor = false;
            btnSeeResults.UseWaitCursor = true;
            btnSeeResults.Visible = false;
            btnSeeResults.Click += btnSeeResults_Click;
            // 
            // ProgressView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(663, 434);
            Controls.Add(btnSeeResults);
            Controls.Add(lblStatus);
            Controls.Add(progressBar1);
            Controls.Add(tittle);
            Name = "ProgressView";
            Text = "KAGT Files Inspector";
            Load += ProgressView_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label tittle;
        private ProgressBar progressBar1;
        private Label lblStatus;
        private Button btnSeeResults;
    }
}
