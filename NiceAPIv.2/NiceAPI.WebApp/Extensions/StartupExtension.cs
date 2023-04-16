using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using NiceAPI.DataLayer;
using NiceAPI.DataLayer.Model;
using NiceAPI.ServiceLayer;
using NiceAPI.ServiceLayer.Abstract;
using NiceAPI.ServiceLayer.Concrete;

namespace NiceAPI.WebApp.Extensions
{
    public static class StartupExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            // uow
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // repos
            services.AddScoped<ScopedService>();
            services.AddTransient<TransientService>();
            services.AddSingleton<SingletonService>();

        }
        public static void AddMapperService(this IServiceCollection services)
        {
            // mapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            services.AddSingleton(mapperConfig.CreateMapper());
        }

        public static void AddBussinessServices(this IServiceCollection services)
        {
            // repos
            services.AddScoped<IGenericRepository<Account>, GenericRepository<Account>>();
            services.AddScoped<IGenericRepository<Person>, GenericRepository<Person>>();

            // services
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<ITokenManagementService, TokenManagementService>();



         }
    }
}
