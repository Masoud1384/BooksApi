using Application.Commands.Token;
using System.Text.Json.Serialization;

namespace Application.Commands.User
{
    public class CreateUserCommand
    {
        public string Username { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; }
        [JsonIgnore]
        public TokenViewModel? Token { get; set; }

        public CreateUserCommand()
        {
                
        }
        public CreateUserCommand(string username, string? email, string password, bool isActive, TokenViewModel token)
        {
            Username = username;
            Email = email;
            Password = password;
            IsActive = isActive;
            Token = token;
        }
    }
}
