﻿using MyToDo.Viewmodels;
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
    public partial class AddTodoView : ContentPage
    {
        public AddTodoView()
        {
            InitializeComponent();
            BindingContext = new AddTodoViewmodel();
        }
    }
}