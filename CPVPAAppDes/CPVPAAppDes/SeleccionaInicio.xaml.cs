using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CPVPAAppDes
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SeleccionaInicio : ContentPage
	{
		public SeleccionaInicio ()
		{
			InitializeComponent ();
		}

        private async void btnElec1_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushModalAsync(new CantAPro());
        }

        private async void btnElec2_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushModalAsync(new ResProd());
        }
    }
}