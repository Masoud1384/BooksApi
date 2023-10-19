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

        public bool Create(Book book)
        {
            try
            {
                _context.books.Add(book);
                var result = _context.SaveChanges();
                return result == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var book = _context.books.Find(id);
                var result = _context.SaveChanges();
                return result == 1;
            }
            catch (Exception)
            {
                return false;
            }
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

        public bool Update(Book book)
        {
            try
            {
                _context.books.Update(book);
                var result = _context.SaveChanges();
                return result == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
