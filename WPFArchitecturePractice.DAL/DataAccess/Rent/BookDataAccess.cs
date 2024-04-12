using WPFArchitecturePractice.Model.Rent;

namespace WPFArchitecturePractice.DAL.DataAccess.Rent;

public interface IBookDataAccess
{
    void AddBook(Book book);
    void DeleteBook(long bookId);
    void DeleteBookPhysically(long bookId);
    void Dispose();
    Book? GetBookById(long bookId);
    List<Book> GetBooks(long? bookId, string? title, short? categoryId);
    void UpdateBook(Book updatedBook);
}


//todo 存在关于书籍类型的显示的问题，需要一个转换器将 categoryId 变成 categoryName
public class BookDataAccess : IDisposable, IBookDataAccess
{
    // 需要访问下面的 DataContext ，利用 efcore 实现对数据库的直接操作
    private readonly WPFArchitecturePraticeContext _context;

    public BookDataAccess(WPFArchitecturePraticeContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    // 添加图书
    public void AddBook(Book book)
    {
        if (book == null)
            throw new ArgumentNullException(nameof(book));

        _context.Books.Add(book);
        _context.SaveChanges();
    }

    // 删除图书（逻辑删除）
    public void DeleteBook(long bookId)
    {
        var bookToDelete = _context.Books.Where(b => !b.IsDeleted).FirstOrDefault(b => b.BookId == bookId);
        if (bookToDelete != null)
        {
            bookToDelete.IsDeleted = true;
            _context.SaveChanges();
        }
    }

    // 删除图书（物理删除）
    public void DeleteBookPhysically(long bookId)
    {
        var bookToDelete = _context.Books.Where(b => !b.IsDeleted).FirstOrDefault(b => b.BookId == bookId);
        if (bookToDelete != null)
        {
            _context.Books.Remove(bookToDelete);
            _context.SaveChanges();
        }
    }

    // 更新图书信息
    public void UpdateBook(Book updatedBook)
    {
        if (updatedBook == null)
            throw new ArgumentNullException(nameof(updatedBook));

        var existingBook = _context.Books.Where(b => !b.IsDeleted).FirstOrDefault(b => b.BookId == updatedBook.BookId);
        if (existingBook != null)
        {
            // 更新整个实体是否会出现问题？（部分不该修改的字段被修改或者有些字段没有被修改：updatetime/isdeleted/createTime）
            existingBook = updatedBook;
            //existingBook.Title = updatedBook.Title;
            //existingBook.Description = updatedBook.Description;
            //existingBook.Author = updatedBook.Author;
            //existingBook.UpdatedDate = DateTime.Now;
            //existingBook.IsRentingState = updatedBook.IsRentingState;

            _context.SaveChanges();
        }
    }

    // 根据图书ID获取图书
    public Book? GetBookById(long bookId)
    {
        return _context.Books.FirstOrDefault(b => b.BookId == bookId);
    }

    // 根据条件获取图书， 当前是有三个参数： bookId， title， categoryId
    public List<Book> GetBooks(long? bookId, string? title, short? categoryId)
    {

        var query = _context.Books.Where(b => !b.IsDeleted);

        if (bookId != null)
            query = query.Where(b => b.BookId == bookId);

        if (!string.IsNullOrEmpty(title))
            query = query.Where(b => b.Title.Contains(title));

        if (categoryId != null)
            query = query.Where(b => b.CategoryId == categoryId);

        return query.ToList();
    }

    // 释放 _context 对象
    public void Dispose()
    {
        _context.Dispose();
    }
}


