using Domain.Models;
using System.Linq.Expressions;

namespace Domain.IRepository
{
    public interface IBookRepository
    {
        int Update(Book book);
        bool DeActive(int bookId);
        void Activate(int bookId);
        int Create(Book book);
        Book Get(Expression<Func<Book,bool>> expression);
        List<Book> GetBooks();
        List<Book> GetBooks(Expression<Func<Book,bool>> expression);

    }
}
