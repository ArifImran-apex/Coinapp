using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CoinApp.Models;
using CoinApp.Services;
using Xamarin.Forms;

namespace CoinApp.ViewModels
{
    public class CoinListingsPageViewModel : BaseViewModel
    {
        ICoinService coinService;
        private List<CoinInfo> currencies = new List<CoinInfo>();
        public List<CoinInfo> Currencies
        {
            get
            {
                return currencies;
            }
            set
            {
                SetField(ref currencies, value);
            }
        }
        public ICommand CoinDetailCommand
        {
            get;
            set;
        }
        public CoinListingsPageViewModel(ICoinService coinService)
        {
            this.coinService = coinService;
            FetchCoins();
            CoinDetailCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("CoinDetailsPage");
            });
        }

        private void FetchCoins()
        {
            Task.Run(async () =>
            {
                Currencies = await coinService.GetAllCoinInfo();
            });
        }
    }
}
