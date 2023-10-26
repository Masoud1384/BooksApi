using Application.Commands.Authors;
using Domain.Models;
using System.Linq.Expressions;

namespace Application.Commands.Books
{
    public interface IBookApplicationContract
    {
        List<AuthorViewModel> SelectAllBooks();
        AuthorViewModel FindBookBy(Expression<Func<Book, bool>> expression);
        bool DeActiveBook(int bookId);
        int AddBook(CreateBookCommand book);
        int Update(UpdateBookCommand book);
        bool ActivateBook(int bookId);
    }
}
