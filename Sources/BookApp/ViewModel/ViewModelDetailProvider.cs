using Model;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using ToolKit;
using VMWrapper;

namespace BookApp.ViewModel
{
    [QueryProperty(nameof(BookId), "BookId")]
    public class ViewModelDetailProvider : BaseViewModel
    {
        private readonly DetailBookViewModel _detailBookViewModel;

        private string _id;
        public string BookId
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                    LoadBookDetailAsync(_id);
                }
            }
        }

        private Book _bookDetail;
        public Book BookDetail
        {
            get => _bookDetail;
            set
            {
                _bookDetail = value;
                OnPropertyChanged();
            }
        }

        // Command Pop-up
        public ICommand _popUpCommand;
        public ICommand PopUpCommand => _popUpCommand ??= new CommandPersonnal(ShowPopUP);

        public ViewModelDetailProvider(DetailBookViewModel detailBookViewModel)
        {
            _detailBookViewModel =
                detailBookViewModel ?? throw new ArgumentNullException(nameof(detailBookViewModel));
        }

        private async void ShowPopUP()
        {
            string action = await DisplayActionSheet(
                "Quel est le statut du livre ?",
                "Cancel",
                null,
                "Finished",
                "Reading",
                "NotRead",
                "ToBeRead"
            );
            switch (action)
            {
                case "Finished":
                    BookDetail.Status = Status.Finished;
                    OnPropertyChanged(nameof(BookDetail));
                    _detailBookViewModel.UpdateColleciton();
                    break;

                case "Reading":
                    BookDetail.Status = Status.Reading;
                    OnPropertyChanged(nameof(BookDetail));
                    _detailBookViewModel.UpdateColleciton();
                    break;

                case "NotRead":
                    BookDetail.Status = Status.NotRead;
                    OnPropertyChanged(nameof(BookDetail));
                    _detailBookViewModel.UpdateColleciton();
                    break;

                case "ToBeRead":
                    BookDetail.Status = Status.ToBeRead;
                    OnPropertyChanged(nameof(BookDetail));
                    _detailBookViewModel.UpdateColleciton();
                    break;

                default:
                    BookDetail.Status = Status.Unknown;
                    OnPropertyChanged(nameof(BookDetail));
                    break;
            }
        }

        public async Task<string> DisplayActionSheet(
            string title,
            string cancel,
            string destruction,
            params string[] buttons
        )
        {
            return await Application.Current.MainPage.DisplayActionSheet(
                title,
                cancel,
                destruction,
                buttons
            );
        }

        private async Task LoadBookDetailAsync(string bookId)
        {
            if (string.IsNullOrWhiteSpace(_id))
                return;
            try
            {
                await _detailBookViewModel.LoadBookDetail(bookId);
                BookDetail = _detailBookViewModel.BookDetail;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
