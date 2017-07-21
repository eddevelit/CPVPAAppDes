using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace CPVPAAppDes.ORM
{
    public class Produccion
    {
        [PrimaryKey, AutoIncrement]
        public int      IdProduccion { get; set; }
        public int      Cantidad { get; set; }
        public string   Presentacion { get; set; }
        public string   Sabor { get; set; }
        public string   Fecha { get; set; }
        /*
        public DateTime HoraMinutos { get; set; }
        public DateTime HoraMinutosSegundo { get; set; }
        public DateTime Hora { get; set; }
        public DateTime Minutos { get; set; }
        public DateTime Segundo { get; set; }
         */


        public override string ToString()
        {
            return string.Format("[{0}{1}{2}{3}{4}]", IdProduccion, Cantidad, Presentacion, Sabor,Fecha);
        }
    }
    
}
