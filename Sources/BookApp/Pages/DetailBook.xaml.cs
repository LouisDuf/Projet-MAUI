using BookApp.ViewModel;
using System.Diagnostics;

namespace BookApp.Pages
{
    public partial class DetailBook : ContentPage
    {
        public ViewModelNavigation Nav { get; } = new ViewModelNavigation();

        public DetailBook(ViewModelDetailProvider VMProvider)
        {
            InitializeComponent();
            BindingContext = VMProvider;
        }
    }
}
