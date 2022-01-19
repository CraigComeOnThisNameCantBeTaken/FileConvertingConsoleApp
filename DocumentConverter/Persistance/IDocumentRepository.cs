namespace DocumentConverter.Persistance
{
    internal interface IDocumentRepository
    {
        Task<string> ReadDocumentAsync(string documentId);
    }
}
