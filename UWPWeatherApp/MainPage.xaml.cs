using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPWeatherApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_click(object sender, RoutedEventArgs e)
        {
            RootObject showWeather = await OpenWeatherMap.showWeather(20.0, 30.0);

            String icon = String.Format("http://openweathermap.org/img/w/{0}.png", showWeather.weather[0].icon);
            Image.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));

            TextResult.Text = showWeather.name + " - " + ((int)showWeather.main.temp).ToString() + " - " + showWeather.weather[0].description;
        }
    }
}
