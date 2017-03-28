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
            var location = await Location.position();

            RootObject showWeather = await OpenWeatherMap.showWeather(location.Coordinate.Latitude, location.Coordinate.Longitude);

            String icon = String.Format("ms-appx:///Assets/icons/{0}.png", showWeather.weather[0].icon);
            Image.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));

            name.Text = showWeather.name;
            temp.Text = ((int)showWeather.main.temp).ToString();
            Description.Text = showWeather.weather[0].description;
        }
    }
}
