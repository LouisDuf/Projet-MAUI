using BookApp.ViewModel;
using VMWrapper;

namespace BookApp.Composants
{
    public partial class CollectionFiltrage : ContentView
    {
        public CollectionFiltrage()
        {
            InitializeComponent();
        }

        public CollectionFiltrage(FilterViewModel data)
            : this()
        {
            BindingContext = data;
        }
    }
}
