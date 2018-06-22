using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Techem.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CapturePage : ContentPage
	{
		public CapturePage ()
		{
			InitializeComponent ();
		}

        private async void BtnPhoto_Clicked(object sender, EventArgs e)
        {
            if (CrossMedia.IsSupported)
            {
                var photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });
                if(photo != null)
                {
                    var stream = photo.GetStream();

                    this.ImagePhoto.Source = ImageSource.FromStream(() => 
                    { return stream; }
                    );
                }
            }
            else
            {
                await DisplayAlert("Photo", "Caméra non supportée", "OK");
            }
        }
    }
}