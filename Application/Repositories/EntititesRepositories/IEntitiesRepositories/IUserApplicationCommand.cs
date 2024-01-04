using Application.Commands.Token;
using Application.Commands.User;

namespace Application.IRepositories.EntititesRepositories.IEntitiesRepositories
{
    public interface IUserApplicationCommand
    {
        List<UserViewModel> SelectAllUsers();
        UserViewModel FindUserBy(int userId);
        bool DeActiveUser(int userId);
        int AddUser(CreateUserCommand user);
        int Update(UserUpdateCommand user);
        bool ActivateUser(int userId);
        bool SaveToken(int userId, TokenViewModel tokenViewModel);
        bool IsUsernameEmailTaken(string username, string email);
    }
}
