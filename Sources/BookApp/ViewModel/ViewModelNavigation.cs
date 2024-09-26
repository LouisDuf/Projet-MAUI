using ToolKit;
using System.Windows.Input;
using System.Diagnostics;
using Model;
using System.Net;

namespace BookApp.ViewModel
{
    public class ViewModelNavigation : BaseViewModel
    {
        public INavigation Navigation { get; set; }

        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        // Command Pop
        public ICommand _backButtonCommand;
        public ICommand BackButtonCommand =>
            _backButtonCommand ??= new CommandPersonnal(
                async () => await BackButton(this, EventArgs.Empty)
            );

        // Command Collection livre
        public ICommand _bookDetailCommand;
        public ICommand BookDetailCommand =>
            _bookDetailCommand ??= new CommandPersonnal<string>(
                async (book) => await OnToItemDetail(book)
            );

        // Command Collection menu
        private ICommand _menuItemsCommand;
        public ICommand MenuItemsCommand =>
            _menuItemsCommand ??= new CommandPersonnal<ViewModelMenuItem>(
                async (item) => await OnItemSelected(item)
            );

        public ICommand _menuItemsFiltreCommand;
        public ICommand MenuItemsFiltreCommand =>
            _menuItemsFiltreCommand ??= new CommandPersonnal<ViewModelMenuItem>(
                async (item) => await OnItemSelected(item)
            );

        public ViewModelNavigation() { }

        private async Task OnItemSelected(ViewModelMenuItem selectedItem)
        {
            if (string.IsNullOrEmpty(selectedItem?.Route))
            {
                Debug.WriteLine("Route is null, cannot navigate.");
                return;
            }
            try
            {
                Title = selectedItem.Name;
                SelectTab(selectedItem.Route);

                var navigationParameter = new Dictionary<string, object> { { "Title", Title } };
                await Shell.Current.GoToAsync(selectedItem.Route, navigationParameter);

                Shell.Current.ForceLayout();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Navigation failed: {ex.Message}");
            }
        }

        private async Task OnToItemDetail(string bookId)
        {
            if (bookId == null)
            {
                Debug.WriteLine("Book is null, cannot navigate to details page.");
                return;
            }

            try
            {
                var navigationParameter = new Dictionary<string, object> { { "BookId", bookId } };
                await Shell.Current.GoToAsync($"DetailBookPage", navigationParameter);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Navigation failed: {ex.Message}");
            }
        }

        async Task BackButton(object sender, EventArgs args)
        {
            if (Shell.Current.Navigation.NavigationStack.Count > 1)
            {
                await Shell.Current.Navigation.PopAsync();
            }
        }

        private void SelectTab(string route)
        {
            var shellItem = Shell.Current.Items.FirstOrDefault(
                item => item.Items.Any(section => section.Route.Contains(route))
            );

            if (shellItem != null)
            {
                Shell.Current.CurrentItem = shellItem;
            }
        }
    }
}
