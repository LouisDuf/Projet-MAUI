using System.Collections.ObjectModel;
using VMWrapper;

namespace BookApp.ViewModel
{
    public class ViewModelMenu
    {
        public ObservableCollection<ViewModelMenuItem> MenuItemsLivre { get; set; }
        public ObservableCollection<ViewModelMenuItem> MenuItemsFiltre { get; set; }

        public ViewModelMenu(BooksViewModel booksViewModel)
        {
            MenuItemsLivre = new ObservableCollection<ViewModelMenuItem>()
            {
                new ViewModelMenuItem(
                    "Tous",
                    "../Resources/Images/tray_2_fill.svg",
                    booksViewModel.TotalBooks,
                    "TousPage"
                ),
                new ViewModelMenuItem(
                    "En prêt",
                    "../Resources/Images/person_badge_clock_fill.svg",
                    null,
                    "EmpruntsPretsPage"
                ),
                new ViewModelMenuItem(
                    "À lire plus tard",
                    "../Resources/Images/arrow_forward.svg",
                    null,
                    ""
                ),
                new ViewModelMenuItem(
                    "Statut de lecture",
                    "../Resources/Images/eyeglasses.svg",
                    null,
                    ""
                ),
                new ViewModelMenuItem("Favoris", "../Resources/Images/heart_fill.svg", null, ""),
                new ViewModelMenuItem(
                    "Étiquettes",
                    "../Resources/Images/tag_fill.svg",
                    null,
                    "",
                    true
                ),
            };

            MenuItemsFiltre = new ObservableCollection<ViewModelMenuItem>()
            {
                new ViewModelMenuItem(
                    "Auteur",
                    "../Resources/Images/person_fill.svg",
                    booksViewModel.TotalAuthors,
                    "FiltragePage"
                ),
                new ViewModelMenuItem(
                    "Date de publication",
                    "../Resources/Images/calendar.svg",
                    null,
                    "FiltragePage"
                ),
                new ViewModelMenuItem("Note", "../Resources/Images/sparkles.svg", null, "", true),
            };
        }
    }
}
