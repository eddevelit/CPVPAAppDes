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
    public partial class PreseProd : ContentPage
    {
        //public CantidadProd cantidadPP;

        //public PreseProd()
        //{
        //    InitializeComponent();
        //}

        //public PreseProd(CantidadProd cantidadPP)
        //{
        //    this.cantidadPP = cantidadPP;
        //}
        //public CantidadProd _cantidad { get; set; }

        public PreseProd(CantidadProd ValArray)
        {
            InitializeComponent();
            //  _cantidad = cantidad;
            BindingContext = ValArray;


        }

        private async void btnPres_Clicked(object sender, EventArgs e)
        {
            
            //var cantiCAP = Int32.Parse(CantPreseprod.Text);
            var cantiCAP = CantPreseprod.Text;
            var presenCAP = Picker.Items[Picker.SelectedIndex];
            string[] catAndPre =  new string []{ cantiCAP ,presenCAP};
            // var cantidadPP = new CantPres { Cantidad = cantiCAP };
            var cantidadPP = new CantPres { CantidadPres = catAndPre } ;
            //cantidadPP.CantidadPres = catAndPre;
            // var cantidadPP2 = new CantPres2 {  Present = presenCAP };
            //
            //if (string.IsNullOrEmpty(presenCAP))
            //{
            //    await DisplayAlert("Error", "Debe ingresar cantidad a producir", "aceptar");
            //    Picker.Focus();
            //    return;
            //}
            await this.Navigation.PushModalAsync(new SelecSabor(cantidadPP));
           
        }
    }
}