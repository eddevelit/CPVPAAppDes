using DevAzt.FormsX.Storage.SQLite.LiteConnection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DevAzt.FormsX.Storage.SQLite.StandarDB;


namespace CPVPAAppDes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResProd : ContentPage
    {
        public static LocalDB DB { get; private set; }

        String dato1;
        String dato2;
        String dato3;

        public ResProd(CantPres pro3s)
        {
            String[] datos = pro3s.CantidadPres.ToArray();
             dato1 = datos[0];
             dato2 = datos[1];
             dato3 = datos[2];
            //DisplayAlert("Datos", dato1, "aceptar");
            //DisplayAlert("Datos", dato2, "aceptar");
            //DisplayAlert("Datos", dato3, "aceptar");
            ////======debas

            //Keys.DataBaseName = "prueba.db3";
            //ResProd.DB = LocalDB.Instance;


            ////=======
            InitializeComponent();
            // BindingContext = dato1;
            //PresProd.SetBinding(Label.TextProperty, new Binding(dato2));
            CatPro.Text = dato1;
            PresProd.Text = dato2;
            SabPro.Text = dato3;
            listaProduccion.ItemTemplate = new DataTemplate(typeof(ProduccionCell));
            Keys.DataBaseName = "prueba.db3";
            ResProd.DB = LocalDB.Instance;

            ResProd.DB.Produccion.Add(new ORM.Produccion
            {
                Cantidad = int.Parse(CatPro.Text),
                Presentacion = PresProd.Text,
                Sabor = SabPro.Text

            });
            ResProd.DB.SaveChanges();
            dato1 = "ok";
            DisplayAlert("Se inserto el registró  :", dato1, "aceptar");
            listaProduccion.ItemsSource = ResProd.DB.Produccion.ToList();

            //using (var data = new DataAccess())
            //{
            //    //listaProduccion.ItemsSource = data.GetProducciones();
            //}

        }

        private void BtnSubmit(object sender, EventArgs e)
        {


            //Produccion newProd = new Produccion
            //{

            //    Cantidad = int.Parse(CatPro.Text),
            //    Presentacion = PresProd.Text,
            //    Sabor = SabPro.Text
            //};
            //======debas
            /*
            Keys.DataBaseName = "prueba.db3";
            ResProd.DB = LocalDB.Instance;

            ResProd.DB.Produccion.Add(new ORM.Produccion
            {
                Cantidad = int.Parse(CatPro.Text),
                Presentacion = PresProd.Text,
                Sabor = SabPro.Text

            });
            ResProd.DB.SaveChanges();
            dato1 = "ok";
            DisplayAlert("Se inserto el registró  :", dato1, "aceptar");
            listaProduccion.ItemsSource = ResProd.DB.Produccion.ToList();
            */
            //=======



            //======================uso de inserciones de prueba==========
            //using (var data = new DataAccess() ) {
            //    data.InsertProduccion(newProd);
            //    dato1 = "ok";
            //    DisplayAlert("Se inserto el registró  :", dato1, "aceptar");
            //    listaProduccion.ItemsSource = data.GetProducciones();
            //}
            //String ruta = Environment.

            //var data = new Connection();
            //data.InsertData(newProd,);
        }
    }
}