using System;
using System.Collections.Generic;
using CoinApp.ViewModels;
using Xamarin.Forms;

namespace CoinApp.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
    }
}
