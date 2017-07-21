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
    public partial class SelecSabor : ContentPage
    {
        String valCat;
        String valPres;
        public SelecSabor(CantPres CantidadPresO)
        {
            string[] ValArray = CantidadPresO.CantidadPres.ToArray() ;
             valCat = ValArray[0];
             valPres = ValArray[1];
            InitializeComponent();
            //  _cantidad = cantidad;
            BindingContext = valCat.ToString();
            BindingContext = valPres;
            //DisplayAlert("Datos", valCat, "aceptar");
            //DisplayAlert("Datos", valPres, "aceptar");


            //============================Creating TapGestureRecognizers  
            //var tapImage = new TapGestureRecognizer();
            ////Binding events  
            //tapImage.Tapped += tapImage_Tapped;
            ////Associating tap events to the image buttons  
            //btnSab4.GestureRecognizers.Add(tapImage);
            //void tapImage_Tapped(object sender, EventArgs e)
            //{
            //    // handle the tap  
            //    var cantiCAP = valCat;
            //    var presenCAP = valPres;
            //    var sabSap = "simple";
            //    string[] Prod3 = new string[] { cantiCAP, presenCAP, sabSap };
            //    // var cantidadPP = new CantPres { Cantidad = cantiCAP };
            //    var Pro3s = new CantPres { CantidadPres = Prod3 };

            //    this.Navigation.PushModalAsync(new ResProd(Pro3s));
            //}

        }

        /*
        private void SelecSabNext_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new ResProd());
        }
        */
        private async void btnSab1_Clicked(object sender, EventArgs e)
        {
            var cantiCAP = valCat;
            var presenCAP = valPres;
            var sabSap = btnSab1.Text;
            string[] Prod3 = new string[] { cantiCAP, presenCAP, sabSap };
            // var cantidadPP = new CantPres { Cantidad = cantiCAP };
            var Pro3s = new CantPres { CantidadPres = Prod3 };

            await this.Navigation.PushModalAsync(new ResProd(Pro3s));
          
        }

        private async void btnSab2_Clicked(object sender, EventArgs e)
        {
            var cantiCAP = valCat;
            var presenCAP = valPres;
            var sabSap = btnSab2.Text;
            string[] Prod3 = new string[] { cantiCAP, presenCAP, sabSap };
            // var cantidadPP = new CantPres { Cantidad = cantiCAP };
            var Pro3s = new CantPres { CantidadPres = Prod3 };

            await this.Navigation.PushModalAsync(new ResProd(Pro3s));
        }

        private async void btnSab3_Clicked(object sender, EventArgs e)
        {
            var cantiCAP = valCat;
            var presenCAP = valPres;
            var sabSap = btnSab3.Text;
            string[] Prod3 = new string[] { cantiCAP, presenCAP, sabSap };
            // var cantidadPP = new CantPres { Cantidad = cantiCAP };
            var Pro3s = new CantPres { CantidadPres = Prod3 };

            await this.Navigation.PushModalAsync(new ResProd(Pro3s));
        }

        private async void btnSab4_Clicked(object sender, EventArgs e)
        {
            var cantiCAP  = valCat;
            var presenCAP = valPres;
            var sabSap    = btnSab4.Text;
            //var fecha = DateTime.Now.ToString("dd/MM/yy");
            //await DisplayAlert("Datos", fecha, "aceptar");
            string[] Prod3 = new string[] { cantiCAP, presenCAP, sabSap};
            // var cantidadPP = new CantPres { Cantidad = cantiCAP };
            var Pro3s = new CantPres { CantidadPres = Prod3 };

            await this.Navigation.PushModalAsync(new ResProd(Pro3s));
        }

    }
}