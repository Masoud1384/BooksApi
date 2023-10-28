using Application;
using Domain.IRepository;
using Microsoft.Extensions.DependencyInjection;
using Application.Commands.Authors;
using Application.Commands.Books;
using Infrastructure.Repository;

namespace Infrastructure
{
    public class Bootstraper
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IAuthorApplicationContract,AuthorApplicationContracts>();
            services.AddScoped<IBookApplicationContract, BoolApplicationContrracts>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
        }
    }
}
