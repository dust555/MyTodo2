using MyToDo.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace MyToDo.Viewmodels
{
    public class BaseViewmodel:INotifyPropertyChanged
    {

        public IDataStore DataStore => DependencyService.Get<IDataStore>();


        public String PageTitle { get; set; }

        Boolean _isBusy;
        public Boolean IsBusy { get { return _isBusy; } set { _isBusy = value; OnPropertyChanged(); } }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
