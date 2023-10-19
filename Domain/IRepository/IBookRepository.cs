using Domain.Models;
using System.Linq.Expressions;

namespace Domain.IRepository
{
    public interface IBookRepository
    {
        bool Update(Book book);
        bool Delete(int id);
        bool Create(Book book);
        Book Get(Expression<Func<Book,bool>> expression);
        List<Book> GetBooks();
        List<Book> GetBooks(Expression<Func<Book,bool>> expression);
    }
}
