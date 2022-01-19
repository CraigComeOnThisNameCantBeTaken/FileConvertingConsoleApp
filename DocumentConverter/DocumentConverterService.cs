using DocumentConverter.Constants;
using DocumentConverter.DocumentConversion;
using DocumentConverter.Persistance;

namespace DocumentConverter
{
    internal class DocumentConverterService : IDocumentConverterService
    {
        private readonly IDocumentRepository documentRepo;

        public DocumentConverterService(IDocumentRepository documentRepo)
        {
            this.documentRepo = documentRepo;
        }

        public async Task<string> ConvertAsync(string documentIdentifier, DocumentType from, DocumentType to)
        {
            var converter = DocumentConverterFactory.Create(from, to);
            var document = await documentRepo.ReadDocumentAsync(documentIdentifier);

            return converter.Convert(document);
        }
    }
}
