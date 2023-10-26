using Domain.IRepository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly Context _context;

        public AuthorRepository(Context context)
        {
            _context = context;
        }

        public void Activate(int id)
        {
            var author = _context.authors.Find(id);
            author.Activate();
            _context.SaveChanges();
        }

        public int Create(Author author)
        {
            try
            {
                _context.authors.Add(author);
                _context.SaveChanges();
                return author.Id;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public bool DeActive(int id)
        {
            var author = _context.authors.Find(id);
            author.DeActive();
            var result = _context.SaveChanges();
            return result == 1;
        }

        public bool Delete(int id)
        {
            try
            {
                var author = _context.authors.Find(id);
                var result = _context.SaveChanges();
                return result == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Author Get(Expression<Func<Author, bool>> expression)
        {
            try
            {
                return _context.authors.FirstOrDefault(expression);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Author> GetAuthors()
        {
            return _context.authors.AsNoTracking().ToList();
        }

        public List<Author> GetAuthors(Expression<Func<Author, bool>> expression)
        {
            var result = _context.authors.AsNoTracking().Where(expression);
            return result.ToList();
        }

        public int Update(Author author)
        {
            try
            {
                _context.authors.Update(author);
                var result = _context.SaveChanges();
                return author.Id;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
