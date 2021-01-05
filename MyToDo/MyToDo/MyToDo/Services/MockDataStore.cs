using MyToDo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Services
{
    class MockDataStore:IDataStore
    {

        public List<Todo> TodoList { get; set; }


        public MockDataStore()
        {

            MockData();
        }

        public void MockData()
        {
            TodoList = new List<Todo>();

            TodoList.Add(new Todo() { Title = "Shop", Description = "Go Shopping" });
            TodoList.Add(new Todo() { Title = "Pay", Description = "You have to pay" });
            TodoList.Add(new Todo() { Title = "Home", Description = "Go Home" });
        }

        async public Task RestoreAsync()
        {
            MockData();
        }

        public Task<List<Todo>> GetAllTodoAsync()
        {
            return Task.FromResult(TodoList);
        }

        public Task<String> AddTodoAsync(Todo todo)
        {
            TodoList.Add(todo);
            return Task.FromResult("");
        }

        public Task<string> DeleteTodoAsync(Todo todo)
        {
            TodoList.Remove(todo);
            return Task.FromResult("");
        }
    }
}
