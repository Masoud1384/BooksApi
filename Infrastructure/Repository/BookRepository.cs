using Domain.IRepository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly Context _context;

        public BookRepository(Context context)
        {
            _context = context;
        }

        public void Activate(int bookId)
        {
            var book = _context.books.Find(bookId);
            if (book != null)
            {
                book.Activate();
                _context.SaveChanges();
            }
        }

        public int Create(Book book)
        {
            try
            {
                _context.books.Add(book);
                _context.SaveChanges();
                return book.Id;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public bool DeActive(int bookId)
        {
            var book = _context.books.Find(bookId);
            if (book != null)
            {
                book.DeActive();
                var result = _context.SaveChanges();
                return result == 1;
            }
            return false;
        }

        public Book Get(Expression<Func<Book, bool>> expression)
        {
            try
            {
                return _context.books.FirstOrDefault(expression);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Book> GetBooks()
        {
            return _context.books.AsNoTracking().ToList();
        }

        public List<Book> GetBooks(Expression<Func<Book, bool>> expression)
        {
            var result = _context.books.AsNoTracking().Where(expression);
            return result.ToList();
        }

        public int Update(Book book)
        {
            try
            {
                _context.books.Update(book);
                var result = _context.SaveChanges();
                return book.Id;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
