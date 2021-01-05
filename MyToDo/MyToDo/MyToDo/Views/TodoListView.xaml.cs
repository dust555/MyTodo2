using MyToDo.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyToDo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoListView : ContentPage
    {

        TodoListViewmodel _viewmodel;

        public TodoListView()
        {
            InitializeComponent();
            BindingContext = _viewmodel = new TodoListViewmodel();
        }

        protected override void OnAppearing()
        {
            _viewmodel.OnAppearing();
        }


    }
}