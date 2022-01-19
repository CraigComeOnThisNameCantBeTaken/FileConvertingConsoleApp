using DocumentConverter.Constants;

namespace DocumentConverter.DocumentConversion
{
    internal static class DocumentConverterFactory
    {
        public static IDocumentConverter Create(DocumentType from, DocumentType to)
        {
            if (from == DocumentType.Csv && to == DocumentType.Xml)
                return new CsvToXmlConverter();
            else if (from == DocumentType.Csv && from != DocumentType.Json)
                return new CsvToJsonConverter();

            throw DocumentConversionException.InvalidTypeConversion(from, to);
        }
    }
}
