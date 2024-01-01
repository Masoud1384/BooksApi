using Application.Commands.Authors;
using Application.IRepositories.EntititesRepositories.IEntitiesRepositories;
using Domain.IRepository;
using Domain.Models;
using System.Linq.Expressions;

namespace Application.IRepositories.EntititesRepositories
{
    public class AuthorApplicationContracts : IAuthorApplicationContract
    {
        private IAuthorRepository _repository;

        public AuthorApplicationContracts(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public bool ActivateAuthor(int authorId)
        {
            if (authorId > 0)
            {
                try
                {
                    _repository.Activate(authorId);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                    throw;
                }
            }
            return false;
        }
        public int AddUser(CreateAuthorCommand author)
        {
            var createAurhor = new Author(author.Name, author.Age, author.booksVm.Select(b =>
            new Book(b.id, b.Name, b.Description, b.PublishDate, b.authorId)).ToList());

            var returnedAuthorId = _repository.Create(createAurhor);
            return returnedAuthorId;
        }
        public bool DeActiveAuthor(int authorId)
        {
            return _repository.DeActive(authorId);
        }
        public AuthorViewModel FindAuthorBy(Expression<Func<AuthorViewModel, bool>> expression)
        {
            //Converting the AuthorViewModel expression to Author expression
            var parameter = Expression.Parameter(typeof(Author), "author");
            var body = Expression.Invoke(expression, Expression.Property(parameter, "AuthorViewModel"));
            var lambda = Expression.Lambda<Func<Author, bool>>(body, parameter);

            var author = _repository.Get(lambda);

            return new AuthorViewModel
            {
                Active = author.Active,
                Age = author.Age,
                id = author.Id,
                Name = author.Name,
                booksVm = author.books.Select(b => new Commands.Books.BookViewModel
                {
                    id = b.Id,
                    authorId = b.authorId,
                    Description = b.Description,
                    Name = b.Name,
                    PublishDate = b.PublishDate
                }).ToList()
            };
        }
        public List<AuthorViewModel> SelectAllAuthors()
        {
            return _repository.GetAuthors().Select(b => new AuthorViewModel
            {
                Active = b.Active,
                Age = b.Age,
                booksVm = b.books.Select(b => new Commands.Books.BookViewModel
                {
                    id = b.Id,
                    authorId = b.authorId,
                    Description = b.Description,
                    Name = b.Name,
                    PublishDate = b.PublishDate
                }).ToList()
            }).ToList();
        }
        public int Update(UpdateAuthorCommand author)
        {
            var updateAurhor = new Author(author.id, author.Name, author.Age, author.booksVm.Select(b =>
            new Book(b.id, b.Name, b.Description, b.PublishDate, b.authorId)).ToList());
            return _repository.Update(updateAurhor);
        }
    }
}
