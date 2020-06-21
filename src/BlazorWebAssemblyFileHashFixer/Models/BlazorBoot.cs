using System.Runtime.Serialization;

namespace BlazorWebAssemblyFileHashFixer.Models
{
    public class BlazorBoot
    {
        public bool CacheBootResources { get; set; }

        public object[] Config { get; set; }

        public bool DebugBuild { get; set; }

        public string EntryAssembly { get; set; }

        public bool LinkerEnabled { get; set; }

        public Resources Resources { get; set; } = new Resources();
    }
}