using Application.Commands.Authors;
using System.Linq.Expressions;

namespace Application.Commands.User
{
    public interface IUserApplicationCommand
    {
        List<UserViewModel> SelectAllUsers();
        UserViewModel FindAuthorBy(Expression<Func<UserViewModel, bool>> expression);
        bool DeActiveUser(int userId);
        int AddUser(CreateUserCommand user);
        int Update(UserUpdateCommand user);
        bool ActivateUser(int userId);
    }
}
