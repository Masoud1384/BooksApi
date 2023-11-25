namespace Application.Commands.User
{
    public class UserViewModel : UserUpdateCommand
    {
        public UserViewModel()
        {
                
        }
        public UserViewModel(int Id, string username, string? email, string password, bool isActive, string token) : base(Id, username, email, password, isActive, token)
        {
        }
    }
}
