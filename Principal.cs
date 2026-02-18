using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FilesInspector
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void bom_comparator_Click(object sender, EventArgs e)
        {
            OpenForm(new MainView());
        }

        private void zlist_validation_Click(object sender, EventArgs e)
        {
            OpenForm(new Zlist_Validate());
        }

        private void program_inspect_Click(object sender, EventArgs e)
        {
            OpenForm(new Program_Inspect());
        }

        private void OpenForm(Form form)
        {
            form.FormClosed += (s, args) =>
            {
                this.Show();
            };

            form.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}