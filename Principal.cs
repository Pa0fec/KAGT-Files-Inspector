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

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void bom_comparator_Click(object sender, EventArgs e)
        {
            MainView pv = new MainView();
        }
    }
}