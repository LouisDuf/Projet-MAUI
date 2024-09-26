using BookApp.ViewModel;
using System.Collections.ObjectModel;
using System.Diagnostics;
using VMWrapper;

namespace BookApp.Pages
{
    public partial class Tous : ContentPage
    {
        public ViewModelNavigation Nav { get; } = new ViewModelNavigation();

        public Tous(BooksViewModel data)
        {
            InitializeComponent();
            BindingContext = data;
        }
    }
}
