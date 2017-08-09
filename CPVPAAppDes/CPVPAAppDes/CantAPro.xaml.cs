using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PCLStorage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CPVPAAppDes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CantAPro : ContentPage
    {
        
        int numsaltos = 0;
        Button CapBtn = new Button
        {
            Text = "Otra",
            TextColor = Color.White,
            ClassId = "btnCantOthe",
            BackgroundColor = Color.FromHex("#929ABE"),
            WidthRequest = 100,
            HeightRequest = 100
        };
        public CantAPro()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Device.BeginInvokeOnMainThread(async () =>
            {
                var client = new HttpClient();
                var response = await client.GetAsync("https://wscpvpad.000webhostapp.com/WSCPVPA/rest/requestCantProd.php");
                string JSON = await response.Content.ReadAsStringAsync();

                if (JSON != null && JSON != "")
                {
                    //Deserialización del Json
                    cantidadProducir cant = JsonConvert.DeserializeObject<cantidadProducir>(JSON);
                    //Definicion de fila y columna del grid
                    ColumnDefinition Columna = new ColumnDefinition
                    {
                        Width = new GridLength(1, GridUnitType.Star)                        
                    };
                    RowDefinition fila = new RowDefinition
                    {
                        Height = new GridLength(50, GridUnitType.Absolute)
                    };
                    //Crea un Grid que contiene dos botones
                    Grid grid = new Grid
                    {
                        ColumnDefinitions = { Columna },
                        RowDefinitions = { fila }
                    };
                    //Lim´piar layout
                    vista.Children.Clear();
                    //Variables para controlar posición de fila y columna para cada botón
                    int nfila = 0, ncolumna = 0,element = 0;
                    //establecer numero de grupos de botónes pór fila
                    int numbuttons = cant.cantidadProd.Count;
                    if ((numbuttons % 2) == 0)
                    {
                        numsaltos = numbuttons - (numbuttons / 2);
                    }
                    else
                        numsaltos = 1;

                    //For para crear filas de botones
                    for (int i = 0; i< cant.cantidadProd.Count; i += numsaltos)
                    {
                        

                        if ((numbuttons % 2) == 0)
                        {
                            //Crea botones en pares
                            Button b1 = new Button
                            {
                                Text = cant.cantidadProd[i].ToString(),
                                TextColor = Color.White,
                                ClassId = "btn" + i,
                                BackgroundColor = Color.FromHex("#8890B5")
                            };
                            var canti1CAP = Int32.Parse(cant.cantidadProd[element]);

                            //Se le agrega el evento clicked a la popiedad clicked del botón
                            b1.Clicked += delegate {
                                var cantidadPP = new CantidadProd { Cantidad = canti1CAP };
                                this.Navigation.PushModalAsync(new SelecSabor(cantidadPP));
                            };
                            grid.Children.Add(b1, nfila, 0);

                            //definición de segundo botón
                            Button b2 = new Button
                            {
                                Text = cant.cantidadProd[i + 1].ToString(),
                                TextColor = Color.White,
                                ClassId = "btnCant" + i + 1,
                                BackgroundColor = Color.FromHex("#8890B5")
                            };

                            //da valor del elemento
                            element += 1;
                            var canti2CAP = Int32.Parse(cant.cantidadProd[element]);
                            //Se le agrega el evento clicked a la popiedad clicked del botón
                            b2.Clicked += delegate {
                                var cantidadPP = new CantidadProd { Cantidad = canti2CAP };
                                this.Navigation.PushModalAsync(new SelecSabor(cantidadPP));
                            };
                            grid.Children.Add(b2, nfila, 1);
                            //Se eliminan
                        }
                        else //En caso que el numero de botones sea impar crea de uno en uno pero el numero de columna cambia
                        {
                            if ((i % 2) == 0)
                                ncolumna = 1;
                            else
                                ncolumna = 0;
                            Button b1 = new Button
                            {
                                Text = cant.cantidadProd[i].ToString(),
                                TextColor = Color.White,
                                ClassId = "btn" + i,
                                BackgroundColor = Color.FromHex("#8890B5")
                            };
                            var canti1CAP = Int32.Parse(cant.cantidadProd[element]);

                            //Se le agrega el evento clicked a la popiedad clicked del botón
                            b1.Clicked += delegate {
                                var cantidadPP = new CantidadProd { Cantidad = canti1CAP };
                                this.Navigation.PushModalAsync(new SelecSabor(cantidadPP));
                            };
                            grid.Children.Add(b1, nfila, ncolumna);
                        }

                        element += 1;
                        //Incremento en fila
                        nfila += 1;
                        vista.Children.Add(grid);
                    }
                    element += 1;
                }
                //Si el JSON viene vacio, crea un label con un mensaje
                else
                {
                    Label lbAlert = new Label
                    {
                        Text = "Recurso = null!!!",
                        TextColor = Color.Red
                    };
                    vista.Children.Add(lbAlert);
                }

                CapBtn.Clicked += btnCantOthe_Clicked;
                vista.Children.Add(CapBtn);
            });
        }
        private void btnCantOthe_Clicked(object sender, EventArgs e)
        {
            var cantiCAP = CapBtn.Text;
            this.Navigation.PushModalAsync(new SelecOtrCan());
        }
    }
}