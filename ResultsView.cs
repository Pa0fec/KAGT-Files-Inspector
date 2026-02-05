using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FilesInspector
{
    public partial class ResultsView : Form
    {
        private readonly ComparisonResult _result;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ComparisonResult Result { get; set; }

        public ResultsView(ComparisonResult result)
        {
            InitializeComponent();
            _result = result;
        }

        private void lblSummary_Click(object sender, EventArgs e)
        {

        }

        private void ResultsView_Load(object sender, EventArgs e)
        {
            if (!_result.HasDifferences)
            {
                lblSummary.Text = "No differences were found between DAT and BOM";
                btnExportDifferences.Visible = false;
            }
            else
            {
                lblSummary.Text =
                    $"{_result.DifferencesCount} differences were found of {_result.TotalReferences} references";

                btnExportDifferences.Visible = true;
                btnExportDifferences.Enabled = true;
            }
        }


        private void ExportarResultadosExcel(
            string ruta,
            List<ReferenceResult> datos
        )
        {
            using (var wb = new ClosedXML.Excel.XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Comparison");

                // Encabezados
                ws.Cell(1, 1).Value = "Referencia";
                ws.Cell(1, 2).Value = "DAT - Part Number";
                ws.Cell(1, 3).Value = "BOM - Part Number";
                ws.Cell(1, 4).Value = "PN Match";
                ws.Cell(1, 5).Value = "DAT - Side";
                ws.Cell(1, 6).Value = "BOM - Side";
                ws.Cell(1, 7).Value = "Side Match";
                ws.Cell(1, 8).Value = "Resultado";

                var header = ws.Range(1, 1, 1, 8);
                header.Style.Font.Bold = true;
                header.Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.LightGray;
                header.Style.Alignment.Horizontal =
                    ClosedXML.Excel.XLAlignmentHorizontalValues.Center;

                int row = 2;

                foreach (var r in datos)   // 🔴 AQUÍ EL CAMBIO
                {
                    ws.Cell(row, 1).Value = r.Referencia;
                    ws.Cell(row, 2).Value = r.DatPartNumber;
                    ws.Cell(row, 3).Value = r.BomPartNumber;
                    ws.Cell(row, 4).Value = r.PartNumberMatch ? "YES" : "NO";
                    ws.Cell(row, 5).Value = r.DatSide;
                    ws.Cell(row, 6).Value = r.BomSide;
                    ws.Cell(row, 7).Value = r.SideMatch ? "YES" : "NO";
                    ws.Cell(row, 8).Value =
                        (r.PartNumberMatch && r.SideMatch) ? "OK" : "DIFFERENCE";

                    if (!r.PartNumberMatch || !r.SideMatch)
                    {
                        var rangoFila = ws.Range(row, 1, row, 8);
                        rangoFila.Style.Fill.BackgroundColor =
                            ClosedXML.Excel.XLColor.LightSalmon;
                        rangoFila.Style.Font.Bold = true;
                    }

                    row++;
                }

                ws.Columns().AdjustToContents();
                wb.SaveAs(ruta);
            }
        }

        private void btnExportResults_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel files (*.xlsx)|*.xlsx";
                sfd.Title = "Save full validation report";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportarResultadosExcel(sfd.FileName, _result.Results);
                    MessageBox.Show("Full validation report generated successfully");
                }
            }
        }

        private void btnExportDifferences_Click(object sender, EventArgs e)
        {
            var differences = _result.Results
                .Where(r => !r.PartNumberMatch || !r.SideMatch)
                .ToList();

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel files (*.xlsx)|*.xlsx";
                sfd.Title = "Save differences report";
                sfd.FileName = "DAT_BOM_Differences_Report.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportarResultadosExcel(sfd.FileName, differences);
                    MessageBox.Show("Differences report generated successfully");
                }
            }
        }

    }
}
