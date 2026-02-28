using Microsoft.Extensions.DependencyInjection;
using DockerDemo.Docker.Service;
using DockerDemo.Docker.Interface;

namespace DockerDemo.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IStoreService, StoreService>();
            return services;

        }
    }
}
