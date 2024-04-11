using WPFArchitecturePractice.DAL.DataAccess.Rent;
using WPFArchitecturePractice.Model.Rent;

namespace WPFArchitecturePractice.BLL.Service.Rent
{
    public interface IBookService
    {
        List<Book> SearchBooks(long? bookId, string? title, short? categoryId);
        // 其他业务逻辑接口方法
    }

    public class BookService : IBookService
    {

        private readonly IBookDataAccess _bookDataAccess;

        public BookService(IBookDataAccess bookDataAccess)
        {
            _bookDataAccess = bookDataAccess ?? throw new ArgumentNullException(nameof(bookDataAccess));
        }

        public List<Book> SearchBooks(long? bookId, string? title, short? categoryId)
        {
            return _bookDataAccess.GetBooks(bookId, title, categoryId);
        }
    }
}
