using BookApp.ViewModel;
using System.Diagnostics;
using VMWrapper;

namespace BookApp.Pages
{
    [QueryProperty(nameof(Title), "Title")]
    public partial class Filtrage : ContentPage
    {
        private readonly string Title;

        public ViewModelNavigation Nav { get; } = new ViewModelNavigation();

        public Filtrage(FilterViewModel data)
        {
            InitializeComponent();
            BindingContext = data;
        }
    }
}
