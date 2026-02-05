using System.Collections.Generic;
using System.Linq;

namespace FilesInspector
{
    public class ComparisonResult
    {
        public List<ReferenceResult> Results { get; set; } = new();

        public int TotalReferences => Results.Count;

        public int DifferencesCount =>
            Results.Count(r => !r.PartNumberMatch || !r.SideMatch);


        public bool HasDifferences => DifferencesCount > 0;
    }
}