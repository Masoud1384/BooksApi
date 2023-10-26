using Domain.Models;
using System.Linq.Expressions;

namespace Application.Commands.Authors
{
    public interface IAuthorApplicationContract
    {
        List<AuthorViewModel> SelectAllAuthors();
        AuthorViewModel FindAuthorBy(Expression<Func<Author, bool>> expression);
        bool DeActiveAuthor(int authorId);
        bool AddUser(CreateAuthorCommand author, out int? authorId);
        bool Update(UpdateAuthorCommand author);
        bool ActivateAuthor(int authorId);
    }
}
