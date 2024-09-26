using Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using ToolKit;

namespace VMWrapper
{
    public class BooksViewModel : BaseViewModel
    {
        private readonly ILibraryManager data;
        private readonly IUserLibraryManager userLibraryManager;

        private long _totalBooks;
        public long TotalBooks
        {
            get { return _totalBooks; }
            set
            {
                _totalBooks = value;
                OnPropertyChanged();
            }
        }

        private long _totalAuthors;
        public long TotalAuthors
        {
            get { return _totalAuthors; }
            set
            {
                _totalAuthors = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<AuteurGroup> AuteurGroups { get; set; }

        private ICommand _removeBookCommand;
        public ICommand RemoveBookCommand =>
            _removeBookCommand ??= new CommandPersonnal<string>(
                async (bookId) => await RemoveBookById(bookId)
            );

        public BooksViewModel(ILibraryManager data, IUserLibraryManager userLibraryManager)
        {
            this.data = data;
            this.userLibraryManager = userLibraryManager;
            AuteurGroups = new ObservableCollection<AuteurGroup>();
            LoadBooksAsync();
        }

        public async Task LoadBooksAsync()
        {
            try
            {
                var (totalA, authors) = await data.GetAuthorsByName("", 0, 5);
                TotalAuthors = totalA;

                foreach (Author author in authors)
                {
                    var (totalB, books) = data.GetBooksByAuthor(author.Name, 0, 5).Result;
                    TotalBooks += totalB;

                    var observableBooks = new ObservableCollection<Book>(books);
                    AuteurGroups.Add(new AuteurGroup(author.Name, observableBooks));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public class AuteurGroup : ObservableCollection<Book>
        {
            public string Name { get; private set; }

            public AuteurGroup(string name, ObservableCollection<Book> books)
                : base(books)
            {
                Name = name;
            }
        }

        public async Task RemoveBookById(string bookId)
        {
            await userLibraryManager.RemoveBook(bookId);

            for (int i = AuteurGroups.Count - 1; i >= 0; i--)
            {
                var group = AuteurGroups[i];
                var bookToRemove = group.FirstOrDefault(book => book.Id == bookId);
                if (bookToRemove != null)
                {
                    group.Remove(bookToRemove);
                    if (group.Count == 0)
                    {
                        AuteurGroups.RemoveAt(i);
                        TotalBooks = TotalBooks - 1;
                    }
                    break;
                }
            }
            OnPropertyChanged(nameof(AuteurGroups));
        }
    }
}
