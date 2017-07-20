using CPVPAAppDes.ORM;
using DevAzt.FormsX.Storage.SQLite.LiteConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAzt.FormsX.Storage.SQLite.StandarDB
{
    public class LocalDB : DataBase
    {
        //Se crean las tablas de la BD
       public Table<Produccion> Produccion { get; set; }

        public LocalDB(string databasePath, bool storeDateTimeAsTicks = true) : base(databasePath, storeDateTimeAsTicks)
        {
            Produccion = DBSet<Produccion>();
        }
        public static LocalDB Instance
        {
            get
            {
                var service = Xamarin.Forms.DependencyService.Get<IDataBase>();
                if (service != null)
                {
                    return service.GetDataBase();
                }
                throw new Exception("No es posible obtener el servicio");
            }
        }
    }
}
