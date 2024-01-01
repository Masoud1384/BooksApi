using Application.Commands.Authors;
using Application.Commands.Books;
using Domain.Models;
using System.Linq.Expressions;

namespace Application.IRepositories.EntititesRepositories.IEntitiesRepositories
{
    public interface IBookApplicationContract
    {
        List<BookViewModel> SelectAllBooks();
        BookViewModel FindBookBy(Expression<Func<Book, bool>> expression);
        bool DeActiveBook(int bookId);
        int AddBook(CreateBookCommand book);
        int Update(UpdateBookCommand book);
        bool ActivateBook(int bookId);
    }
}
