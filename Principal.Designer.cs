namespace FilesInspector
{
    partial class Principal
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
            label2 = new Label();
            label3 = new Label();
            bom_generator = new Button();
            bom_comparator = new Button();
            program_inspect = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Gemini_Generated_Image_4smadl4smadl4sma;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(136, 130);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(193, 39);
            label1.Name = "label1";
            label1.Size = new Size(319, 42);
            label1.TabIndex = 1;
            label1.Text = "KAGT FILES INSPECTOR";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Consolas", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(226, 92);
            label2.Name = "label2";
            label2.Size = new Size(240, 18);
            label2.TabIndex = 2;
            label2.Text = "Manufacturing Validation Tool";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("HP Simplified", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(239, 171);
            label3.Name = "label3";
            label3.Size = new Size(121, 26);
            label3.TabIndex = 3;
            label3.Text = "MAIN MENU";
            // 
            // bom_generator
            // 
            bom_generator.BackColor = SystemColors.GradientActiveCaption;
            bom_generator.Cursor = Cursors.AppStarting;
            bom_generator.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bom_generator.Location = new Point(193, 226);
            bom_generator.Name = "bom_generator";
            bom_generator.Size = new Size(200, 60);
            bom_generator.TabIndex = 4;
            bom_generator.Text = "Generate KAGT BOM";
            bom_generator.UseVisualStyleBackColor = false;
            bom_generator.Click += button1_Click;
            // 
            // bom_comparator
            // 
            bom_comparator.BackColor = SystemColors.GradientActiveCaption;
            bom_comparator.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bom_comparator.Location = new Point(193, 315);
            bom_comparator.Name = "bom_comparator";
            bom_comparator.Size = new Size(200, 60);
            bom_comparator.TabIndex = 5;
            bom_comparator.Text = "BOM Comparator";
            bom_comparator.UseVisualStyleBackColor = false;
            bom_comparator.Click += bom_comparator_Click;
            // 
            // program_inspect
            // 
            program_inspect.BackColor = SystemColors.GradientActiveCaption;
            program_inspect.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            program_inspect.Location = new Point(193, 404);
            program_inspect.Name = "program_inspect";
            program_inspect.Size = new Size(200, 60);
            program_inspect.TabIndex = 6;
            program_inspect.Text = "Inspect Assembly program";
            program_inspect.UseVisualStyleBackColor = false;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(579, 512);
            Controls.Add(program_inspect);
            Controls.Add(bom_comparator);
            Controls.Add(bom_generator);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "Principal";
            Text = "Principal";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button bom_generator;
        private Button bom_comparator;
        private Button program_inspect;
    }
}