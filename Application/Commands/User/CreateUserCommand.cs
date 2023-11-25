namespace Application.Commands.User
{
    public class CreateUserCommand
    {
        public string Username { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string Token { get; set; }

        public CreateUserCommand(string username, string? email, string password, bool isActive, string token)
        {
            Username = username;
            Email = email;
            Password = password;
            IsActive = isActive;
            Token = token;
        }
    }
}
