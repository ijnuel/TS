using Microsoft.Extensions.DependencyInjection;
using Services.BaseServices;
using Services.PatientServices;
using Services.PaymentServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IBaseService, BaseService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IPaymentService, PaymentService>();

            return services;
        }
    }
}
