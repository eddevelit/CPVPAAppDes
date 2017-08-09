using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DevAzt.FormsX.Storage.SQLite.StandarDB;
using DevAzt.FormsX.Storage.SQLite.LiteConnection;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using Java.IO;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using static Android.Views.LayoutInflater;
using PCLStorage;

namespace CPVPAAppDes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelecSabor : ContentPage
    {
        int numsaltos = 0;
        string cantiCAP = "", sabSap ="", IDsabor ="", url ="", base64string;
        Stream bytemapJSON;
        StreamReader reader;
        JToken token;
        /*ImageSource retSource = null;
        BlobIMA BlobRequest = null;*/
        Byte[] blob;
        CrossplataformFiles fileCross;
        public SelecSabor(CantidadProd ValArray)
        {

            BindingContext = ValArray;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            //Definiendo Acceso a libresrías compartidas PCLS
            fileCross = new CrossplataformFiles();

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
            //Define imagen
            
            
            Xamarin.Forms.Image beachImage = new Xamarin.Forms.Image { Aspect = Aspect.AspectFit, WidthRequest = 200,HeightRequest = 150 };
            //Limpiar Layout
            VistaSabores.Children.Clear();
            base.OnAppearing();
            Device.BeginInvokeOnMainThread(async () =>
            {
                var client = new HttpClient();
                
                var response = await client.GetAsync("https://wscpvpad.000webhostapp.com/WSCPVPA/rest/requestSabor.php");
                string JSON = await response.Content.ReadAsStringAsync();
                
                //sE ESTABLECE MAXIMO DE BUFFER PARA LAS IMAGENES
                //client.MaxResponseContentBufferSize = 256000;
                //
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tocken);

                //sE VAALIDA QUE LA RESPUESTA NO VENGA VACIA
                if (JSON != null && JSON != "")
                {
                    //Deserialización del Json
                    Sabor SaborRequest = JsonConvert.DeserializeObject<Sabor>(JSON);
                    //Variables para controlar posición de fila y columna para cada botón 
                    int nfila = 0, ncolumna = 0, element = 0;
                    //establecer numero de grupos de botónes pór fila
                    int numbuttons = SaborRequest.sabores.Count;
                    if ((numbuttons % 2) == 0)
                    {
                        numsaltos = numbuttons - (numbuttons / 2);
                    }
                    else
                        numsaltos = 1;

                    //For para crear filas de botones
                    for (int i = 0; i < SaborRequest.sabores.Count; i += numsaltos)
                    {

                        string nombreImage = SaborRequest.sabores[i].NOM_SABOR.ToString();
                        if ((numbuttons % 2) == 0)
                        {
                            //Request para imagen
                            IDsabor = SaborRequest.sabores[i].IDSabor;
                            url = "https://wscpvpad.000webhostapp.com/WSCPVPA/rest/requestImageSabor.php?id=" + IDsabor;
                            //Request de imágen
                            bytemapJSON = await client.GetStreamAsync(url);
                            //se prepara un lector para el buffer
                            reader = new StreamReader(bytemapJSON);
                            token = JObject.Parse(reader.ReadToEnd().ToString());
                            base64string = token.SelectToken("Imagen").ToString();
                            //Se decodifica el base64 a un string
                            blob = Convert.FromBase64String(base64string);
                            //se libera recursos
                            bytemapJSON.Dispose();
                            beachImage.Source = ImageSource.FromStream(() => new MemoryStream(blob));
                            bytemapJSON.Write(blob, 0, blob.Length);
                            //FileImageSource.FromStream(Func<Stream> bytemapJSON);
                            //Crea botones en pares
                            Button btnSabor1 = new Button
                            {
                                Text = nombreImage,
                                TextColor = Xamarin.Forms.Color.White,
                                ClassId = "btn" + i,
                                BackgroundColor = Xamarin.Forms.Color.FromHex("#8890B5")
                            };
                            //btnSabor1.Image = (FileImageSource)(StreamImageSource.FromStream(() => new MemoryStream(blob)));// ImageSource.FromStream(() => new MemoryStream(blob));
                            sabSap = nombreImage;
                            cantiCAP = CantPreseprod.Text;
                            btnSabor1.Image = "";

                            //savingfile
                            fileCross.saveFilePCS(sabSap, blob);


                            btnSabor1.Image = "/Storage/emulated/0/Android/data/myApp.Droid/files/Pictures/"+ sabSap + ".png";
                                //Se le agrega el evento clicked a la popiedad clicked del botón
                                btnSabor1.Clicked += delegate
                                {
                                    string[] catAndPre = new string[] { cantiCAP, sabSap };

                                    var cantidadPP = new CantPres { CantidadPres = catAndPre };

                                    this.Navigation.PushModalAsync(new PreseProd(cantidadPP));
                                };
                            grid.Children.Add(btnSabor1, nfila, 0);
                            grid.Children.Add(beachImage, 0, 0);
                            //Cambiar nombre del segundo botón
                            nombreImage = SaborRequest.sabores[i + 1].NOM_SABOR.ToString();
                            //Request para imagen
                            IDsabor = SaborRequest.sabores[i+1].IDSabor;
                            //URL
                            url = "https://wscpvpad.000webhostapp.com/WSCPVPA/rest/requestImageSabor.php?id=" + IDsabor;
                            //Petición
                            bytemapJSON = await client.GetStreamAsync(url);
                            /*reader = new StreamReader(bytemapJSON);
                            token = JObject.Parse(reader.ReadToEnd().ToString());
                            base64string = token.SelectToken("Imagen").ToString();
                            blob = Convert.FromBase64String(base64string);
                            bytemapJSON.Dispose();*/
                            /*JSON = await response.Content.ReadAsStringAsync();
                            //Deserializando JSON
                            BlobRequest = JsonConvert.DeserializeObject<BlobIMA>(JSON);*/
                            //Crear imágen d botón 1
                            //definición de segundo botón
                            Button btnSabor2 = new Button
                            {
                                Text = nombreImage,
                                TextColor = Xamarin.Forms.Color.White,
                                ClassId = "btnCant" + i + 1,
                                BackgroundColor = Xamarin.Forms.Color.FromHex("#8890B5")
                            };

                            //da valor del elemento
                            element += 1;
                            sabSap = nombreImage;
                            cantiCAP = CantPreseprod.Text;
                            //Se le agrega el evento clicked a la popiedad clicked del botón
                            btnSabor2.Clicked += delegate
                            {
                                string[] catAndPre = new string[] { cantiCAP, sabSap };

                                var cantidadPP = new CantPres { CantidadPres = catAndPre };

                                this.Navigation.PushModalAsync(new PreseProd(cantidadPP));
                            };
                            grid.Children.Add(btnSabor2, nfila, 1);
                            //grid.Children.Add(beachImage, nfila, 1);
                        }
                        else //En caso que el numero de botones sea impar crea de uno en uno pero el numero de columna cambia
                        {

                            //Request para imagen
                            IDsabor = SaborRequest.sabores[i].IDSabor;
                            url = "https://wscpvpad.000webhostapp.com/WSCPVPA/rest/requestImageSabor.php?id=" + IDsabor;
                            bytemapJSON = await client.GetStreamAsync(url);
                            reader = new StreamReader(bytemapJSON);
                            token = JObject.Parse(reader.ReadToEnd().ToString());
                            base64string = token.SelectToken("Imagen").ToString();
                            blob = Convert.FromBase64String(base64string);
                            bytemapJSON.Dispose();
                            //beachImage.Source = retSource;

                            if ((i % 2) == 0)
                                ncolumna = 1;
                            else
                                ncolumna = 0;
                            Button btnSabor1 = new Button
                            {
                                Text = nombreImage,
                                TextColor = Xamarin.Forms.Color.White,
                                ClassId = "btn" + i,
                                BackgroundColor = Xamarin.Forms.Color.FromHex("#8890B5")
                            };
                            sabSap = nombreImage;
                            cantiCAP = CantPreseprod.Text;

                            //Se le agrega el evento clicked a la popiedad clicked del botón
                            btnSabor1.Clicked += delegate
                            {
                                string[] catAndPre = new string[] { cantiCAP, sabSap };

                                var cantidadPP = new CantPres { CantidadPres = catAndPre };

                                this.Navigation.PushModalAsync(new PreseProd(cantidadPP));
                            };
                            grid.Children.Add(btnSabor1, nfila, ncolumna);

                            element += 1;
                        }//Fin del ELSE PARA NUMERO DE ELEMENTOS IMPAR
                         //Incremento en fila
                        nfila += 1;
                        VistaSabores.Children.Add(grid);
                        //element += 1;
                    }//FIN DEL FOR PARA LOS BOTONES
                }//FIN DEL IF  QUE VALIDA EL JSON
                //Si el JSON viene vacio, crea un label con un mensaje
                else
                {
                    Label lbAlert = new Label
                    {
                        Text = "Recurso = null!!!",
                        TextColor = Xamarin.Forms.Color.Red
                    };
                    VistaSabores.Children.Add(lbAlert);
                }
            });
        }
        /*private async void btnSab1_Clicked(object sender, EventArgs e)
        {
            var cantiCAP = CantPreseprod.Text;
            var sabSap = "Jamaica";
            string[] catAndPre = new string[] { cantiCAP, sabSap };

            var cantidadPP = new CantPres { CantidadPres = catAndPre };

            await this.Navigation.PushModalAsync(new PreseProd(cantidadPP));

        }

        private async void btnSab2_Clicked(object sender, EventArgs e)
        {

            var cantiCAP = CantPreseprod.Text;
            var sabSap = "Horchata";
            string[] catAndPre = new string[] { cantiCAP, sabSap };

            var cantidadPP = new CantPres { CantidadPres = catAndPre };

            await this.Navigation.PushModalAsync(new PreseProd(cantidadPP));

        }

        private async void btnSab3_Clicked(object sender, EventArgs e)
        {
            var cantiCAP = CantPreseprod.Text;
            var sabSap = "Mango";
            string[] catAndPre = new string[] { cantiCAP, sabSap };

            var cantidadPP = new CantPres { CantidadPres = catAndPre };

            await this.Navigation.PushModalAsync(new PreseProd(cantidadPP));
        }

        private async void btnSab4_Clicked(object sender, EventArgs e)
        {
            var cantiCAP = CantPreseprod.Text;
            var sabSap = "Simple";
            string[] catAndPre = new string[] { cantiCAP, sabSap };

            var cantidadPP = new CantPres { CantidadPres = catAndPre };

            await this.Navigation.PushModalAsync(new PreseProd(cantidadPP));
        }*/

    }
}