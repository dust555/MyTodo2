using MyToDo.Models;
using MyToDo.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyToDo.Viewmodels
{
    class AddTodoViewmodel:BaseViewmodel
    {

        public String Title { get; set; }
        public String Description { get; set; }

        public Command AddCommand { get; set; }


        public AddTodoViewmodel()
        {
            AddCommand = new Command(AddTodo);
            PageTitle = "Add Todo";
        }


        async public void AddTodo() {
            await DataStore.AddTodoAsync(new Todo() { Title = this.Title, Description = this.Description });
            await App.Current.MainPage.Navigation.PopAsync();
        }

    }
}
