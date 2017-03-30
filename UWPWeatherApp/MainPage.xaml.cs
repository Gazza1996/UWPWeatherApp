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
        
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // for getting exact location
            var location = await Location.position();
            // create a value showWeather to take api key from openweathermap and give locatin points (lat, lon)
            RootObject showWeather = await OpenWeatherMap.showWeather(location.Coordinate.Latitude, location.Coordinate.Longitude);
            // code set for outputting icons for specific weather
            String icon = String.Format("ms-appx:///Assets/icons/{0}.png", showWeather.weather[0].icon);
            Image.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
            Other.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));

            // current
            // output for textblock 
            name.Text = showWeather.name;
            // needs to be set to toString() to format properly
            temp.Text = ((int)showWeather.main.temp).ToString() + "°c";
            Description.Text = showWeather.weather[0].description;

            // other conditions
            // output for textblock
            // needs to be set to toString() to format properly
            Humidity.Text = "Humidity: " + ((int)showWeather.main.humidity).ToString() + "%";
            Wind.Text = "Wind Speed: " + showWeather.wind.speed + "km/h";
            Temp_max.Text = "Max Temperature: " + showWeather.main.temp_max + "°c";
            Temp_min.Text = "Min Temperature: " + showWeather.main.temp_min + "°c";

        }
    }
}