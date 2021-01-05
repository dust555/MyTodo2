using MyToDo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyToDo.Services
{
    class SQLiteDataStore : IDataStore
    {
        public List<Todo> TodoList { get; set; }

        public ISQLiteDatabase _db = DependencyService.Get<ISQLiteDatabase>();

        public SQLiteDataStore()
        {
            _db.SQLiteDatabase.CreateTableAsync<Todo>().Wait();
        }

        async public Task<string> AddTodoAsync(Todo todo)
        {
            await _db.SQLiteDatabase.InsertAsync(todo);
            return "";
        }

        async public Task<string> DeleteTodoAsync(Todo todo)
        {
            await _db.SQLiteDatabase.DeleteAsync(todo);
            return "";
        }

        public Task<List<Todo>> GetAllTodoAsync()
        {
            return _db.SQLiteDatabase.Table<Todo>().ToListAsync();
        }

        async public Task RestoreAsync()
        {
            await _db.SQLiteDatabase.ExecuteAsync("DELETE FROM Todo");
            await _db.SQLiteDatabase.InsertAsync(new Todo() { Title = "Shop", Description = "Go Shopping" });
            await _db.SQLiteDatabase.InsertAsync(new Todo() { Title = "Pay", Description = "You have to pay" });
            await _db.SQLiteDatabase.InsertAsync(new Todo() { Title = "Home", Description = "Go Home" });
        }
    }
}
