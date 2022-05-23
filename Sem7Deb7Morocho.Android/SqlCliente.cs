using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.IO;
using Sem7Deb7Morocho.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(SqlCliente))]

namespace Sem7Deb7Morocho.Droid
{
    public class SqlCliente : Database
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var psth = Path.Combine(documentPath, "uisrael.db3");
            return new SQLiteAsyncConnection(psth);
        }
    }
}