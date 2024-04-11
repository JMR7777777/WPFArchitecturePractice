using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

public class BookDataAccess : IDisposable, IBookDataAccess
{
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

    // 删除图书
    public void DeleteBook(long bookId)
    {
        var bookToDelete = _context.Books.Where(b => !b.IsDeleted).FirstOrDefault(b => b.BookId == bookId);
        if (bookToDelete != null)
        {
            bookToDelete.IsDeleted = true;
            _context.SaveChanges();
        }
    }

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

    // 根据条件获取图书
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


