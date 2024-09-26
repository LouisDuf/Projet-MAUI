using Model;
using System.Diagnostics;
using ToolKit;

namespace VMWrapper
{
    public class DetailBookViewModel : BaseViewModel
    {
        private readonly ILibraryManager data;

        private readonly IUserLibraryManager userLibraryManager;

        public Book BookDetail { get; private set; } = new Book();

        public DetailBookViewModel(ILibraryManager data, IUserLibraryManager userLibraryManager)
        {
            this.data = data;
            this.userLibraryManager = userLibraryManager;
        }

        public async Task UpdateColleciton()
        {
            await userLibraryManager.UpdateBook(BookDetail);
        }

        public async Task LoadBookDetail(string idBook)
        {
            try
            {
                if (idBook != "")
                {
                    BookDetail = await data.GetBookById(idBook);
                    OnPropertyChanged(nameof(BookDetail));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
