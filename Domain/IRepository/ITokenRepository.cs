using Domain.Models;
using System.Security.Cryptography.X509Certificates;

namespace Domain.IRepository
{
    public interface ITokenRepository
    {
        UserToken CreateNewRefreshToken(string refreshToken);   
        void SaveToken(UserToken token);
        UserToken FindRefreshToken(string refreshToken);
    }
}
