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

            var comparisonRows = CompararProgramas(datData, csvData);

            pv.Close();

            LoadComparisonResults(comparisonRows);

        }

        private List<ComparisonRow> CompararProgramas(
    List<DatRecord> dat,
    List<DatRecord> csv)
        {
            var comparisonRows = new List<ComparisonRow>();

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

            var processedKeys = new HashSet<(string Referencia, string Side)>();

            foreach (var d in datUnico)
            {
                var key = (d.Referencia, d.Side);
                processedKeys.Add(key);

                if (!csvDict.TryGetValue(key, out var csvPart))
                {
                    comparisonRows.Add(new ComparisonRow
                    {
                        Reference = d.Referencia,
                        Side = d.Side,
                        DatPartNumber = d.PartNumber,
                        CsvPartNumber = "-",
                        Status = "Missing in CSV"
                    });
                    continue;
                }

                if (!d.PartNumber.Equals(csvPart, StringComparison.OrdinalIgnoreCase))
                {
                    comparisonRows.Add(new ComparisonRow
                    {
                        Reference = d.Referencia,
                        Side = d.Side,
                        DatPartNumber = d.PartNumber,
                        CsvPartNumber = csvPart,
                        Status = "Part mismatch"
                    });
                }
                else
                {
                    comparisonRows.Add(new ComparisonRow
                    {
                        Reference = d.Referencia,
                        Side = d.Side,
                        DatPartNumber = d.PartNumber,
                        CsvPartNumber = csvPart,
                        Status = "Match"
                    });
                }
            }

            foreach (var c in csvDict)
            {
                if (processedKeys.Contains(c.Key))
                {
                    continue;
                }

                comparisonRows.Add(new ComparisonRow
                {
                    Reference = c.Key.Referencia,
                    Side = c.Key.Side,
                    DatPartNumber = "-",
                    CsvPartNumber = c.Value,
                    Status = "Missing in DAT"
                });
            }

            return comparisonRows
                .OrderBy(r => r.Status == "Match")
                .ThenBy(r => r.Reference)
                .ThenBy(r => r.Side)
                .ToList();
        }

        private void LoadComparisonResults(List<ComparisonRow> results)
        {
            dgvComparisonResults.AutoGenerateColumns = false;
            dgvComparisonResults.DataSource = new BindingList<ComparisonRow>(results);

            int total = results.Count;
            int differences = results.Count(r => !string.Equals(r.Status, "Match", StringComparison.OrdinalIgnoreCase));
            int matches = total - differences;

            lblResultsSummary.Text =
                $"Total references: {total}   |   Matches: {matches}   |   Differences: {differences}";

            lblResultsSummary.ForeColor = differences == 0
                ? Color.FromArgb(0, 120, 0)
                : Color.FromArgb(170, 60, 0);

            if (differences == 0)
            {
                MessageBox.Show("Inspection completed successfully. No differences found.", "Inspection Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
