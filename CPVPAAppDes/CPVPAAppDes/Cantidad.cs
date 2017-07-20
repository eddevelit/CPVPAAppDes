using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;


namespace CPVPAAppDes
{
    class Cantidad
    {
        [PrimaryKey, AutoIncrement]
        public int IdCant { get; set; }
        public String CantDesc { get; set; }

        public override string ToString()
        {
            return String.Format( "{ 0}{ 1}",IdCant,CantDesc );
        }
    }

}
