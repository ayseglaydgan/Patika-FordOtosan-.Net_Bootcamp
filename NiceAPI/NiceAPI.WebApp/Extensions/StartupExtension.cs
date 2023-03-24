using Microsoft.Extensions.DependencyInjection;
using NiceAPI.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NiceAPI.WebApp.Extensions
{
    public static class StartupExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            // uow
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // repos
            services.AddScoped<IGenericRepository<Account>,GenericRepository<Account>>();
            //services.AddScoped<IGenericRepository<Person>, GenericRepository<Person>>();

           
        }
    }
}
