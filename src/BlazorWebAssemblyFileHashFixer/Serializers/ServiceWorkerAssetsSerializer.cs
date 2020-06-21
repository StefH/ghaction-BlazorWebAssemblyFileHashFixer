using System;
using System.IO;
using System.Text.Json;
using BlazorWebAssemblyFileHashFixer.Models;

namespace BlazorWebAssemblyFileHashFixer.Serializers
{
    public static class ServiceWorkerAssetsSerializer
    {
        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public static AssetsManifest DeserializeFromFile(string path)
        {
            var text = File.ReadAllText(path).Replace("self.assetsManifest = ", string.Empty).Replace(";", string.Empty);

            return JsonSerializer.Deserialize<AssetsManifest>(text, Options);
        }
    }
}
