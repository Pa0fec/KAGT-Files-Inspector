using System;
using System.Collections.Generic;
using System.IO;

namespace FilesInspector
{
    public static class CsvParser
    {
        public static List<DatRecord> ProcesarCsv(string ruta, string side)
        {
            var registros = new List<DatRecord>();
            var lines = File.ReadAllLines(ruta);

            for (int i = 1; i < lines.Length; i++) // saltar header
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                    continue;

                var cols = lines[i].Split(',');

                if (cols.Length < 2)
                    continue;

                string referencia = CleanValue(cols[0]);
                string partNumber = CleanValue(cols[1]);

                registros.Add(new DatRecord
                {
                    Referencia = referencia,
                    PartNumber = partNumber,
                    Side = side
                });
            }

            return registros;
        }

        private static string CleanValue(string value)
        {
            return value
                .Trim()
                .Trim('"')
                .ToUpper();
        }
    }
}