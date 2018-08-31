using SWAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SWAPI.ViewModels
{
	public class BaseViewModel : ContentView
	{
        public SwaAPI Api => new SwaAPI();
        public INavigation Navigation => Application.Current.MainPage.Navigation;

        public ICommand RefreshCommand { get; set; }
        public ICommand ItemClickCommand { get; set; }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }

        public BaseViewModel(string title)
        {
            Title = title;
        }

        public Task ShowAlertAsync(string title, string msg, string cancel)
            => Application.Current.MainPage.DisplayAlert(title, msg, cancel);

        public virtual Task Initialize(object parameters = null)
            => Task.FromResult(true);
    }
}