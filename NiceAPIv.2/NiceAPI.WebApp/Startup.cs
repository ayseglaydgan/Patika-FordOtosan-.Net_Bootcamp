using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NiceAPI.BaseClass;
using NiceAPI.BaseClass.Jwt;
using NiceAPI.DataLayer;
using NiceAPI.WebApp.Extensions;
using NiceAPI.WebApp.Middleware;

namespace NiceAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static JwtConfig JwtConfig { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            JwtConfig = Configuration.GetSection("JwtConfig").Get<JwtConfig>();
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));

            // ABOUT THE DEPENDENCY INJECTION
            services.AddDbContextDI(Configuration);
            //services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services.AddScoped<IValidator<Person>, PersonValidator>();
          
            services.AddServices();
            services.AddMapperService();
            services.AddBussinessServices();
            services.AddJwtAuthentication();
            services.AddCustomSwagger();

            services.AddControllers();
            
            
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NiceAPI v1"));
            }

            app.UseHttpsRedirection();

            

            app.UseMiddleware<HeartbeatMiddleware>();
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseMiddleware<RequestLoggingMiddleware>();


            //jwt
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.AddApplicationServices();
        }
    }
}
