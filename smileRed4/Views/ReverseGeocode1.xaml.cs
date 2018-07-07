using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using smileRed4.Helpers;
using smileRed4.Models;
using smileRed4.Services;
using smileRed4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace smileRed4.Views
{
	public partial class ReverseGeocode1 : PopupPage
    {
        Geocoder geoCoder;
        MyPlace place;
        string infoPlace;
        public ReverseGeocode1 (GeolocatorService geolocatorServices)
		{
			InitializeComponent ();
            geoCoder = new Geocoder();

            var latitude = geolocatorServices.Latitude;
            var longitude = geolocatorServices.Longitude;
            Address_Place();

            async void Address_Place()
            {
                var fortMasonPosition = new Position(latitude, longitude);
                var possibleAddresses = await geoCoder.GetAddressesForPositionAsync(fortMasonPosition);

                foreach (var a in possibleAddresses)
                {
                    Place.Text += a + "\n";                              
                }
                Application.Current.Properties["Place"] =
                infoPlace = Place.Text;

                if (string.IsNullOrEmpty(Place.Text))
                {
                    Caption.Text = Languages.GpsFailure;
                }
                else
                {
                    Caption.Text = Languages.AddressLabel;
                }
            }         
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
            //await PopupNavigation.PopAsync(true);
        }

         private async void Button_Open(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage(infoPlace));
            await PopupNavigation.Instance.PopAsync(true);
          
        }

        /* // GEOCODE
       * var b2 = new Button { Text = "Geocode '394 Pacific Ave'" };
         b2.Clicked += async (sender, e) => {
             var xamarinAddress = "394 Pacific Ave, San Francisco, California";
             var approximateLocation = await geoCoder.GetPositionsForAddressAsync(xamarinAddress);
             foreach (var p in approximateLocation)
             {
                 l.Text += p.Latitude + ", " + p.Longitude + "\n";
             }
         };*/
    }
}