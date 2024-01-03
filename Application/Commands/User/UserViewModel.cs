using Application.Commands.Token;

namespace Application.Commands.User
{
    public class UserViewModel : UserUpdateCommand
    {
        public TokenViewModel Token { get; set; }
        public UserViewModel()
        {
                
        }
        public UserViewModel(int Id, string username, string? email, string password, bool isActive,TokenViewModel token) : base(Id, username, email, password, isActive, token)
        {
            Token = token;
        }
    }
}
