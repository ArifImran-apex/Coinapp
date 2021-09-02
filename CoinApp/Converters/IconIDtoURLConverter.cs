using System;
using System.Globalization;
using Xamarin.Forms;

namespace CoinApp.Converters
{
    public class IconIDtoURLConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            String uRL = String.Empty;
            if(value != null && value is String str)
            {
                //Step 1 - Remove dashes from id_icon field of the data, to be used inside the URL
                uRL = str.Replace("-", "");
                //Step 2 - Create a URL
                uRL = string.Format("https://s3.eu-central-1.amazonaws.com/bbxt-static-icons/type-id/png_32/{0}.png", uRL);
            }
            return uRL;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
