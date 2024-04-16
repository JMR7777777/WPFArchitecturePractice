using WPFArchitecturePractice.DAL.DataAccess.Rent;
using WPFArchitecturePractice.Model.Rent;

namespace WPFArchitecturePractice.BLL.Service.Rent
{
    // BookService 的接口类
    public interface IBookService
    {
        Task<List<Book>> SearchBooksAsync(long? bookId, string? title, short? categoryId);
    }

    // BookService 类
    public class BookService : IBookService
    {
        // 需要访问下层的 IBookDataAccess
        private readonly IBookDataAccess _bookDataAccess;

        public BookService(IBookDataAccess bookDataAccess)
        {
            _bookDataAccess = bookDataAccess ?? throw new ArgumentNullException(nameof(bookDataAccess));
        }

        // 无需复杂逻辑，可以直接调用 _bookDataAccess 的 GetBooks 方法
        public async Task<List<Book>> SearchBooksAsync(long? bookId, string? title, short? categoryId)
        {
            return await _bookDataAccess.GetBooksAsync(bookId, title, categoryId);
        }
    }
}
