using System;
using System.Collections.Generic;
using System.Text;

namespace FilesInspector
{
    public class ReferenceResult
    {
        public string Referencia { get; set; }

        public string DatPartNumber { get; set; }
        public string BomPartNumber { get; set; }

        public string DatSide { get; set; }
        public string BomSide { get; set; }

        public bool PartNumberMatch { get; set; }
        public bool SideMatch { get; set; }
    }

}