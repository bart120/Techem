using System;
using Techem.Data;
using Techem.Helpers;
using Techem.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Techem
{
	public partial class App : Application
	{

        public const string SELECT_CITY_MESSAGE = "SelectCity";

        public App ()
		{
			InitializeComponent();
            

			MainPage = new MasterPage();
            var d = DB;
		}

        private static TechemDataBase db;
        public static TechemDataBase DB {
            get
            {
                if (db == null)
                    db = new TechemDataBase(DependencyService.Get<IFileHelper>().GetLocalFilePath("TechemSQLite.db3"));
                return db;
            }
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
