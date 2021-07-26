using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace CoinApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand LoginCommand
        {
            get;
            set;
        }
        public ICommand ForgotPasswordCommand
        {
            get;
            set;
        }
        public LoginViewModel()
        {
            LoginCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("//DashBoard");
            });
            ForgotPasswordCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("ForgotPassword");
            });
        }
    }
}
