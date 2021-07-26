using System;
using System.Collections.Generic;
using CoinApp.ViewModels;
using Xamarin.Forms;

namespace CoinApp.Views
{
    public partial class CoinListingsPage : ContentPage
    {
        public CoinListingsPage()
        {
            InitializeComponent();
            BindingContext = new CoinListingsPageViewModel();
        }
    }
}
