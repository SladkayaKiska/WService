using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MoscowM.InfrastructureServices.Gateways.Database;
using Microsoft.EntityFrameworkCore;
using MoscowM.ApplicationServices.GetInOutMetroListUseCase;
using MoscowM.ApplicationServices.Ports.Gateways.Database;
using MoscowM.ApplicationServices.Repositories;
using MoscowM.DomainObjects.Ports;

namespace MoscowM.WebService
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
            services.AddDbContext<MetroContext>(opts => 
                opts.UseSqlite($"Filename={System.IO.Path.Combine(System.Environment.CurrentDirectory, "MoscowM.db")}")
            );

            services.AddScoped<IMetroDatabaseGateway, MetroEFSqliteGateway>();

            services.AddScoped<DbInOutMetroRepository>();
            services.AddScoped<IReadOnlyInOutMetroRepository>(x => x.GetRequiredService<DbInOutMetroRepository>());
            services.AddScoped<IInOutMetroRepository>(x => x.GetRequiredService<DbInOutMetroRepository>());

            services.AddScoped<IGetInOutMetroListUseCase, GetInOutMetroListUseCase>();

            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
