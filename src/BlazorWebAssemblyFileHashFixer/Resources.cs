using System.Collections.Generic;

namespace BlazorWebAssemblyFileHashFixer
{
    public class Resources
    {
        public IReadOnlyDictionary<string, string> Assembly { get; set; } = new Dictionary<string, string>();

        public IReadOnlyDictionary<string, string> Pdb { get; set; } = new Dictionary<string, string>();

        public IReadOnlyDictionary<string, string> Runtime { get; set; } = new Dictionary<string, string>();

        public IReadOnlyDictionary<string, string> SatelliteResources { get; set; } = new Dictionary<string, string>();
    }
}