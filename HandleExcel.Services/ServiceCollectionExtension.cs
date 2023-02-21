using HandleExcel.Services;
using HandleExcel.Services.Interfaces;
using HandleExcel.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandleExcel.Repositories
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddScoped<IUserService, UserService>();

            //services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
