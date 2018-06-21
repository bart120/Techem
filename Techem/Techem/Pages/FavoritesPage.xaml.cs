using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadCitiesCommand.Execute(null);
        }
    }
}