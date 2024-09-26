using BookApp.ViewModel;
using System.Windows.Input;
using VMWrapper;

namespace BookApp.Pages
{
    public partial class EmpruntsPrets : ContentPage
    {
        public ViewModelNavigation Nav { get; } = new ViewModelNavigation();

        public EmpruntsPrets(BooksViewModel data)
        {
            InitializeComponent();
            BindingContext = data;
        }
    }
}
