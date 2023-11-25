using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class Context : DbContext
    {
        public Context()
        {

        }
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Book> books { get; private set; }
        public DbSet<Author> authors { get; private set; }
        public DbSet<User> users { get; private set; }
    }
}
