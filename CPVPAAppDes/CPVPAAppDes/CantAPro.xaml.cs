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
    public partial class CantAPro : ContentPage
    {
        public CantAPro()
        {
            InitializeComponent();
           // using (var datos = new DataAccess())
           // {
           //     datosListView.ItemsSource = datos.GetProducciones();
           // }

        }
        // ABRIENDO Y ENVIANDO DATOS A LA SIGUIENTE PANTALLA
        private void btnCant1_Clicked(object sender, EventArgs e)
        {
            var cantiCAP = Int32.Parse(btnCant1.Text);

            var cantidadPP = new CantidadProd { Cantidad = cantiCAP };

            //Se asigna el valor de la cantidad a producir 
            //Produccion produccion = new Produccion
            //{
            //    Cantidad = cantiCAP,
            //    Presentacion = "2lt",
            //    Sabor = "Naranja"
            //};

            //Se realiza la inserción a la BD 
            //using (var datos = new DataAccess())
            //{
            //    datos.InsertProduccion(produccion);
            //   // datosListView.ItemsSource = datos.GetProducciones();
            //}

            this.Navigation.PushModalAsync(new PreseProd(cantidadPP));
        }

        private void btnCant2_Clicked(object sender, EventArgs e)
        {
            var cantiCAP = Int32.Parse(btnCant2.Text);

            var cantidadPP = new CantidadProd { Cantidad = cantiCAP };

            this.Navigation.PushModalAsync(new PreseProd(cantidadPP));
        }

        private void btnCant3_Clicked(object sender, EventArgs e)
        {
            var cantiCAP = Int32.Parse(btnCant3.Text);

            var cantidadPP = new CantidadProd { Cantidad = cantiCAP };

            this.Navigation.PushModalAsync(new PreseProd(cantidadPP));
        }

        private void btnCant4_Clicked(object sender, EventArgs e)
        {
            var cantiCAP = Int32.Parse(btnCant4.Text);

            var cantidadPP = new CantidadProd { Cantidad = cantiCAP };

            this.Navigation.PushModalAsync(new PreseProd(cantidadPP));
        }
        private void btnCantOthe_Clicked(object sender, EventArgs e)
        {
            var cantiCAP = btnCantOthe.Text;

            //var cantidadPP = new CantidadProd { Cantidad = otraCantidad };

            this.Navigation.PushModalAsync(new SelecOtrCan());
        }
    }
}