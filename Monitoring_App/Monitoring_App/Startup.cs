using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Monitoring_App.Domain.Factories;
using Monitoring_App.Domain.Services;
using Npgsql;

namespace Monitoring_App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            ConfigureEntity(services);
            SetDependencyInjection(services);
            ServiceTypeFactory.InitiateTypes();
        }

        public void SetDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IServicesService, ServicesService>();
            services.AddScoped<IServicesRepository, ServicesRepository>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void ConfigureEntity(IServiceCollection services)
        {
            var connectionString = Configuration.GetValue<string>("PostgreSql:ConnectionString");
            var dbPassword = Configuration.GetValue<string>("PostgreSql:DbPassword");

            var builder = new NpgsqlConnectionStringBuilder(connectionString)
            {
                Password = dbPassword
            };

            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(builder.ConnectionString));
        }

    }
}
