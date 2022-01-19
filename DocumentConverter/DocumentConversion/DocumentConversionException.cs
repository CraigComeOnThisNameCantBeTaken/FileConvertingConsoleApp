using DocumentConverter.Constants;

namespace DocumentConverter.DocumentConversion
{
    public class DocumentConversionException : Exception
    {
        public DocumentConversionException(string? message) : base(message)
        {
        }

        public static DocumentConversionException InvalidTypeConversion(DocumentType from, DocumentType to) =>
            new DocumentConversionException($"Unable to convert from {from} to {to} as this is not currently supported");
    }
}
