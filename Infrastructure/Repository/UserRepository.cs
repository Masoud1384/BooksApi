using Application.Services.IServices;
using Domain.IRepository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        private readonly RandomNumberGenerator random = RandomNumberGenerator.Create();

        public UserRepository(Context context)
        {
            _context = context;
        }

        public void Activate(int id)
        {
            var user = _context.users.Find(id);
            user.Activate();
            _context.SaveChanges();
        }
        public int Create(User user)
        {
            try
            {
                _context.users.Add(user);
                _context.SaveChanges();
                return user.Id;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public bool DeActive(int id)
        {
            var user = _context.users.Find(id);
            user.DeActivate();
            var result = _context.SaveChanges();
            return result == 1;
        }
        public bool Delete(int id)
        {
            try
            {
                var user = _context.users.Find(id);
                var result = _context.SaveChanges();
                return result == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public User Get(Expression<Func<User, bool>> expression)
        {
            try
            {
                return _context.users.FirstOrDefault(expression);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public IEnumerable<User> GetAll()
        {
            return _context.users.AsNoTracking().ToList();
        }
        public IEnumerable<User> GetAll(Expression<Func<User, bool>> expression)
        {
            var result = _context.users.AsNoTracking().Where(expression);
            return result.ToList();
        }
        public bool SaveToken(int userId, UserToken userToken)
        {
            if (!userToken.Token.IsNullOrEmpty())
            {
                var algorithm = new SHA256CryptoServiceProvider();
                var byteValue = Encoding.UTF8.GetBytes(userToken.Token);
                var hashbyte = Convert.ToBase64String(algorithm.ComputeHash(byteValue));
                var user = Get(u => u.Id == userId);
                if (user != null)
                {
                    user.Token = userToken;
                    return _context.SaveChanges() > 0 ? true : false;
                }
            }
            return false;
        }
        public int Update(User user)
        {
            try
            {
                _context.users.Update(user);
                var result = _context.SaveChanges();
                return user.Id;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
