using SWAPI.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SWAPI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootPage : ContentPage
    {
        private RootViewModel _vm;
        public RootViewModel ViewModel
        {
            get
            {
                if (_vm == null)
                    _vm = new RootViewModel();

                BindingContext = _vm;

                return (BindingContext as RootViewModel);
            }
        }

        public RootPage()
        {
            InitializeComponent();
        }
    }
}