using MyToDo.Models;
using MyToDo.Services;
using MyToDo.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyToDo.Viewmodels
{
    public class TodoListViewmodel:BaseViewmodel
    {

        public ObservableCollection<Todo> TodoList { get; set; }
        public Todo SelectedTodo { get; set; }

        public Command DeleteCommand { get; set; }
        public Command AddCommand { get; set; }

        public Command RefreshCommand { get; set; }
        public Command RestoreCommand { get; set; }



        

        public TodoListViewmodel()
        {

            DeleteCommand = new Command(DeleteTodoAsync);
            AddCommand = new Command(GotoAddPage);
            RefreshCommand = new Command(RefreshAsync);
            RestoreCommand = new Command(RestoreAsync);

            IsBusy = false;


            PageTitle = "Todo List";

            TodoList = new ObservableCollection<Todo>();

            GetDataAsync();


        }

        async Task GetDataAsync()
        {
            var TodoFromDatastore = await DataStore.GetAllTodoAsync();

            TodoList.Clear();
            foreach (var todo in TodoFromDatastore)
            {
                TodoList.Add(todo);
            }
        }

        async void RefreshAsync()
        {
            IsBusy = true;
            await GetDataAsync();
            IsBusy = false;
        }

        public void OnAppearing()
        {
            GetDataAsync();
        }

        public void GotoAddPage()
        {
            App.Current.MainPage.Navigation.PushAsync(new AddTodoView());
        }

        async public void DeleteTodoAsync()
        {

            if (SelectedTodo != null)
            {
                await DataStore.DeleteTodoAsync(SelectedTodo);
                await GetDataAsync();
                SelectedTodo = null;
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Delete", "Geen item geselecteerd", "OK");
            }

        }

        async public void RestoreAsync()
        {
            await DataStore.RestoreAsync();
            GetDataAsync();
        }

    }
}
