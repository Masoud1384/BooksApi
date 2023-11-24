using Domain.Models;
using System.Linq.Expressions;

namespace Domain.IRepository
{
    public interface IUserRepository
    {
        int Update(User user);
        bool DeActive(User user);
        void Activate(int userId);
        int Create(User user);
        User Get(Expression<Func<User, bool>> expression);
    }
}
