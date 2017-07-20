//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using SQLite.Net;
//using Xamarin.Forms;
//using System.IO;
//using System.Collections;

//namespace CPVPAAppDes
//{//clase para implementacion y manupulacion de la informacion-
//   // class DataAccess:IDisposable//interfas generica para liberar  recursos.M
//    {
//        //private SQLiteConnection connection;//atributo para conexión

//        //public  DataAccess()//metodo"contructor de la clase" para hacer conexion
//        //{
//        //    var config = DependencyService.Get<IConfig>();//va i busca la config
//        //    connection = new SQLiteConnection(config.Plataforma,
//        //        Path.Combine(config.DirectorioDB, "RegistroProduccion.db3"));//Estabecer conexion
//        //                   //direct - metodo
//        //    connection.CreateTable<Produccion>();//crea a la tabla -no es compartido este codigo
//        //   //crea la tabla con base a Produccion
//        //}

//        //public void InsertProduccion(Produccion produccion)//método insert 
//        //{
//        //   connection.Insert(produccion);
//        //}

//        //public void UpdateProduccion(Produccion produccion)//método update 
//        //{
//        //    connection.Update(produccion);
//        //}
//        //public void DeleteProduccion(Produccion produccion)//método delite 
//        //{
//        //    connection.Delete(produccion);
//        //}

//        //public Produccion GetProduccion(int IdProduccion)//método obtener prod 
//        //{
//        //    return connection.Table<Produccion>().FirstOrDefault(c => c.IdProduccion == IdProduccion);
//        //    //regresa la produccion              primer-defecto    donde el id sea igual al atributo 
//        //    //se requiere importar using linq
//        //}
//        //public  List<Produccion> GetProducciones ()//método obtener ServeralProd 
//        //{
//        //    return connection.Table<Produccion>().OrderBy(c => c.IdProduccion).ToList();
//        //}
//        ////public List<Produccion> IdProduccion()//método obtener ServeralProd 
//        ////{
//        ////    return connection.Table<Produccion>().OrderBy(c => c.IdProduccion).Last();
//        ////}

//        //public void Dispose()//método para liberar recurso 
//        //{
//        //    connection.Dispose();
//        //} 

//    }
//}
