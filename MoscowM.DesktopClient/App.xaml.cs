using Microsoft.Extensions.DependencyInjection;
using MoscowM.ApplicationServices.GetInOutMetroListUseCase;
using MoscowM.ApplicationServices.Ports.Cache;
using MoscowM.ApplicationServices.Repositories;
using MoscowM.DesktopClient.InfrastructureServices.ViewModels;
using MoscowM.DomainObjects;
using MoscowM.DomainObjects.Ports;
using MoscowM.InfrastructureServices.Cache;
using MoscowM.InfrastructureServices.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MoscowM.DesktopClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDomainObjectsCache<InOutMetro>, DomainObjectsMemoryCache<InOutMetro>>();
            services.AddSingleton<NetworkInOutMetroRepository>(
                x => new NetworkInOutMetroRepository("localhost", 80, useTls: false, x.GetRequiredService<IDomainObjectsCache<InOutMetro>>())
            );
            services.AddSingleton<CachedReadOnlyInOutMetroRepository>(
                x => new CachedReadOnlyInOutMetroRepository(
                    x.GetRequiredService<NetworkInOutMetroRepository>(), 
                    x.GetRequiredService<IDomainObjectsCache<InOutMetro>>()
                )
            );
            services.AddSingleton<IReadOnlyInOutMetroRepository>(x => x.GetRequiredService<CachedReadOnlyInOutMetroRepository>());
            services.AddSingleton<IGetInOutMetroListUseCase, GetInOutMetroListUseCase>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs args)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
