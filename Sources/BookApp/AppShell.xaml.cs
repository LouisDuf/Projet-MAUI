using BookApp.Pages;

namespace BookApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("FiltragePage", typeof(Filtrage));
            Routing.RegisterRoute("TousPage", typeof(Tous));
            Routing.RegisterRoute("Mainpage", typeof(MainPage));
            Routing.RegisterRoute("EmpruntsPretsPage", typeof(EmpruntsPrets));
            Routing.RegisterRoute("DetailBookPage", typeof(DetailBook));
        }
    }
}
