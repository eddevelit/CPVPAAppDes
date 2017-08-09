using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPVPAAppDes
{
  public class cantidadProducir
    {
        public List<string> cantidadProd { get; set; }
    }



    public class WingetResult

    {
        public string IDSabor { get; set; }
        public string NOM_SABOR { get; set; }
        //
        //public Array data { get; set; }
        /*public string codigo_postal { get; set; }
        public string municipio { get; set; }
        public string estado { get; set; }
        public List<string> colonias { get; set; }*/
    }

    public class Sabor
    {
        public List<WingetResult> sabores { get; set; }
    }

    public class BlobIMA
    {
        public byte[] Imagen { get; set; }
    }

}
