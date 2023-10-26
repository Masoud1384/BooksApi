using Application.Commands.Authors;
using Domain.IRepository;
using Domain.Models;
using System.Linq.Expressions;

namespace Application
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
            throw new NotImplementedException();
        }

        public bool AddUser(CreateAuthorCommand author, out int? authorId)
        {
            throw new NotImplementedException();
        }

        public bool DeActiveAuthor(int authorId)
        {
            throw new NotImplementedException();
        }

        public AuthorViewModel FindAuthorBy(Expression<Func<Author, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<AuthorViewModel> SelectAllAuthors()
        {
            throw new NotImplementedException();
        }

        public bool Update(UpdateAuthorCommand author)
        {
            throw new NotImplementedException();
        }
    }
}
