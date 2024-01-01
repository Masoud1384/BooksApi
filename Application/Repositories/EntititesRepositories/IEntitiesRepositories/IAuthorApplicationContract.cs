using Application.Commands.Authors;
using Domain.Models;
using System.Linq.Expressions;

namespace Application.IRepositories.EntititesRepositories.IEntitiesRepositories
{
    public interface IAuthorApplicationContract
    {
        List<AuthorViewModel> SelectAllAuthors();
        AuthorViewModel FindAuthorBy(Expression<Func<AuthorViewModel, bool>> expression);
        bool DeActiveAuthor(int authorId);
        int AddUser(CreateAuthorCommand author);
        int Update(UpdateAuthorCommand author);
        bool ActivateAuthor(int authorId);
    }
}
