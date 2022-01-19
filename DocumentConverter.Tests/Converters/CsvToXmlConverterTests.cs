using DocumentConverter.DocumentConversion;
using FluentAssertions;
using System.Xml.Linq;
using Xunit;

namespace DocumentConverter.Tests.Converters
{
    public class CsvToXmlConverterTests : ConverterTests
    {
        [Fact]
        public void Convert_FlatInput_FlatResult()
        {
            var input = GetFlatInput();
            var sut = Create();

            var result = sut.Convert(input);

            var actual = XDocument.Parse(result);
            var expected = XDocument.Parse(GetExpectedFlatResult());
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Convert_NestedInput_NestedResult()
        {
            var input = GetNestedInput();
            var sut = Create();

            var result = sut.Convert(input);

            var actual = XDocument.Parse(result);
            var expected = XDocument.Parse(GetExpectedNestedResult());
            actual.Should().BeEquivalentTo(expected);
        }

        private IDocumentConverter Create()
        {
            return new CsvToXmlConverter();
        }

        private string GetExpectedFlatResult()
        {
            return GetFileContent("simple.xml");
        }

        private string GetExpectedNestedResult()
        {
            return GetFileContent("nesting.xml");
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
