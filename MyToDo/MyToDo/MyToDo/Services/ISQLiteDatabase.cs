using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyToDo.Services
{
    public interface ISQLiteDatabase
    {

        SQLiteAsyncConnection SQLiteDatabase { get; set; }

    }
}
