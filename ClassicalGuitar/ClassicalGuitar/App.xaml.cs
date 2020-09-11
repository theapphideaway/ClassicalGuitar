using ClassicalGuitar.Services;
using ClassicalGuitar.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClassicalGuitar
{
    public partial class App : Application
    { 
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        public static ServiceProvider RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IGuitarService, GuitarService>();
            services.AddTransient<GuitarsViewModel>();
            return services.BuildServiceProvider();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
