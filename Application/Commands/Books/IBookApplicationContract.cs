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
        bool AddBook(CreateBookCommand book, out int? bookId);
        bool Update(UpdateBookCommand book);
        bool ActivateBook(int bookId);
    }
}
