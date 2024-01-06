using Application.Commands.Token;
using Application.Commands.User;
using Application.IRepositories.EntititesRepositories.IEntitiesRepositories;
using Application.Services.IServices;
using Domain.IRepository;
using Domain.Models;

namespace Application.IRepositories.EntititesRepositories
{
    public class UserApplicationContracts : IUserApplicationCommand
    {
        private IUserRepository _repository;
        private readonly IPasswordHasher _passwordHasher;

        public UserApplicationContracts(IUserRepository repository, IPasswordHasher passwordHasher)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
        }
        public bool ActivateUser(int userId)
        {
            if (userId > 0)
            {
                try
                {
                    _repository.Activate(userId);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                    throw;
                }
            }
            return false;
        }
        public int AddUser(CreateUserCommand user)
        {
            user.Password = _passwordHasher.HashPassword(user.Password);
            var createUser = new User(user.Username, user.Email, user.Password, user.Token);

            var returneduserId = _repository.Create(createUser);
            return returneduserId;
        }
        public bool DeActiveUser(int userId)
        {
            return _repository.DeActive(userId);
        }
        public UserViewModel FindUserBy(int userId)
        {
            var user = _repository.Get(u => u.Id == userId);
            var returnUser = new UserViewModel
            {
                Id = user.Id,
                IsActive = user.IsActive,
                Email = user.Email,
                Password = user.Password,
                Username = user.Username,
            };
            if (user.Token != null)
            {
                returnUser.Token = new TokenViewModel
                {
                    Id = user.Token.Id,
                    Expire = user.Token.Expire,
                    Token = user.Token.Token,
                };
            }


            return returnUser;
        }
         public UserViewModel FindUserBy(string username)
        {
            var user = _repository.Get(u => u.Username == username);
            var returnUser = new UserViewModel
            {
                Id = user.Id,
                IsActive = user.IsActive,
                Email = user.Email,
                Password = user.Password,
                Username = user.Username,
            };
            if (user.Token != null)
            {
                returnUser.Token = new TokenViewModel
                {
                    Id = user.Token.Id,
                    Expire = user.Token.Expire,
                    Token = user.Token.Token,
                    RefreshToken = user.Token.RefreshToken,
                    RefreshTokenExp = user.Token.RefreshTokenExp,
                };
            }
            return returnUser;
        }

        public List<UserViewModel> SelectAllUsers()
        {
            return _repository.GetAll().Select(b => new UserViewModel
            {
                Id = b.Id,
                IsActive = b.IsActive,
                Email = b.Email,
                Password = b.Password,
                Token = new Commands.Token.TokenViewModel
                {
                    Id = b.Token.Id,
                    Expire = b.Token.Expire,
                    Token = b.Token.Token,
                },
                Username = b.Username,
            }).ToList();
        }
        public int Update(UserUpdateCommand user)
        {
            var updateAurhor = new User(user.Id, user.Username, user.Email, user.Password, (bool)user.IsActive, user.Token);
            return _repository.Update(updateAurhor);
        }

        public bool SaveToken(int userId, TokenViewModel tokenViewModel)
        {
            var user = FindUserBy(userId);
            if (user != null)
            {
                return _repository.SaveToken(userId, new UserToken
                {
                    Expire = tokenViewModel.Expire,
                    Token = tokenViewModel.Token,
                    Id = userId,
                    RefreshToken = tokenViewModel.RefreshToken, 
                    RefreshTokenExp = tokenViewModel.RefreshTokenExp,
                });
            }
            return false;
        }

        public bool IsUsernameEmailTaken(string username, string email)
        {
            return _repository.IsUsernameOrEmailTaken(username, email);
        }
    }
}
