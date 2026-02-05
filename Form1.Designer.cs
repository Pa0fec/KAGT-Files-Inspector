namespace FilesInspector
{
    partial class MainView
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
            btnSelectDat = new Button();
            btnSelectBom = new Button();
            label1 = new Label();
            txtDatFile = new TextBox();
            txtBomFile = new TextBox();
            label2 = new Label();
            label3 = new Label();
            btnInspectFiles = new Button();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnSelectDat
            // 
            btnSelectDat.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSelectDat.Location = new Point(713, 174);
            btnSelectDat.Name = "btnSelectDat";
            btnSelectDat.Size = new Size(95, 30);
            btnSelectDat.TabIndex = 0;
            btnSelectDat.Text = "Browse";
            btnSelectDat.UseVisualStyleBackColor = true;
            btnSelectDat.Click += btnSelectDat_Click;
            // 
            // btnSelectBom
            // 
            btnSelectBom.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSelectBom.Location = new Point(713, 254);
            btnSelectBom.Name = "btnSelectBom";
            btnSelectBom.Size = new Size(95, 30);
            btnSelectBom.TabIndex = 1;
            btnSelectBom.Text = "Browse";
            btnSelectBom.UseVisualStyleBackColor = true;
            btnSelectBom.Click += btnSelectBom_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlLightLight;
            label1.Font = new Font("Impact", 24F);
            label1.Location = new Point(237, 35);
            label1.Name = "label1";
            label1.Size = new Size(461, 48);
            label1.TabIndex = 2;
            label1.Text = "KAGT DAT–BOM Comparator";
            // 
            // txtDatFile
            // 
            txtDatFile.BackColor = SystemColors.Info;
            txtDatFile.Location = new Point(267, 177);
            txtDatFile.Name = "txtDatFile";
            txtDatFile.Size = new Size(400, 27);
            txtDatFile.TabIndex = 4;
            // 
            // txtBomFile
            // 
            txtBomFile.BackColor = SystemColors.Info;
            txtBomFile.Location = new Point(267, 257);
            txtBomFile.Name = "txtBomFile";
            txtBomFile.Size = new Size(400, 27);
            txtBomFile.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(144, 180);
            label2.Name = "label2";
            label2.Size = new Size(90, 20);
            label2.TabIndex = 7;
            label2.Text = "DAT File:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(144, 260);
            label3.Name = "label3";
            label3.Size = new Size(90, 20);
            label3.TabIndex = 8;
            label3.Text = "BOM File:";
            // 
            // btnInspectFiles
            // 
            btnInspectFiles.BackColor = Color.Green;
            btnInspectFiles.Font = new Font("Consolas", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInspectFiles.ForeColor = SystemColors.ButtonHighlight;
            btnInspectFiles.Location = new Point(357, 356);
            btnInspectFiles.Name = "btnInspectFiles";
            btnInspectFiles.Size = new Size(220, 59);
            btnInspectFiles.TabIndex = 10;
            btnInspectFiles.Text = " Inspect and Compare";
            btnInspectFiles.UseVisualStyleBackColor = false;
            btnInspectFiles.Click += btnInspectFiles_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Consolas", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.Location = new Point(347, 94);
            label4.Name = "label4";
            label4.Size = new Size(240, 18);
            label4.TabIndex = 11;
            label4.Text = "Manufacturing Validation Tool";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Gemini_Generated_Image_4smadl4smadl4sma;
            pictureBox1.Location = new Point(27, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(172, 142);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(934, 453);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(btnInspectFiles);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtBomFile);
            Controls.Add(txtDatFile);
            Controls.Add(label1);
            Controls.Add(btnSelectBom);
            Controls.Add(btnSelectDat);
            Name = "MainView";
            Text = "KAGT Files Inspector";
            Load += MainView_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSelectDat;
        private Button btnSelectBom;
        private Label label1;
        private TextBox txtDatFile;
        private TextBox txtBomFile;
        private Label label2;
        private Label label3;
        private Button btnInspectFiles;
        private Label label4;
        private PictureBox pictureBox1;
    }
}
