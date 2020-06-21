using System.IO;
using System.Reflection;
using BlazorWebAssemblyFileHashFixer;
using FluentAssertions;
using Xunit;

namespace BlazorWebAssemblyFileHashFixerTests
{
    public class UnitTest1
    {
        private readonly string _currentPath = Path.Combine(Assembly.GetExecutingAssembly().Location, "..");

        [Fact]
        public void BlazorBootSerializer_Deserialize()
        {
            var path = Path.Combine(_currentPath, "wwwroot", "_framework", "blazor.boot.json");

            var result = BlazorBootSerializer.DeserializeFromFile(path);

            result.Should().NotBeNull();
        }

        [Fact]
        public void ServiceWorkerAssetsSerializer_Deserialize()
        {
            var path = Path.Combine(_currentPath, "wwwroot", "service-worker-assets.js");

            var result = ServiceWorkerAssetsSerializer.DeserializeFromFile(path);

            result.Should().NotBeNull();
        }
    }
}
