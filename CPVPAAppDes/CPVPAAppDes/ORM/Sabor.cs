using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPVPAAppDes.ORM
{
    class Sabor
    {
        [PrimaryKey, AutoIncrement]
        public int IdSabor { get; set; }
        public string DescSabor { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}{1}]", IdSabor,DescSabor);
        }
    }
}
