using Application.Commands.User;
using Domain.IRepository;
using Domain.Models;
using System.Linq.Expressions;

namespace Application
{
    public class UserApplicationContracts : IUserApplicationCommand
    {
        private IUserRepository _repository;

        public UserApplicationContracts(IUserRepository repository)
        {
            _repository = repository;
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
            var createUser = new User(user.Username,user.Email,user.Password,user.Token);

            var returneduserId = _repository.Create(createUser);
            return returneduserId;
        }
        public bool DeActiveUser(int userId)
        {
            return _repository.DeActive(userId);
        }
        public UserViewModel FindUserBy(Expression<Func<UserViewModel, bool>> expression)
        {
            //Converting the userViewModel expression to user expression
            var parameter = Expression.Parameter(typeof(User), "User");
            var body = Expression.Invoke(expression, Expression.Property(parameter, "UserViewModel"));
            var lambda = Expression.Lambda<Func<User, bool>>(body, parameter);

            var user = _repository.Get(lambda);

            return new UserViewModel
            {
                IsActive = user.IsActive,
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                Token = user.Token,
            };
        }
        public List<UserViewModel> SelectAllUsers()
        {
            return _repository.GetAll().Select(b => new UserViewModel
            {
                Id = b.Id,
                IsActive = b.IsActive,
                Email = b.Email, 
                Password = b.Password,
                Token= b.Token,
                Username= b.Username,
            }).ToList();
        }
        public int Update(UserUpdateCommand user)
        {
            var updateAurhor = new User(user.Id,user.Username,user.Email,user.Password,user.IsActive,user.Token);
            return _repository.Update(updateAurhor);
        }
    }
}
