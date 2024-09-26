using Model;
using System.Collections.ObjectModel;

namespace ToolKit
{
    public class ObservableBook : BaseViewModel
    {
        private Book _book;
        public Book Book
        {
            get { return _book; }
            set
            {
                if (_book != value)
                {
                    _book = value;
                    OnPropertyChanged(nameof(Book));
                }
            }
        }

        public ObservableBook(Book book)
        {
            _book = book;
        }

        public string Id
        {
            get => _book.Id;
            set
            {
                if (_book.Id != value)
                {
                    _book.Id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Title
        {
            get => _book.Title;
            set
            {
                if (_book.Title != value)
                {
                    _book.Title = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime PublishDate
        {
            get => _book.PublishDate;
            set
            {
                if (_book.PublishDate != value)
                {
                    _book.PublishDate = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<string> Publishers
        {
            get => _book.Publishers;
            set
            {
                if (_book.Publishers != value)
                {
                    _book.Publishers = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ISBN13
        {
            get => _book.ISBN13;
            set
            {
                if (_book.ISBN13 != value)
                {
                    _book.ISBN13 = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<string> Series
        {
            get => _book.Series;
            set
            {
                if (_book.Series != value)
                {
                    _book.Series = value;
                    OnPropertyChanged();
                }
            }
        }

        public int NbPages
        {
            get => _book.NbPages;
            set
            {
                if (_book.NbPages != value)
                {
                    _book.NbPages = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Format
        {
            get => _book.Format;
            set
            {
                if (_book.Format != value)
                {
                    _book.Format = value;
                    OnPropertyChanged();
                }
            }
        }

        public Languages Language
        {
            get => _book.Language;
            set
            {
                if (_book.Language != value)
                {
                    _book.Language = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<Contributor> Contributors
        {
            get => _book.Contributors;
            set
            {
                if (_book.Contributors != value)
                {
                    _book.Contributors = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ImageSmall => _book.ImageSmall;
        public string ImageMedium => _book.ImageMedium;
        public string ImageLarge => _book.ImageLarge;

        public List<Work> Works
        {
            get => _book.Works;
            set
            {
                if (_book.Works != value)
                {
                    _book.Works = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<Author> Authors
        {
            get => _book.Authors;
            set
            {
                if (_book.Authors != value)
                {
                    _book.Authors = value;
                    OnPropertyChanged();
                }
            }
        }

        public Status Status
        {
            get => _book.Status;
            set
            {
                if (_book.Status != value)
                {
                    _book.Status = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<string> UserTags
        {
            get => _book.UserTags;
            set
            {
                if (_book.UserTags != value)
                {
                    _book.UserTags = value;
                    OnPropertyChanged();
                }
            }
        }

        public float? UserRating
        {
            get => _book.UserRating;
            set
            {
                if (_book.UserRating != value)
                {
                    _book.UserRating = value;
                    OnPropertyChanged();
                }
            }
        }

        public string UserNote
        {
            get => _book.UserNote;
            set
            {
                if (_book.UserNote != value)
                {
                    _book.UserNote = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
