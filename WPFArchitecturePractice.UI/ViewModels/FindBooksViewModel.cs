using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using WPFArchitecturePractice.BLL.Service.Rent;
using WPFArchitecturePractice.Model.Rent;
using WPFArchitecturePractice.UI.Messages;

namespace WPFArchitecturePractice.UI.ViewModels
{
    public partial class FindBooksViewModel : ObservableObject
    {
        [ObservableProperty]
        private long? bookId;
        [ObservableProperty]
        private string? bookTitle;
        [ObservableProperty]
        private short? bookCategoryId;

        [ObservableProperty]
        public ObservableCollection<Book> books;

        private readonly IBookService _bookService;

        public FindBooksViewModel(IBookService bookService)
        {
            _bookService = bookService;
            bookTitle = "1";
            books = new ObservableCollection<Book>();
        }

        [RelayCommand]
        public void SetAsCurrentBooks()
        {
            WeakReferenceMessenger.Default.Send(new ChangePageMessage("Views\\RentRecordsPage.xaml"));
        }

        [RelayCommand]
        public void SearchBooks()
        {
            // 调用 BookService 中的方法执行查询
            var books = _bookService.SearchBooks(this.BookId, this.BookTitle, this.BookCategoryId);

            // 将查询结果更新到 Books 集合中
            Books.Clear();

            foreach (var book in books)
            {
                Books.Add(book);
            }
        }
    }
}
