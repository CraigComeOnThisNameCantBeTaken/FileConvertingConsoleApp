using FileSystem;
using System.Reflection;

namespace DocumentConverter.Persistance
{
    internal class FileSystemDocumentRepository : IDocumentRepository
    {
        // there are other ways to handle this but to not get too side tracked from the scope of this task and still be runnable anywhere...
        private static string fileDirectory = Path.Combine(
            Assembly.GetExecutingAssembly().Location,
            ".."
        );

        private readonly IFileSystem fileSystem;

        public FileSystemDocumentRepository(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
        }

        public Task<string> ReadDocumentAsync(string documentId)
        {
            var path = Path.Combine(fileDirectory, documentId);
            using var fileStream = fileSystem.OpenRead(path);

            var result = GetContent(fileStream);
            return Task.FromResult(result);
        }

        private string GetContent(Stream stream)
        {
            var sm = new StreamReader(stream);
            var result = sm.ReadToEnd();

            if (result is null)
                throw new Exception("File is empty");

            return result;
        }
    }
}
