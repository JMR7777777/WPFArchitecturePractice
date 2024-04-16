using Microsoft.EntityFrameworkCore;
using WPFArchitecturePractice.Model.Rent;

namespace WPFArchitecturePractice.DAL.DataAccess.Rent;

public interface IBookDataAccess
{
    Task AddBookAsync(Book book);
    Task DeleteBookAsync(long bookId);
    Task DeleteBookPhysicallyAsync(long bookId);
    void Dispose();
    Task<Book?> GetBookByIdAsync(long bookId);
    Task<List<Book>> GetBooksAsync(long? bookId, string? title, short? categoryId);
    Task UpdateBookAsync(Book updatedBook);
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
    public async Task AddBookAsync(Book book)
    {
        if (book == null)
            throw new ArgumentNullException(nameof(book));

        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
    }

    // 删除图书（逻辑删除）
    public async Task DeleteBookAsync(long bookId)
    {
        var bookToDelete = await _context.Books.Where(b => !b.IsDeleted).FirstOrDefaultAsync(b => b.BookId == bookId);
        if (bookToDelete != null)
        {
            bookToDelete.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
    }

    // 删除图书（物理删除）
    public async Task DeleteBookPhysicallyAsync(long bookId)
    {
        // efcore 7.0 引入的新语法：ExecuteDeleteAsync（），支持批量删除，不用查询后赋值，效率更高。但是存在事务、并发控制等需要手动调节的问题：https://learn.microsoft.com/zh-cn/ef/core/saving/execute-insert-update-delete
        //await _context.Books.Where(b => !b.IsDeleted && b.BookId == bookId).ExecuteDeleteAsync();

        // efcore 7.0 以前的写法
        var bookToDelete = await _context.Books.Where(b => !b.IsDeleted).FirstOrDefaultAsync(b => b.BookId == bookId);
        if (bookToDelete != null)
        {
            _context.Books.Remove(bookToDelete);
            await _context.SaveChangesAsync();
        }
    }

    // 更新图书信息
    public async Task UpdateBookAsync(Book updatedBook)
    {
        // 抛出异常：updatedBook 为空对象
        if (updatedBook == null)
            throw new ArgumentNullException(nameof(updatedBook));

        // efcore 7.0 以前的写法
        var existingBook = await _context.Books.Where(b => !b.IsDeleted).FirstOrDefaultAsync(b => b.BookId == updatedBook.BookId);
        if (existingBook != null)
        {
            // 更新整个实体是否会出现问题？（部分不该修改的字段被修改或者有些字段没有被修改：updatetime/isdeleted/createTime）
            existingBook = updatedBook;
            //existingBook.Title = updatedBook.Title;
            //existingBook.Description = updatedBook.Description;
            //existingBook.Author = updatedBook.Author;
            //existingBook.UpdatedDate = DateTime.Now;
            //existingBook.IsRentingState = updatedBook.IsRentingState;

            await _context.SaveChangesAsync();
        }
    }

    // 根据图书ID获取图书
    public async Task<Book?> GetBookByIdAsync(long bookId)
    {
        return await _context.Books.FirstOrDefaultAsync(b => b.BookId == bookId);
    }

    // 根据条件获取图书， 当前是有三个参数： bookId， title， categoryId
    public async Task<List<Book>> GetBooksAsync(long? bookId, string? title, short? categoryId)
    {
        var query = _context.Books.Where(b => !b.IsDeleted);
        if (bookId != null)
            query = query.Where(b => b.BookId == bookId);
        if (!string.IsNullOrEmpty(title))
            query = query.Where(b => b.Title.Contains(title));
        if (categoryId != null)
            query = query.Where(b => b.CategoryId == categoryId);

        return await query.ToListAsync();
    }

    // 释放 _context 对象
    public void Dispose()
    {
        _context.Dispose();
    }
}


