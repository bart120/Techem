using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Techem.Models;
using Xamarin.Forms;

namespace Techem.ViewModels
{
    public class FavoritesViewModel : BaseViewModel
    {
        public ObservableCollection<City> Cities { get; set; }

        public Command LoadCitiesCommand { get; set; }

        public Command DeleteCityCommand { get; set; }

        private int count;

        public int Count
        {
            get { return count; }
            set { SetProperty(ref count, value); }
        }

        


        public FavoritesViewModel()
        {
            Cities = new ObservableCollection<City>();
            LoadCitiesCommand = new Command(async () => await ExecuteLoadCitiesCommand());
            DeleteCityCommand = new Command(async (city) => await ExecuteDeleteCityCommand(city as City));
        }

        protected async Task ExecuteDeleteCityCommand(City city)
        {
            await App.DB.Delete(city);
            LoadCitiesCommand.Execute(null);
        }

        protected async Task ExecuteLoadCitiesCommand()
        {
            this.Cities.Clear();
            var cities = await App.DB.GetAllAsync();
            //this.Cities = cities;
            foreach (var item in cities)
            {
                this.Cities.Add(item);
            }
            this.Count = Cities.Count;
            
        }

    }
}
