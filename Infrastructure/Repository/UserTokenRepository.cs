using Domain.IRepository;
using Domain.Models;

namespace Infrastructure.Repository
{
    public class UserTokenRepository : ITokenRepository
    {
        private Context _context;

        public UserTokenRepository(Context context)
        {
            _context = context;
        }


        public void DeleteToken(int tokenId)
        {
            var token = FindToken(tokenId);
            if (token != null)
            {
                _context.tokens.Remove(token);
                _context.SaveChanges();
            }
        }

        public UserToken FindToken(int tokenId)
        {
            return _context.tokens.Find(tokenId);
        }

        public void SaveToken(UserToken token)
        {
            _context.Add(token);
            _context.SaveChanges();
        }
    }
}
