using Microsoft.Extensions.DependencyInjection;
using Repositories.BaseRepositories;
using Repositories.PatientRepositories;
using Repositories.PaymentRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IBaseRepository, BaseRepository>();
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();

            return services;
        }
    }
}
