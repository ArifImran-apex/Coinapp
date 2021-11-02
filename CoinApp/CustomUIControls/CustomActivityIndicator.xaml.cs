using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoinApp.CustomUIControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomActivityIndicator : ContentView
    {
        /// <summary>
        /// The fade out delay.
        /// </summary>
        private uint fadeOutDelay = 500;
        public CustomActivityIndicator()
        {
            this.IsVisible = false;
            InitializeComponent();
        }

        public bool IsRunning
        {
            get { return (bool)GetValue(IsRunningProperty); }
            set { SetValue(IsRunningProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsRunning.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty IsRunningProperty =
            BindableProperty.Create("IsRunning", typeof(bool), typeof(CustomActivityIndicator), false, BindingMode.TwoWay, null, propertyChanged: OnIsRunning);

        private static void OnIsRunning(BindableObject bindable, object oldValue, object newValue)
        {
            ((CustomActivityIndicator)bindable).OnIsRunningChanged((bool)oldValue, (bool)newValue);
        }
        private void OnIsRunningChanged(bool oldValue, bool newValue)
        {
            //To show the loader
            if (newValue && !oldValue)
            {
                this.IsVisible = true;
                this.LoaderContainer.Opacity = 1;
            }
            else
            {
                // To hide the loader
                this.LoaderContainer.Animate("containeranimation", new Animation((double obj) =>
                {
                    this.LoaderContainer.Opacity = obj;
                },
                    this.LoaderContainer.Opacity, 0.1, Easing.CubicInOut), 16, this.fadeOutDelay, null, (arg1, arg2) =>
                    {
                        this.IsVisible = false;
                    }, () =>
                    {
                        return false;
                    });
            }
        }
    }
}