using Domain.Models;
using System.Linq.Expressions;

namespace Domain.IRepository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll(Expression<Func<User, bool>> expression);
        IEnumerable<User> GetAll();
        int Update(User user);
        bool DeActive(int userId);
        void Activate(int userId);
        int Create(User user);
        User Get(Expression<Func<User, bool>> expression);



    }
}
