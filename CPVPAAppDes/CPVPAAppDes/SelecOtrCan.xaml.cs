using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CPVPAAppDes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelecOtrCan : ContentPage
    {
        private CantidadProd cantidadPP;

        public SelecOtrCan()
        {
            InitializeComponent();
        }

        public SelecOtrCan(CantidadProd cantidadPP)
        {
            this.cantidadPP = cantidadPP;
        }

        private async void btnNext_Clicked(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(EntryCant.Text)) {
                await DisplayAlert("Error","Debe ingresar cantidad a producir","aceptar");
                EntryCant.Focus();
                return;
            }
            var cantiCAP = Int32.Parse(EntryCant.Text);

            var cantidadPP = new CantidadProd { Cantidad = cantiCAP };
            await this.Navigation.PushModalAsync(new SelecSabor(cantidadPP));
        }
    }
}