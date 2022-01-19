using DocumentConverter.Constants;

namespace DocumentConverter
{
    public interface IDocumentConverterService
    {
        Task<string> ConvertAsync(string documentIdentifier, DocumentType from, DocumentType to);
    }
}
