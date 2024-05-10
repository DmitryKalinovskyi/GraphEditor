using GraphApplication.Algorithms;
using GraphApplication.Algorithms.Contracts;
using GraphApplication.ModelViews;
using GraphApplication.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using System.Windows;

namespace GraphApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ServiceProvider ServiceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<MainWindowModelView>();
            services.AddSingleton<MainWindow>();

            services.AddScoped<IBFSAlgorithm, BFSAlgorithm>();
            services.AddScoped<IDFSAlgorithm, DFSAlgorithm>();
            services.AddScoped<IMinSpanningTreeAlgorithm, PrimAlgorithm>();

            ServiceProvider = services.BuildServiceProvider();

            MainWindow = ServiceProvider.GetService<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ServiceProvider.GetRequiredService<MainWindow>().Show();
        }
    }
}
