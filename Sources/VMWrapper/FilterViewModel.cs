using Model;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using ToolKit;

namespace VMWrapper
{
    public class FilterViewModel : BaseViewModel
    {
        private readonly ILibraryManager data;

        public ObservableCollection<Author> AuthorList { get; private set; } =
            new ObservableCollection<Author>();
        public ObservableCollection<Book> BookList { get; private set; } =
            new ObservableCollection<Book>();

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

        private string _searchQuery;
        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                if (_searchQuery != value)
                {
                    _searchQuery = value;
                    OnPropertyChanged(nameof(SearchQuery));
                    _ = SearchAuthors(SearchQuery);
                }
            }
        }

        private ICommand _searchCommand;
        public ICommand SearchCommand =>
            _searchCommand ??= new CommandPersonnal<string>(
                async (query) => await SearchAuthors(query)
            );

        private ICommand _sortCommand;
        public ICommand SortCommand =>
            _sortCommand ??= new CommandPersonnal<string>(
                async (sortOrder) => await SortingByName(sortOrder)
            );

        public FilterViewModel(ILibraryManager data)
        {
            this.data = data;
            GetAuthorsAsync();
        }

        private async Task GetDatePublish()
        {
            try
            {
                var result = await data.GetBooksByAuthor("", 0, 5);
                var books = result.Item2;

                BookList.Clear();
                foreach (Book book in books)
                {
                    BookList.Add(book);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public async Task GetAuthorsAsync()
        {
            try
            {
                var result = await data.GetAuthorsByName("", 0, 10);
                var authors = result.Item2;

                AuthorList.Clear();
                foreach (var author in authors)
                {
                    AuthorList.Add(author);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public async Task SortingByName(string sortOrder)
        {
            try
            {
                string sortParam = sortOrder switch
                {
                    "name" => "name",
                    "name_reverse" => "name_reverse",
                    _ => "name"
                };
                Debug.WriteLine($"riri", sortOrder);
                if (SearchQuery != null)
                {
                    var (total, authors) = await data.GetAuthorsByName(
                        _searchQuery,
                        0,
                        10,
                        sortParam
                    );
                    AuthorList.Clear();
                    foreach (var author in authors)
                    {
                        AuthorList.Add(author);
                    }
                }
                else
                {
                    var (total, authors) = await data.GetAuthorsByName("", 0, 10, sortParam);
                    AuthorList.Clear();
                    foreach (var author in authors)
                    {
                        AuthorList.Add(author);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private async Task SearchAuthors(string query)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(query))
                {
                    TotalBooks = 0;

                    var (total, authors) = await data.GetAuthorsByName(query, 0, 10);

                    AuthorList.Clear();
                    foreach (Author author in authors)
                    {
                        var (totalB, books) = data.GetBooksByAuthor(author.Name, 0, 10).Result;
                        TotalBooks += totalB;
                    }

                    foreach (var author in authors)
                    {
                        AuthorList.Add(author);
                    }
                }
                else
                {
                    _ = GetAuthorsAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
