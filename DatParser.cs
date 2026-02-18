using System;
using System.Collections.Generic;
using System.IO;

namespace FilesInspector
{
    public static class DatParser
    {
        // ====================================================
        //  FUNCIÓN: Separar la primera columna del archivo DAT
        // ====================================================
        public static (string PartNumber, string Referencia) ParseDatLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return (string.Empty, string.Empty);

            string firstBlock = line
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)[0]
                .Trim()
                .ToUpper();

            if (firstBlock.Length <= 7)
                return (firstBlock, string.Empty);

            string core = firstBlock.Substring(3);

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
                return (core, string.Empty);

            string partNumber = core.Substring(0, core.Length - referencia.Length);

            return (partNumber, referencia);
        }

        public static string MapSide(string rawSide)
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
        public static List<DatRecord> ProcesarDat(string ruta)
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
    }
}
