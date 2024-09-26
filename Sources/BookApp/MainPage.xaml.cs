using BookApp.Pages;
using System.Collections.ObjectModel;
using BookApp.ViewModel;
using System.Diagnostics;

namespace BookApp
{
    public partial class MainPage : ContentPage
    {
        public ViewModelNavigation Nav { get; } = new ViewModelNavigation();

        public MainPage(ViewModelMenu data)
        {
            InitializeComponent();
            BindingContext = data;
        }
    }
}
