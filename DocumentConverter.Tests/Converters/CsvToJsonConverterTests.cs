using DocumentConverter.DocumentConversion;
using FluentAssertions;
using Xunit;

namespace DocumentConverter.Tests.Converters
{
    public class CsvToJsonConverterTests : ConverterTests
    {
        [Fact]
        public void Convert_FlatInput_FlatResult()
        {
            var input = GetFlatInput();
            var sut = Create();

            var result = sut.Convert(input);

            var actual = result;
            var expected = GetExpectedFlatResult();
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Convert_NestedInput_NestedResult()
        {
            var input = GetNestedInput();
            var sut = Create();

            var result = sut.Convert(input);

            var actual = result;
            var expected = GetExpectedNestedResult();
            actual.Should().BeEquivalentTo(expected);
        }

        private IDocumentConverter Create()
        {
            return new CsvToJsonConverter();
        }

        private string GetExpectedFlatResult()
        {
            return GetFileContent("simple.json");
        }

        private string GetExpectedNestedResult()
        {
            return GetFileContent("nesting.json");
        }

        private string GetFlatInput()
        {
            return GetFileContent("simple.csv");
        }

        private string GetNestedInput()
        {
            return GetFileContent("nesting.csv");
        }
    }
}
