using Domain.IRepository;
using Domain.Models;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public class BookRepository : IBookRepository
    {
        public bool Create(Book book)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Book Get(Expression<Func<Book, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetBooks()
        {
            throw new NotImplementedException();
        }

        public List<Book> GetBooks(Expression<Func<Book, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public bool Update(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
