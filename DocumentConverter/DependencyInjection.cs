using DocumentConverter.Persistance;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentConverter
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDocumentConversion(this IServiceCollection services)
        {
            services.AddTransient<IDocumentRepository, FileSystemDocumentRepository>();
            services.AddTransient<IDocumentConverterService, DocumentConverterService>();

            return services;
        } 
    }
}
