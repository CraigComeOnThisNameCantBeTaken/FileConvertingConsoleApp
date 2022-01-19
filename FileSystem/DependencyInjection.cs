using Microsoft.Extensions.DependencyInjection;

namespace FileSystem
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddFileSystem(this IServiceCollection services)
        {
            services.AddTransient<IFileSystem, RealFileSystem>();
            return services;
        }

        public static IServiceCollection AddInMemoryFileSystem(this IServiceCollection services)
        {
            var existing = services
                .FirstOrDefault(descriptor => descriptor.ServiceType == typeof(IFileSystem));
            if (existing is not null)
                services.Remove(existing);

            services.AddTransient<IFileSystem, InMemoryFileSystem>();
            return services;
        }
    }
}
