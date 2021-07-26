using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CoinApp.Services;
using Xamarin.Forms;

namespace CoinApp.ViewModels
{
    public class CoinListingsPageViewModel : BaseViewModel
    {
        CoinService coinService;
        public ICommand CoinDetailCommand
        {
            get;
            set;
        }
        public CoinListingsPageViewModel()
        {
            coinService = new CoinService();
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
                var coins = await coinService.GetAllCoinInfo();
            });
        }
    }
}
