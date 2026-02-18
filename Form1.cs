using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace FilesInspector
{
    public partial class MainView : Form
    {
        private ComparisonResult _comparisonResult;
        public MainView()
        {
            InitializeComponent();
        }

        private void MainView_Load(object sender, EventArgs e)
        {
        }

        // =============================
        //  EVENTO: Seleccionar archivo .DAT
        // =============================
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

        // =============================
        //  EVENTO: Seleccionar archivo BOM
        // =============================
        private void btnSelectBom_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                ofd.Title = "Please Select the BOM file (.xlsx)";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtBomFile.Text = ofd.FileName;
                }
            }
        }

       

        // ====================================================
        //  FUNCIÓN: Leer BOM (ClosedXML)
        // ====================================================
        private List<BomEntry> LeerBOM(string ruta)
        {
            var lista = new List<BomEntry>();

            using (var wb = new XLWorkbook(ruta))
            {
                var ws = wb.Worksheet(1);
                var rows = ws.RangeUsed().RowsUsed();

                foreach (var row in rows.Skip(1))
                {
                    var partNumber = row.Cell("D").GetString().Trim(); // ✅
                    var referencia = row.Cell("H").GetString().Trim(); // ✅
                    var side = row.Cell("L").GetString().Trim();       // ✅

                    if (!string.IsNullOrWhiteSpace(referencia))
                    {
                        lista.Add(new BomEntry
                        {
                            PartNumber = partNumber,
                            Referencia = referencia.ToUpper(),
                            Side = side
                        });
                    }
                }
            }

            return lista;
        }


        // ====================================================
        //  EVENTO: BOTÓN INSPECT FILES
        // ====================================================
        private async void btnInspectFiles_Click(object sender, EventArgs e)
        {
            string datPath = txtDatFile.Text;
            string bomPath = txtBomFile.Text;

            if (!File.Exists(datPath))
            {
                MessageBox.Show("Select the DAT file");
                return;
            }

            if (!File.Exists(bomPath))
            {
                MessageBox.Show("Select the BOM file(.xlsx)");
                return;
            }

            ProgressView pv = new ProgressView();
            pv.Show();
            pv.UpdateProgress(0, "Reading files...");

            _comparisonResult = await Task.Run(() =>
            {
                var datInfo = DatParser.ProcesarDat(datPath);
                var bomInfo = LeerBOM(bomPath);

                return CompararArchivos(datInfo, bomInfo, pv);
            });

            pv.Result = _comparisonResult;

            //pv.BeginInvoke((Action)(() => pv.Close()));

            //MessageBox.Show("Comparison completed.");
        }

        // ====================================================
        //  FUNCIÓN: COMPARAR ARCHIVOS
        // ====================================================
        private ComparisonResult CompararArchivos(
    List<DatRecord> dat,
    List<BomEntry> bom,
    ProgressView pv)
        {
            var result = new ComparisonResult();

            var bomDict = bom
            .Where(b =>
                !string.IsNullOrWhiteSpace(b.Referencia) &&
                !string.IsNullOrWhiteSpace(b.PartNumber))
            .GroupBy(b => new
            {
                Ref = b.Referencia.Trim().ToUpper(),
                PN = b.PartNumber.Trim().ToUpper()
            })
            .ToDictionary(g => g.Key, g => g.First());

            var datByReference = dat
            .Where(d => !string.IsNullOrWhiteSpace(d.Referencia))
            .GroupBy(d => new
            {
                Ref = d.Referencia.Trim().ToUpper(),
                PN = d.PartNumber?.Trim().ToUpper(),
                Side = d.Side
            })
            .Select(g => g.First())
            .ToList();

            int total = datByReference.Count;
            int procesados = 0;


            foreach (var d in datByReference)
            {
                bomDict.TryGetValue(
                    new
                    {
                        Ref = d.Referencia.Trim().ToUpper(),
                        PN = d.PartNumber.Trim().ToUpper()
                    },
                    out var bomMatch
                );


                var referenceResult = new ReferenceResult
                {
                    Referencia = d.Referencia,
                    DatPartNumber = d.PartNumber,
                    DatSide = d.Side
                };

                if (bomMatch == null)
                {
                    referenceResult.PartNumberMatch = false;
                    referenceResult.SideMatch = false;
                }
                else
                {
                    referenceResult.BomPartNumber = bomMatch.PartNumber;
                    referenceResult.BomSide = bomMatch.Side;

                    referenceResult.PartNumberMatch =
                        d.PartNumber == bomMatch.PartNumber;

                    referenceResult.SideMatch =
                     string.IsNullOrWhiteSpace(bomMatch.Side)
                         ? true   // si el BOM no define Side, no se marca como error
                         : d.Side.Equals(bomMatch.Side, StringComparison.OrdinalIgnoreCase);

                }

                result.Results.Add(referenceResult);

                // 🔹 PROGRESO 🔹
                procesados++;
                int percent = (procesados * 100) / total;

                pv.UpdateProgress(
                    percent,
                    $"Comparing references {procesados} / {total}"
                );
            }

            pv.UpdateProgress(100, "Analysis completed");
            return result;

        }


        // ====================================================
        //  MODELOS
        // ====================================================

        public class BomEntry
        {
            public string PartNumber { get; set; }
            public string Referencia { get; set; }
            public string Side { get; set; }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
