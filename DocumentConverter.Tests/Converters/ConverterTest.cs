using System.IO;

namespace DocumentConverter.Tests.Converters
{
    public abstract class ConverterTests
    {
        private string PathToData = Path.Combine(
            Directory.GetCurrentDirectory(),
            "",
            "Data"
        );

        protected string GetFileContent(string fileName) {
            var path = GetPath(fileName);
            return File.ReadAllText(path);
        }

        private string GetPath(string fileName) => Path.Combine(PathToData, fileName);
    }
}
