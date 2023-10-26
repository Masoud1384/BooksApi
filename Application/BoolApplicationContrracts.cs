using Application.Commands.Authors;
using Application.Commands.Books;
using Domain.IRepository;
using Domain.Models;
using System.Linq.Expressions;

namespace Application
{
    public class BoolApplicationContrracts : IBookApplicationContract
    {
        private IBookRepository _bookRepository;

        public BoolApplicationContrracts(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public bool ActivateBook(int bookId)
        {
            throw new NotImplementedException();
        }

        public bool AddBook(CreateBookCommand book, out int? bookId)
        {
            throw new NotImplementedException();
        }

        public bool DeActiveBook(int bookId)
        {
            throw new NotImplementedException();
        }

        public AuthorViewModel FindBookBy(Expression<Func<Book, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<AuthorViewModel> SelectAllBooks()
        {
            throw new NotImplementedException();
        }

        public bool Update(UpdateBookCommand book)
        {
            throw new NotImplementedException();
        }
    }
}
