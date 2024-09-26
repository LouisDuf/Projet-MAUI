using BookApp.ViewModel;
using VMWrapper;

namespace BookApp.Composants
{
    public partial class GroupCollection : ContentView
    {
        public ViewModelNavigation Nav { get; } = new ViewModelNavigation();

        public GroupCollection()
        {
            InitializeComponent();
        }

        public GroupCollection(BooksViewModel data)
            : this()
        {
            BindingContext = data;
        }
    }
}
