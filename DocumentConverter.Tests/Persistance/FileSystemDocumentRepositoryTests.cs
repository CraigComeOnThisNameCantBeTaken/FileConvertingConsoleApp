using DocumentConverter.Persistance;
using FileSystem;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static System.Net.Mime.MediaTypeNames;

namespace DocumentConverter.Tests.Persistance
{
    public class FileSystemDocumentRepositoryTests
    {
        private string path = Path.Combine(
            Assembly.GetExecutingAssembly().Location,
            "..",
            "aPath"
        );

        private InMemoryFileSystem _fileSystem = new();

        [Fact]
        public async Task ReadDocumentAsync_FileExists_ReturnsContent()
        {
            var content = "someContent";
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));
            _fileSystem.Add(path, stream);

            var sut = Create();

            var result = await sut.ReadDocumentAsync(path);
            result.Should().Be(content);
        }

        [Fact]
        public async Task ReadDocumentAsync_FileDoesNotExist_ThrowsFileNotFoundException()
        {
            var sut = Create();
            await sut.Invoking(s => s.ReadDocumentAsync(path))
                .Should().ThrowAsync<FileNotFoundException>();
        }

        private IDocumentRepository Create()
        {
            return new FileSystemDocumentRepository(_fileSystem);
        }
    }
}
