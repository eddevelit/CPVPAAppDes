using DevAzt.FormsX.Storage.SQLite.LiteConnection;
using DevAzt.FormsX.Storage.SQLite.StandarDB;
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

        public static LocalDB DB { get; private set; }
        String valCat;
        String valsabor;
        public PreseProd(CantPres CantidadPresO)
        {
            InitializeComponent();

            string[] ValArray = CantidadPresO.CantidadPres.ToArray();
            valCat = ValArray[0];
            valsabor = ValArray[1];
            
            BindingContext = valCat.ToString();
            BindingContext = valsabor.ToString();
        }

       /* private async void btnPres_Clicked(object sender, EventArgs e)
        {
            var cantiCAP = CantProd.Text;
            var presenCAP = btnPres1.Text;
            string[] catAndPre =  new string []{ cantiCAP ,presenCAP};
            var cantidadPP = new CantPres { CantidadPres = catAndPre } ;
            //await this.Navigation.PushModalAsync(new SelecSabor(cantidadPP));
           
        }*/

        private async void btnPres1_Clicked(object sender, EventArgs e)
        {
            var cantiCAP = valCat;
            var presenCAP = btnPres1.Text;
            string fecha = DateTime.Now.ToString("dd/MM/yy");
            Keys.DataBaseName = "prueba.db3";
            PreseProd.DB = LocalDB.Instance;
            PreseProd.DB.Produccion.Add(new ORM.Produccion
            {
                Cantidad = int.Parse(cantiCAP),
                Presentacion = presenCAP,
                Sabor = valsabor,
                Fecha = fecha

            });
            PreseProd.DB.SaveChanges();
            await this.Navigation.PushModalAsync(new SeleccionaInicio());
        }

        private async void btnPres2_Clicked(object sender, EventArgs e)
        {
            var cantiCAP = valCat;
            var presenCAP = btnPres2.Text;
            string fecha = DateTime.Now.ToString("dd/MM/yy");
            Keys.DataBaseName = "prueba.db3";
            PreseProd.DB = LocalDB.Instance;
            PreseProd.DB.Produccion.Add(new ORM.Produccion
            {
                Cantidad = int.Parse(cantiCAP),
                Presentacion = presenCAP,
                Sabor = valsabor,
                Fecha = fecha

            });
            PreseProd.DB.SaveChanges();

            await this.Navigation.PushModalAsync(new SeleccionaInicio());
        }

        private async void btnPres3_Clicked(object sender, EventArgs e)
        {
            var cantiCAP = valCat;
            var presenCAP = btnPres3.Text;
            string fecha = DateTime.Now.ToString("dd/MM/yy");
            Keys.DataBaseName = "prueba.db3";
            PreseProd.DB = LocalDB.Instance;
            PreseProd.DB.Produccion.Add(new ORM.Produccion
            {
                Cantidad = int.Parse(cantiCAP),
                Presentacion = presenCAP,
                Sabor = valsabor,
                Fecha = fecha

            });
            PreseProd.DB.SaveChanges();

            await this.Navigation.PushModalAsync(new SeleccionaInicio());
        }

        private async void btnPres4_Clicked(object sender, EventArgs e)
        {
            var cantiCAP = valCat;
            var presenCAP = btnPres4.Text;
            string fecha = DateTime.Now.ToString("dd/MM/yy");
            Keys.DataBaseName = "prueba.db3";
            PreseProd.DB = LocalDB.Instance;
            PreseProd.DB.Produccion.Add(new ORM.Produccion
            {
                Cantidad = int.Parse(cantiCAP),
                Presentacion = presenCAP,
                Sabor = valsabor,
                Fecha = fecha

            });
            PreseProd.DB.SaveChanges();

            await this.Navigation.PushModalAsync(new SeleccionaInicio());
        }

        /*private async void btnPres5_Clicked(object sender, EventArgs e)
        {
            var cantiCAP = CantProd.Text;
            var presenCAP = btnPres5.Text;
            string[] catAndPre = new string[] { cantiCAP, presenCAP };

            var cantidadPP = new CantPres { CantidadPres = catAndPre };
        }*/

        /*private async void btnPres6_Clicked(object sender, EventArgs e)
        {
            var cantiCAP = CantProd.Text;
            var presenCAP = btnPres6.Text;
            string[] catAndPre = new string[] { cantiCAP, presenCAP };

            var cantidadPP = new CantPres { CantidadPres = catAndPre };

            //await this.Navigation.PushModalAsync(new SelecSabor(cantidadPP));

        }*/
    }
}