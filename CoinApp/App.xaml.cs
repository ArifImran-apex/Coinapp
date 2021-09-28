using Autofac;
using CoinApp.Services;
using CoinApp.ViewModels;
using Xamarin.Forms;

namespace CoinApp
{
    public partial class App : Application
    {
        public static IContainer Container { get; set; }
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
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
