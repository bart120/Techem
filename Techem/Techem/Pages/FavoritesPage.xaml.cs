using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techem.Models;
using Techem.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Techem.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FavoritesPage : ContentPage
	{
        FavoritesViewModel viewModel;

		public FavoritesPage ()
		{
			InitializeComponent ();
            BindingContext = viewModel = new FavoritesViewModel();
		}

        
        private async void ItemSelected_Clicked(object sender, SelectedItemChangedEventArgs e)
        {
            var city = e.SelectedItem as City;
            MessagingCenter.Send(this, App.SELECT_CITY_MESSAGE, city);
            await Navigation.PopModalAsync(true);
        }

        protected override void OnAppearing()
        {
            
            base.OnAppearing();
            viewModel.LoadCitiesCommand.Execute(null);
        }
    }
}