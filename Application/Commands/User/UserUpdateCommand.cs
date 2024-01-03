using Application.Commands.Token;

namespace Application.Commands.User
{
    public class UserUpdateCommand : CreateUserCommand
    {
        public int Id { get; set; }
        public UserUpdateCommand()
        {
            
        }
        public UserUpdateCommand(int Id, string username, string? email, string password, bool isActive, TokenViewModel token) : base(username, email, password, isActive, token)
        {
            this.Id = Id;
        }
    }
}
