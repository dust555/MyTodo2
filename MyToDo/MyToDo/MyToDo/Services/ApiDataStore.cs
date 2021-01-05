using MyToDo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Services
{
    class ApiDataStore : IDataStore
    {
        public List<Todo> TodoList { get ; set; }

        public ApiDataStore()
        {
            TodoList = new List<Todo>();
        }

        async public Task RestoreAsync()
        {
            HttpClient client = new HttpClient();
            Debug.WriteLine("---------------------------------------------Start client");
            String json = await client.GetStringAsync("http://www.seamine.be/todoapi.php?restore=1");
            Debug.WriteLine("---------------------------------------------" + json);
        }

        async public Task<String> AddTodoAsync(Todo todo)
        {
            //TodoList.Add(todo);
            HttpClient client = new HttpClient();
            Debug.WriteLine("---------------------------------------------Start client");
            var content = new StringContent(JsonConvert.SerializeObject(todo));
            HttpResponseMessage responseMessage = await client.PostAsync("http://www.seamine.be/todoapi.php", content);
            String response = await responseMessage.Content.ReadAsStringAsync();
            Debug.WriteLine("---------------------------------------------" + response);

            return "";

        }

        async public Task<String> DeleteTodoAsync(Todo todo)
        {
            //TodoList.Add(todo);
            HttpClient client = new HttpClient();
            Debug.WriteLine("---------------------------------------------Start client");
            var content = new StringContent(JsonConvert.SerializeObject(todo));
            HttpResponseMessage responseMessage = await client.DeleteAsync("http://www.seamine.be/todoapi.php?id="+todo.Id);
            String response = await responseMessage.Content.ReadAsStringAsync();
            Debug.WriteLine("---------------------------------------------" + response);

            return "";
        }

        async public Task<List<Todo>> GetAllTodoAsync()
        {
            HttpClient client = new HttpClient();
            Debug.WriteLine("---------------------------------------------Start client");
            String json = await client.GetStringAsync("http://www.seamine.be/todoapi.php");
            Debug.WriteLine("---------------------------------------------"+json);

            TodoList = JsonConvert.DeserializeObject<List<Todo>>(json);

            return TodoList;

        }
    }
}
