using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techem.Models;
using Techem.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Techem.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WeatherPage : ContentPage
	{
		public WeatherPage ()
		{
			InitializeComponent ();
            
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var weather = await WeatherService.GetWeatherByCity(this.EntryCity.Text);
            BindingContext = weather;
        }

        private async void ButtonGeo_Clicked(object sender, EventArgs e)
        {
            if (CrossGeolocator.IsSupported)
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 200;

                var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

                //await DisplayAlert("Geo", $"long: {position.Longitude}, lat: {position.Latitude}", "OK");
                var weather = await WeatherService.GetWeatherByGeoloc(position.Longitude, position.Latitude);
                this.BindingContext = weather;
                //((Weather)BindingContext).City = weather.City;
            }
            else
                await DisplayAlert("Geo", "Impossible de géolocaliser", "OK");
        }

        private async void ButtonAdd_Clicked(object sender, EventArgs e)
        {
            if (BindingContext != null)
            {
                var weather = BindingContext as Weather;
                City city = new City
                {
                    Name = weather.City
                };
                
                await App.DB.SaveAsync(city);
                await DisplayAlert("Ajouter une ville", $"Enregistrement de {city.Name} OK.", "OK");
            }
            
        }

        private async void ButtonFavoris_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new FavoritesPage()));
            //await Navigation.PushAsync(new NavigationPage(new FavoritesPage()));
        }

    }
}