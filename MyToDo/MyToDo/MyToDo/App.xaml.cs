using MyToDo.Services;
using MyToDo.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyToDo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<SQLiteDataStore>();
            //DependencyService.Register<MockDataStore>();

            MainPage = new NavigationPage(new TodoListView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
