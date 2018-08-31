using SWAPI.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SWAPI.ViewModels
{
	public class RootViewModel : BaseViewModel
    {
        private string _category;
        public string Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value; OnPropertyChanged();
            }
        }

        private Root _joke = new Root();
        public Root Joke
        {
            get
            {
                return _joke;
            }
            set
            {
                _joke = value; OnPropertyChanged();
            }
        }

        private Movies _movie = new Movies();
        public Movies Movies
        {
            get
            {
                return _movie;
            }
            set
            {
                _movie = value; OnPropertyChanged();
            }
        }

        public RootViewModel() : base("")
        {
        }

        public override async Task Initialize(object parameters)
        {
            Category = parameters as string;
            Title = Category;

            await LoadData();
        }

        async Task LoadData()
        {
            if (IsBusy)
                return;

            Exception error = null;

            try
            {
                IsBusy = true;
                var allInformations = await Api.GetRandomJokeByCategoyAsync();
                foreach (var information in allInformations)
                    foreach (var info in information.results)
                        if (Category.Equals(info.name))
                        {
                            Random rand = new Random();
                            int size = info.films.Count;
                            int position = rand.Next(0, size);
                            Movies = await Api.GetMovieByPersonAsync(info.films[position]);
                        }

                // Joke = Joke;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex);
                error = ex;
            }
            finally
            {
                IsBusy = false;
            }

            if (error != null)
                await ShowAlertAsync("Error!", error.Message, "OK");
        }
    }
}