namespace Application.Commands.User
{
    public class UserUpdateCommand : CreateUserCommand
    {
        public int Id { get; set; }

        public UserUpdateCommand(int Id, string username, string? email, string password, bool isActive, string token) : base(username, email, password, isActive, token)
        {
            this.Id = Id;
        }
    }
}
