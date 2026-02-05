using System;
using System.Windows.Forms;

namespace FilesInspector
{
    public partial class ProgressView : Form
    {
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(
     System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public ComparisonResult Result { get; set; }


        public ProgressView()
        {
            InitializeComponent();
        }

        private void ProgressView_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            lblStatus.Text = "Preparing analysis...";
        }

        // ====================================================
        //  MÉTODO PARA ACTUALIZAR PROGRESO (Thread-Safe)
        // ====================================================
        public void UpdateProgress(int percent, string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateProgress(percent, message)));
                return;
            }

            if (percent < 0) percent = 0;
            if (percent > 100) percent = 100;

            progressBar1.Value = percent;
            lblStatus.Text = message;

            if (percent == 100)
            {
                lblStatus.Text = "Analysis completed";
                btnSeeResults.Visible = true;
                btnSeeResults.Enabled = true;
            }
        }

        private void btnSeeResults_Click(object sender, EventArgs e)
        {
            ResultsView rv = new ResultsView(Result);
            rv.Show();
            Close();
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }
    }
}
