using Domain.Models;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace Domain.IRepository
{
    public interface IAuthorRepository
    {
        int Update(Author author);
        bool DeActive(int id);
        void Activate(int id);
        int Create(Author author);
        Author Get(Expression<Func<Author, bool>> expression);
        List<Author> GetAuthors();
        List<Author> GetAuthors(Expression<Func<Author, bool>> expression);
    }
}
