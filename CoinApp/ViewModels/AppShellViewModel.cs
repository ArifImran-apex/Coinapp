using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace CoinApp.ViewModels
{
    public class AppShellViewModel
    {
        public ICommand Signout
        {
            get;
            set;
        }
        public AppShellViewModel()
        {
            Signout = new Command(async () =>
            {
                var result = await App.Current.MainPage.DisplayAlert("Alert!", "Are you sure you want to signout.","OK", "Cancel");
                if(result)
                {
                    await Shell.Current.GoToAsync("//LoginPage");
                }
            });
        }
    }
}
