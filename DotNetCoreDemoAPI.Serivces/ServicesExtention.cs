using InfucareRx.PatientHealthApp.Serivces.Interfaces;
using InfucareRx.PatientHealthApp.Serivces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InfucareRx.PatientHealthApp.Serivces
{
    public static class ServicesExtention
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IUserService),typeof(UserService));
            return services;
        }
    }
}
