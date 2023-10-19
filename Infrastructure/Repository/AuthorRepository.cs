using Domain.IRepository;
using Domain.Models;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        public bool Create(Author author)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Author Get(Expression<Func<Author, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<Author> GetAuthors()
        {
            throw new NotImplementedException();
        }

        public List<Author> GetAuthors(Expression<Func<Author, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public bool Update(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
