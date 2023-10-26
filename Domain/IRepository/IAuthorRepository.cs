using Domain.Models;
using System.Linq.Expressions;

namespace Domain.IRepository
{
    public interface IAuthorRepository
    {
        bool Update(Author author);
        bool DeActive(int id);
        void Activate(int id);
        bool Create(Author author);
        Author Get(Expression<Func<Author, bool>> expression);
        List<Author> GetAuthors();
        List<Author> GetAuthors(Expression<Func<Author, bool>> expression);
    }
}
