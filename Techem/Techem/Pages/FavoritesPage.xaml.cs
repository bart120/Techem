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

            this.CitiesListView.ItemSelected += async (object sender, SelectedItemChangedEventArgs e) =>
            {
                if (e.SelectedItem == null) return;

                var city = e.SelectedItem as City;
                MessagingCenter.Send(this, App.SELECT_CITY_MESSAGE, city);
                await Navigation.PopModalAsync(true);
                this.CitiesListView.SelectedItem = null;
            };
		}

        
        /*private async void ItemSelected_Clicked(object sender, SelectedItemChangedEventArgs e)
        {
            var city = e.SelectedItem as City;
            MessagingCenter.Send(this, App.SELECT_CITY_MESSAGE, city);
            await Navigation.PopModalAsync(true);
        }*/

        protected override void OnAppearing()
        {
            
            base.OnAppearing();
            viewModel.LoadCitiesCommand.Execute(null);
        }

        private async void ItemSelected_Clicked(object sender, EventArgs e)
        {
            var city = ((MenuItem)sender).CommandParameter as City;
            MessagingCenter.Send(this, App.SELECT_CITY_MESSAGE, city);
            await Navigation.PopModalAsync(true);
        }

        private async void CitiesListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            /*var city = e.Group as City;
            MessagingCenter.Send(this, App.SELECT_CITY_MESSAGE, city);
            await Navigation.PopModalAsync(true);*/
        }

        private async void CitiesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var city = e.SelectedItem as City;
            if (city != null)
            {
                MessagingCenter.Send(this, App.SELECT_CITY_MESSAGE, city);
                await Navigation.PopModalAsync(true);
            }
        }
    }
}