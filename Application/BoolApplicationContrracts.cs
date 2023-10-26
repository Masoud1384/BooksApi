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
            try
            {
                if (bookId > 0)
                {
                    _bookRepository.Activate(bookId);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            return false;
        }

        public bool DeActiveBook(int bookId)
        {
            return _bookRepository.DeActive(bookId);
        }

        public BookViewModel FindBookBy(Expression<Func<Book, bool>> expression)
        {
            //Converting the BookViewModel expression to Book expression
            var parameter = Expression.Parameter(typeof(Book), "book");
            var body = Expression.Invoke(expression, Expression.Property(parameter, "BookViewModel"));
            var lambda = Expression.Lambda<Func<Book, bool>>(body, parameter);

            var book = _bookRepository.Get(lambda);
            return new BookViewModel
            {
                id= book.Id,
                authorId = book.authorId,
                Description= book.Description,
                Name = book.Name,
                PublishDate = book.PublishDate,
            };
        }

        public List<BookViewModel> SelectAllBooks()
        {
            return _bookRepository.GetBooks().Select(b => new BookViewModel
            {
                authorId = b.authorId,
                Description = b.Description,
                id = b.Id,
                Name = b.Name,
                PublishDate = b.PublishDate
            }).ToList();
        }

        public int Update(UpdateBookCommand book)
        {
            var updatebook = new Book(book.id,book.Name,book.Description,book.PublishDate,book.authorId);
            return _bookRepository.Update(updatebook);
        }

        public int AddBook(CreateBookCommand book)
        {
            var createbook = new Book(book.Name,book.Description,book.PublishDate,book.authorId);
            return _bookRepository.Create(createbook);
        }
    }
}
