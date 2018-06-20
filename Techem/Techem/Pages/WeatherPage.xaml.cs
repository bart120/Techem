using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}