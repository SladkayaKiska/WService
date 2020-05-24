using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MoscowM.ApplicationServices.GetInOutMetroListUseCase;
using MoscowM.ApplicationServices.Repositories;
using MoscowM.DomainObjects.Ports;
using MoscowM.DomainObjects;
using System.Collections.Generic;

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
            services.AddScoped<InMemoryInOutMetroRepository>(x => new InMemoryInOutMetroRepository(
                new List<InOutMetro> {
                    new InOutMetro() 
                    { 
                        Id = 1,
                       Name="Китай-город, вход-выход 9 в северный вестибюль",
       MetroStation="Китай-город  ", MetroLine="Калужско-Рижская линия  ",

       Schedule1 ="Режим работы по нечётным дням: открытие в 05:30:00; закрытие в 01:00:00; первый поезд по 1 пути в 05:43:05, по 2 пути в 05:49:50; последний поезд по 1 пути в 01:36:20, по 2 пути в 01:27:24  ",

Schedule2 ="Режим работы по чётным дням: открытие в 05:30:00; закрытие в 01:00:00; первый поезд по 1 пути в 05:44:00, по 2 пути в 05:49:05; последний поезд по 1 пути в 01:36:20, по 2 пути в 01:27:24  "

    },
                    new InOutMetro()
                    {
                       Id = 2,
                        Name="Китай-город, вход-выход 5 в северный вестибюль",
       MetroStation="Китай-город ", MetroLine="Калужско-Рижская линия ",

       Schedule1 ="Режим работы по нечётным дням:  открытие в 05:30:00; закрытие в 01:00:00; первый поезд по 1 пути в 05:43:05, по 2 пути в 05:49:50; последний поезд по 1 пути в 01:36:20, по 2 пути в 01:27:16",

Schedule2 ="Режим работы по чётным дням:  открытие в 05:30:00; закрытие в 01:00:00; первый поезд по 1 пути в 05:44:00, по 2 пути в 05:49:05; последний поезд по 1 пути в 01:36:20, по 2 пути в 01:27:16 "
                    },
                    new InOutMetro()
                    {
                        Id = 3,
  Name="Братиславская, вход-выход 5 в северный вестибюль",
       MetroStation="Братиславская  ", MetroLine="Люблинско-Дмитровская линия",

       Schedule1 ="Режим работы по нечётным дням:  открытие в 05:30:00; закрытие в 01:00:00; первый поезд по 1 пути в 05:56:00, по 2 пути в 05:42:00; последний поезд по 1 пути в 01:52:00, по 2 пути в 01:12:00  ",

Schedule2 ="Режим работы по чётным дням:  открытие в 05:30:00; закрытие в 01:00:00; первый поезд по 1 пути в 06:00:00, по 2 пути в 05:49:00; последний поезд по 1 пути в 01:52:00, по 2 пути в 01:12:00 "

                    }
            }));
            services.AddScoped<IReadOnlyInOutMetroRepository>(x => x.GetRequiredService<InMemoryInOutMetroRepository>());
            services.AddScoped<IInOutMetroRepository>(x => x.GetRequiredService<InMemoryInOutMetroRepository>());

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
