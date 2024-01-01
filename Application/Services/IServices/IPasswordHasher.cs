namespace Application.Services.IServices
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyPassword(string password,string enteredPassword);
    }
}
