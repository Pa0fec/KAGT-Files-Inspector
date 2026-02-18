using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace FilesInspector
{
    public partial class Program_Inspect : Form
    {
        public Program_Inspect()
        {
            InitializeComponent();
        }

        private void btnSelectDat_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "DAT files (*.dat)|*.dat|All files (*.*)|*.*";
                ofd.Title = "Please Select the .DAT file";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtDatFile.Text = ofd.FileName;
                }
            }
        }

        private void btnSelectTop_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                ofd.Title = "Please Select the .CSV file";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txttopfile.Text = ofd.FileName;
                }
            }
        }

        private void btnSelectBot_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                ofd.Title = "Please Select the .CSV file";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtbotfile.Text = ofd.FileName;
                }
            }
        }

        private void btnInspectFiles_Click(object sender, EventArgs e)
        {
            string datPath = txtDatFile.Text;
            string topPath = txttopfile.Text;
            string botPath = txtbotfile.Text;

            if (!File.Exists(datPath))
            {
                MessageBox.Show("Select the DAT file");
                return;
            }

            if (!File.Exists(topPath))
            {
                MessageBox.Show("Select the TOP file(.csv)");
                return;
            }

            if (!File.Exists(botPath))
            {
                MessageBox.Show("Select the BOT file(.csv)");
                return;
            }

            ProgressView pv = new ProgressView();
            pv.Show();
            pv.UpdateProgress(0, "Reading files...");

            var datData = DatParser.ProcesarDat(datPath);

            var topData = CsvParser.ProcesarCsv(topPath, "SMT_SA");
            var botData = CsvParser.ProcesarCsv(botPath, "SMT_SB");

            var csvData = topData.Concat(botData).ToList();

            var diferencias = CompararProgramas(datData, csvData);

            pv.Close();

            if (diferencias.Count == 0)
            {
                MessageBox.Show("No differences found.");
            }
            else
            {
                MessageBox.Show(string.Join(Environment.NewLine, diferencias));
            }

        }

        private List<string> CompararProgramas(
    List<DatRecord> dat,
    List<DatRecord> csv)
        {
            var diferencias = new List<string>();

            // 🔹 Quitar duplicados en DAT
            var datUnico = dat
                .GroupBy(x => (x.Referencia, x.Side))
                .Select(g => g.First())
                .ToList();

            // 🔹 Quitar duplicados en CSV
            var csvDict = csv
                .GroupBy(x => (x.Referencia, x.Side))
                .ToDictionary(
                    g => g.Key,
                    g => g.First().PartNumber
                );

            foreach (var d in datUnico)
            {
                if (!csvDict.TryGetValue((d.Referencia, d.Side), out var csvPart))
                {
                    diferencias.Add($"Missing in CSV: {d.Referencia} ({d.Side})");
                    continue;
                }

                if (!d.PartNumber.Equals(csvPart, StringComparison.OrdinalIgnoreCase))
                {
                    diferencias.Add(
                        $"Part mismatch: {d.Referencia} - DAT:{d.PartNumber} CSV:{csvPart}"
                    );
                }
            }

            return diferencias;
        }
    }
}
