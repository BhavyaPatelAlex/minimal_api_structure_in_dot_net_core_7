using InfucareRx.PatientHealthApp.Repository.Interfaces;
using InfucareRx.PatientHealthApp.Repository.Interfaces.Base;
using InfucareRx.PatientHealthApp.Repository.Repository;
using InfucareRx.PatientHealthApp.Repository.Repository.Base;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace InfucareRx.PatientHealthApp.Repository
{
    public static class RepositoryExtention
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));

            return services;
        }
    }
}