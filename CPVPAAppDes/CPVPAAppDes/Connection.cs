using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using Xamarin.Forms;
using System.IO;
using DevAzt.FormsX.Storage.SQLite.LiteConnection;
using DevAzt.FormsX.Storage.SQLite.StandarDB;



namespace CPVPAAppDes
{
    class Connection
    {
        //private object ex;

        //private string CreateDatabase(String path) {
        //    try {
        //        var connection = new SQLiteAsyncConnection(path);
        //        connection.CreateTableAsync<Produccion>();
        //        return "Databas was created";

        //    }
        //    catch(Exception ex)
        //        {
        //        return ex.Message;
        //    }

        //}
        //public String InsertData(Produccion data,String path) {
        //    try {
        //        var db = new SQLiteAsyncConnection(path);
        //        db.InsertAsync(data);
        //           // db.UpdateAsync(data);
        //        return "Single data was insert";
        //    } catch (Exception ex) {
        //        return ex.Message;
        //    }
        // }
        //public String findNumber(Produccion data, String path)
        //{
        //    try
        //    {
        //        var db = new SQLiteAsyncConnection(path);
        //        var conut = db.ExecuteScalarAsync<int>("SELECT Coutn(*) FROM Produccion");
        //        // db.UpdateAsync(data);
        //       // var sendVar = String.Format(conut);
        //     //  if(conut>0)
        //        return "completado";
        //    }
        //    catch 
        //    {
               
        //        return "it couldn´t to find ";
        //    }
        //}
        //public  List<Produccion> GetProducciones(Produccion data, String path)//método obtener ServeralProd 
        //{
        //     var db = new SQLiteAsyncConnection(path);
        //    //return db.Table<Produccion>().OrderBy(c => c.IdProduccion).ToListAsync();
        //    return "is done";
        //}
    }
}
