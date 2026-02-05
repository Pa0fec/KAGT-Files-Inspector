namespace FilesInspector
{
    partial class ResultsView
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
            lblSummary = new Label();
            btnExportResults = new Button();
            btnExportDifferences = new Button();
            SuspendLayout();
            // 
            // lblSummary
            // 
            lblSummary.Font = new Font("Consolas", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSummary.Location = new Point(47, 66);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(403, 27);
            lblSummary.TabIndex = 0;
            lblSummary.Text = "No discrepancies were found.";
            lblSummary.Click += lblSummary_Click;
            // 
            // btnExportResults
            // 
            btnExportResults.BackColor = Color.Green;
            btnExportResults.Font = new Font("Consolas", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExportResults.ForeColor = SystemColors.Control;
            btnExportResults.Location = new Point(147, 134);
            btnExportResults.Name = "btnExportResults";
            btnExportResults.Size = new Size(202, 61);
            btnExportResults.TabIndex = 1;
            btnExportResults.Text = "Export Full Validation Report";
            btnExportResults.UseVisualStyleBackColor = false;
            btnExportResults.Click += btnExportResults_Click;
            // 
            // btnExportDifferences
            // 
            btnExportDifferences.BackColor = Color.DarkRed;
            btnExportDifferences.Font = new Font("Consolas", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExportDifferences.ForeColor = SystemColors.Control;
            btnExportDifferences.Location = new Point(147, 236);
            btnExportDifferences.Name = "btnExportDifferences";
            btnExportDifferences.Size = new Size(202, 58);
            btnExportDifferences.TabIndex = 2;
            btnExportDifferences.Text = "Export Differences Report";
            btnExportDifferences.UseVisualStyleBackColor = false;
            btnExportDifferences.Visible = false;
            btnExportDifferences.Click += btnExportDifferences_Click;
            // 
            // ResultsView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(497, 357);
            Controls.Add(btnExportDifferences);
            Controls.Add(btnExportResults);
            Controls.Add(lblSummary);
            Name = "ResultsView";
            Text = "ResultsView";
            Load += ResultsView_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label lblSummary;
        private Button btnExportResults;
        private Button btnExportDifferences;
    }
}