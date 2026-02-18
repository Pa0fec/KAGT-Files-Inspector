namespace FilesInspector
{
    partial class Program_Inspect
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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label4 = new Label();
            label2 = new Label();
            txtDatFile = new TextBox();
            btnSelectDat = new Button();
            label3 = new Label();
            txttopfile = new TextBox();
            btnSelectTop = new Button();
            label5 = new Label();
            txtbotfile = new TextBox();
            btnSelectBot = new Button();
            btnInspectFiles = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Gemini_Generated_Image_4smadl4smadl4sma;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(143, 124);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlLightLight;
            label1.Font = new Font("Impact", 24F);
            label1.Location = new Point(227, 33);
            label1.Name = "label1";
            label1.Size = new Size(370, 48);
            label1.TabIndex = 3;
            label1.Text = "NPM Program Inspect";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Consolas", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.Location = new Point(277, 93);
            label4.Name = "label4";
            label4.Size = new Size(240, 18);
            label4.TabIndex = 12;
            label4.Text = "Manufacturing Validation Tool";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(74, 183);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 15;
            label2.Text = ".DAT File:";
            // 
            // txtDatFile
            // 
            txtDatFile.BackColor = SystemColors.Info;
            txtDatFile.Location = new Point(197, 180);
            txtDatFile.Name = "txtDatFile";
            txtDatFile.Size = new Size(400, 27);
            txtDatFile.TabIndex = 14;
            // 
            // btnSelectDat
            // 
            btnSelectDat.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSelectDat.Location = new Point(643, 177);
            btnSelectDat.Name = "btnSelectDat";
            btnSelectDat.Size = new Size(95, 30);
            btnSelectDat.TabIndex = 13;
            btnSelectDat.Text = "Browse";
            btnSelectDat.UseVisualStyleBackColor = true;
            btnSelectDat.Click += btnSelectDat_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(74, 259);
            label3.Name = "label3";
            label3.Size = new Size(90, 20);
            label3.TabIndex = 18;
            label3.Text = "TOP File:";
            // 
            // txttopfile
            // 
            txttopfile.BackColor = SystemColors.Info;
            txttopfile.Location = new Point(197, 256);
            txttopfile.Name = "txttopfile";
            txttopfile.Size = new Size(400, 27);
            txttopfile.TabIndex = 17;
            // 
            // btnSelectTop
            // 
            btnSelectTop.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSelectTop.Location = new Point(643, 253);
            btnSelectTop.Name = "btnSelectTop";
            btnSelectTop.Size = new Size(95, 30);
            btnSelectTop.TabIndex = 16;
            btnSelectTop.Text = "Browse";
            btnSelectTop.UseVisualStyleBackColor = true;
            btnSelectTop.Click += btnSelectTop_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(74, 327);
            label5.Name = "label5";
            label5.Size = new Size(90, 20);
            label5.TabIndex = 21;
            label5.Text = "BOT File:";
            // 
            // txtbotfile
            // 
            txtbotfile.BackColor = SystemColors.Info;
            txtbotfile.Location = new Point(197, 324);
            txtbotfile.Name = "txtbotfile";
            txtbotfile.Size = new Size(400, 27);
            txtbotfile.TabIndex = 20;
            // 
            // btnSelectBot
            // 
            btnSelectBot.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSelectBot.Location = new Point(643, 321);
            btnSelectBot.Name = "btnSelectBot";
            btnSelectBot.Size = new Size(95, 30);
            btnSelectBot.TabIndex = 19;
            btnSelectBot.Text = "Browse";
            btnSelectBot.UseVisualStyleBackColor = true;
            btnSelectBot.Click += btnSelectBot_Click;
            // 
            // btnInspectFiles
            // 
            btnInspectFiles.BackColor = Color.Green;
            btnInspectFiles.Font = new Font("Consolas", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInspectFiles.ForeColor = SystemColors.ButtonHighlight;
            btnInspectFiles.Location = new Point(286, 396);
            btnInspectFiles.Name = "btnInspectFiles";
            btnInspectFiles.Size = new Size(220, 59);
            btnInspectFiles.TabIndex = 22;
            btnInspectFiles.Text = " Inspect Programs";
            btnInspectFiles.UseVisualStyleBackColor = false;
            btnInspectFiles.Click += btnInspectFiles_Click;
            // 
            // Program_Inspect
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(800, 483);
            Controls.Add(btnInspectFiles);
            Controls.Add(label5);
            Controls.Add(txtbotfile);
            Controls.Add(btnSelectBot);
            Controls.Add(label3);
            Controls.Add(txttopfile);
            Controls.Add(btnSelectTop);
            Controls.Add(label2);
            Controls.Add(txtDatFile);
            Controls.Add(btnSelectDat);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "Program_Inspect";
            Text = "Program_Inspect";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label4;
        private Label label2;
        private TextBox txtDatFile;
        private Button btnSelectDat;
        private Label label3;
        private TextBox txttopfile;
        private Button btnSelectTop;
        private Label label5;
        private TextBox txtbotfile;
        private Button btnSelectBot;
        private Button btnInspectFiles;
    }
}