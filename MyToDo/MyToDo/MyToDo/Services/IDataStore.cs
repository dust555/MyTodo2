using MyToDo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Services
{
    public interface IDataStore
    {

        List<Todo> TodoList { get; set; }

        Task<List<Todo>> GetAllTodoAsync();

        Task<String> AddTodoAsync(Todo todo);

        Task<String> DeleteTodoAsync(Todo todo);

        Task RestoreAsync();



    }
}
