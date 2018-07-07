using smileRed4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace smileRed4.Views
{
	public partial class Page1 : ContentPage
	{
		public Page1 ()
		{
			InitializeComponent ();

            var session= (Application.Current.Properties["Place"].ToString());
            Application.Current.Properties.Clear();
            Lugar.Text = session;            
        }
	}
}