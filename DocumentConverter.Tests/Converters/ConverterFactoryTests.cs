using DocumentConverter.Constants;
using DocumentConverter.DocumentConversion;
using FluentAssertions;
using System;
using Xunit;

namespace DocumentConverter.Tests.Converters
{
    public class ConverterFactoryTests
    {
        [Theory]
        [InlineData(DocumentType.Csv, DocumentType.Json)]
        [InlineData(DocumentType.Csv, DocumentType.Xml)]
        public void Create_KnownConversions_ReturnsConverter(DocumentType from, DocumentType to)
        {
            var result = DocumentConverterFactory.Create(from, to);
            result.Should().NotBeNull();
        }

        [Theory]
        [InlineData(DocumentType.Json, DocumentType.Csv)]
        [InlineData(DocumentType.Json, DocumentType.Xml)]
        [InlineData(DocumentType.Xml, DocumentType.Csv)]
        [InlineData(DocumentType.Xml, DocumentType.Json)]
        public void Create_UnknownConversions_Throws(DocumentType from, DocumentType to)
        {
            try
            {
                DocumentConverterFactory.Create(from, to);
                throw new Exception("Method should fail");
            }
            catch (DocumentConversionException)
            {

            }
        }
    }
}
