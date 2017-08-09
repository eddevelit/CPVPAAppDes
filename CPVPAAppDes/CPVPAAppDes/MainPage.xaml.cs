using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PCLStorage;

namespace CPVPAAppDes
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
         
        }
        protected  override void OnAppearing()
        {
            base.OnAppearing();
            Device.BeginInvokeOnMainThread(async () =>
            {
                //RestClient client = new RestClient();
                //var wingetresult = await client.Get<WingetResult>("https://api-codigos-postales.herokuapp.com/v2/codigo_postal/66436");//linea antigua  no su esta usando
                var client = new HttpClient();
                var response = await client.GetAsync("http://wscpvpad.000webhostapp.com/WSCPVPA/rest/requestSabor.php");
                string JSON = await response.Content.ReadAsStringAsync();
                //WingetResult DatosDireccion = new WingetResult();
                
                if (JSON != null && JSON != "")
                {
                    
                    //var datos = wingetresult.NOM_SABOR;
                    //var otroDato = datos.ToString();
                    //LabelChange.Text = otroDato;
                    //LabelChange.Text = "winget result = dentro!!!";
                    //StreamReader sr = new StreamReader(wingetresult);
                    ///LabelChange.Text = "winget result = contenido!!!";
                    //var dato = wingetresult.estado;
                    //LabelChange.Text = "winget result = procesado!!!";
                    //var tipo = dato.GetType();
                    //LabelChange.Text = dato.ToString();
                    //LabelChange1.Text = "Llega al final";
                    
                    
                        //Binding listview with server response 
                        Sabor sabores = JsonConvert.DeserializeObject<Sabor>(JSON);
                        LabelChange.Text = "Sabores: " + sabores.sabores.ElementAt(1).NOM_SABOR;
                }
                else
                {
                    LabelChange.Text = "winget result = null!!!";
                }
            });
        }
    }
}
