using Core.Data.ApplicationDbContext;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationCore(this IServiceCollection services)
        {
            services.AddTransient<IApplicationDbContext, ApplicationDbContext>();

            return services;
        }
    }
}
