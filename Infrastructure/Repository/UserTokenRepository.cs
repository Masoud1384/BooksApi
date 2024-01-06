using Domain.IRepository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UserTokenRepository : ITokenRepository
    {
        private Context _context;

        public UserTokenRepository(Context context)
        {
            _context = context;
        }

        public UserToken CreateNewRefreshToken(string refreshToken)
        {
            var userToken = FindRefreshToken(refreshToken);
            userToken.RefreshToken = Guid.NewGuid().ToString();
            userToken.RefreshTokenExp = DateTime.Now.AddDays(30);
            _context.SaveChanges();
            return userToken;
        }

        public UserToken FindRefreshToken(string refreshToken)
        {
            return _context.tokens.Include(u=>u.user).FirstOrDefault(t=>t.RefreshToken==refreshToken);
        }

        public void SaveToken(UserToken token)
        {
            _context.tokens.Add(token);
            _context.SaveChanges();
        }
    }
}
