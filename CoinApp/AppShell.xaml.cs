using System;
using System.Collections.Generic;
using CoinApp.ViewModels;
using CoinApp.Views;
using Xamarin.Forms;

namespace CoinApp
{
    public partial class AppShell : Shell
    {
        
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            BindingContext = new AppShellViewModel();
        }

        void RegisterRoutes()
        {
            Routing.RegisterRoute("CoinDetailsPage", typeof(CoinDetailsPage));
            Routing.RegisterRoute("ForgotPassword", typeof(ForgotPassword));
        }
    }
}
