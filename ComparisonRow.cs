using System;
using System.Collections.Generic;
using System.Text;

namespace FilesInspector
{
    public class ComparisonRow
    {
        public string Reference { get; set; }
        public string Side { get; set; }
        public string DatPartNumber { get; set; }
        public string CsvPartNumber { get; set; }
        public string Status { get; set; }
    }
}