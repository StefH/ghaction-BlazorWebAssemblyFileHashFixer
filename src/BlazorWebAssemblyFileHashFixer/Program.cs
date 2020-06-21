using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BlazorWebAssemblyFileHashFixer.Models;
using BlazorWebAssemblyFileHashFixer.Serializers;
using BlazorWebAssemblyFileHashFixer.Utils;

namespace BlazorWebAssemblyFileHashFixer
{
    class Program
    {
        private const string BlazorBootJson = "blazor.boot.json";
        private const string ServiceWorkAssetsJs = "service-worker-assets.js";

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine($"Please provide the wwwroot path.");
                return;
            }

            string path = args[0];

            string blazorBootPath = Path.Combine(path, "_framework", BlazorBootJson);
            if (File.Exists(blazorBootPath))
            {
                var blazorBootAssets = new List<Asset>();
                var blazorBoot = BlazorBootSerializer.DeserializeFromFile(blazorBootPath);
                blazorBootAssets.AddRange(blazorBoot.Resources.Assembly.Select(x => new Asset
                {
                    Hash = x.Value,
                    Path = Path.Combine(path, "_framework", "_bin", x.Key)
                }));
                blazorBootAssets.AddRange(blazorBoot.Resources.Runtime.Select(x => new Asset
                {
                    Hash = x.Value,
                    Path = Path.Combine(path, "_framework", "wasm", x.Key)
                }));

                int replaced = 0;
                var blazorBootText = File.ReadAllText(blazorBootPath);
                foreach (var file in blazorBootAssets)
                {
                    string hash = $"sha256-{HashUtils.CreateSHA256FromFile(file.Path)}";
                    if (hash != file.Hash)
                    {
                        Console.WriteLine($"{BlazorBootJson} : replacing hash for file '{file.Path}'");
                        blazorBootText = blazorBootText.Replace(file.Hash, hash);
                        replaced++;
                    }
                }
                File.WriteAllText(blazorBootPath, blazorBootText);
                Console.WriteLine($"{BlazorBootJson} : replaced {replaced} hashes.");
            }
            else
            {
                Console.WriteLine($"No '{blazorBootPath}' file found.");
            }

            string assetsPath = Path.Combine(path, ServiceWorkAssetsJs);
            if (File.Exists(assetsPath))
            {
                var serviceWorkerAssets = ServiceWorkerAssetsSerializer.DeserializeFromFile(assetsPath)
                    .Assets.Select(x => new Asset
                    {
                        Hash = x.Hash,
                        Path = Path.Combine(path, x.Url.Replace('/', Path.DirectorySeparatorChar))
                    });

                int replaced = 0;
                var assetsText = File.ReadAllText(assetsPath);
                foreach (var file in serviceWorkerAssets)
                {
                    string hash = $"sha256-{HashUtils.CreateSHA256FromFile(file.Path)}";
                    if (hash != file.Hash)
                    {
                        Console.WriteLine($"{ServiceWorkAssetsJs} : replacing hash for file '{file.Path}'");
                        assetsText = assetsText.Replace(file.Hash, hash);
                        replaced++;
                    }
                }
                File.WriteAllText(assetsPath, assetsText);
                Console.WriteLine($"{ServiceWorkAssetsJs} : replaced {replaced} hashes.");
            }
            else
            {
                Console.WriteLine($"No '{assetsPath}' file found.");
            }
        }
    }
}