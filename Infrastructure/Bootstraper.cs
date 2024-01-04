using Domain.IRepository;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Repository;
using Application.IRepositories.EntititesRepositories;
using Application.IRepositories.EntititesRepositories.IEntitiesRepositories;
using Application.Services.IServices;

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
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserApplicationCommand, UserApplicationContracts>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ITokenRepository,UserTokenRepository>();
        }
    }
}