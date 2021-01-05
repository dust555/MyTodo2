using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyToDo.Services;
using SQLite;

namespace MyToDo.Droid
{
    class SQLiteDatabase_Android : ISQLiteDatabase
    {
        public SQLiteAsyncConnection SQLiteDatabase { get; set; }

        public SQLiteDatabase_Android()
        {
            var basePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var dbName = "ToDo.db3";
            var dbPath = Path.Combine(basePath, dbName);

            SQLiteDatabase = new SQLiteAsyncConnection(dbPath);

        }

    }
}