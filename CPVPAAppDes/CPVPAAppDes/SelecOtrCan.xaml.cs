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
            // Produccion OtraCan = new Produccion {

            //   Cantidad = int.Parse(EntryCant.Text)

            //};
            //using (var datos = new DataAccess()) {
            //   datos.InsertProduccion(OtraCan); 
            //este codigo es para insertar los datos pero al parecer se requeiren todos     
            ///por lo que se realizará la insercion al final

            //listaProduccion.ItemsSource = datos.GetProducciones();

            //datos.s
            //this.Navigation.PushModalAsync(new PreseProd(cantidadPP));
            // }
            await this.Navigation.PushModalAsync(new PreseProd(cantidadPP));
        }

        private async void btnBack_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushModalAsync(new CantAPro());
        }
    }
}