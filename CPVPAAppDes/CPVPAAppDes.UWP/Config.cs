using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using SQLite.Net.Interop;
using Xamarin.Forms;


//[assembly: Dependency(typeof(Produccion.WindowsPhone.Config))]
namespace CPVPAAppDes.UWP
{
    class Config : IConfig 
    {
        private string directorioBD;
        private ISQLitePlatform plataforma;

        public String DirectorioBD
        {
            get {
                if (String.IsNullOrEmpty(directorioBD))
                {
                 //   directorioBD = AplicationData.Current.Localfolder.Path;
            }
                return directorioBD;
        }
        

    }

        public string DirectorioDB => throw new NotImplementedException();

        public ISQLitePlatform Plataforma => throw new NotImplementedException();
    }
}
