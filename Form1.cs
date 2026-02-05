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
        //  FUNCIÓN: Separar la primera columna del archivo DAT
        // ====================================================
        private (string PartNumber, string Referencia) ParseDatLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return (string.Empty, string.Empty);

            // Tomar el primer bloque (ej. 200N103P63637C426)
            string firstBlock = line
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)[0]
                .Trim()
                .ToUpper();

            if (firstBlock.Length <= 7) // mínimo razonable
                return (firstBlock, string.Empty);

            // Quitar los primeros 3 caracteres (descartables)
            string core = firstBlock.Substring(3);

            // Detectar referencia: últimos 4 o 5 caracteres que inician con letra
            string referencia = string.Empty;

            if (core.Length >= 5 && char.IsLetter(core[^5]))
            {
                referencia = core.Substring(core.Length - 5);
            }
            else if (core.Length >= 4 && char.IsLetter(core[^4]))
            {
                referencia = core.Substring(core.Length - 4);
            }

            if (string.IsNullOrEmpty(referencia))
            {
                // Fallback seguro
                return (core, string.Empty);
            }

            // El resto es número de parte
            string partNumber = core.Substring(0, core.Length - referencia.Length);

            return (partNumber, referencia);
        }

        private string MapSide(string rawSide)
        {
            if (string.IsNullOrWhiteSpace(rawSide))
                return string.Empty;

            rawSide = rawSide.Trim().ToUpper();

            return rawSide switch
            {
                "C" => "SMT_SA",
                "S" => "SMT_SB",
                _ => string.Empty
            };
        }

        // ====================================================
        //  FUNCIÓN: Procesar todo el archivo DAT
        // ====================================================
        private List<DatRecord> ProcesarDat(string ruta)
        {
            var registros = new List<DatRecord>();

            foreach (var line in File.ReadLines(ruta))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var cols = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (cols.Length < 5) continue;

                string col1 = cols[0];
                string side = MapSide(cols[4]);

                var (partNumber, referencia) = ParseDatLine(col1);

                registros.Add(new DatRecord
                {
                    PartNumber = partNumber,
                    Referencia = referencia,
                    Side = side
                });
            }

            return registros;
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
                var datInfo = ProcesarDat(datPath);
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
        public class DatRecord
        {
            public string PartNumber { get; set; }
            public string Referencia { get; set; }
            public string Side { get; set; }
        }

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
