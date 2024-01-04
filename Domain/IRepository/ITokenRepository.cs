using Domain.Models;
using System.Security.Cryptography.X509Certificates;

namespace Domain.IRepository
{
    public interface ITokenRepository
    {
        void SaveToken(UserToken token);
        void DeleteToken(int tokenId);
        UserToken FindToken(int tokenId);
    }
}
