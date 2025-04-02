using Microsoft.Extensions.DependencyInjection;
using ServiceFileCreator.Service;

namespace ServiceFileCreator.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddAdamServiceFileCreator(this IServiceCollection services)
        {
            services.AddTransient<IServiceFileCreator, Service.ServiceFileCreator>();
            return services;
        }
    }
}
