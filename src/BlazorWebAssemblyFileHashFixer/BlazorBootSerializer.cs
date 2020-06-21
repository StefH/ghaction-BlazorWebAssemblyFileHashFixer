using System.IO;
using System.Text.Json;

namespace BlazorWebAssemblyFileHashFixer
{
    public static class BlazorBootSerializer
    {
        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public static BlazorBoot DeserializeFromFile(string path)
        {
            return JsonSerializer.Deserialize<BlazorBoot>(File.ReadAllText(path), Options);
        }
    }
}