﻿using System.Linq.Expressions;
using Application.Commands.User;

namespace Application.IRepositories.EntititesRepositories.IEntitiesRepositories
{
    public interface IUserApplicationCommand
    {
        List<UserViewModel> SelectAllUsers();
        UserViewModel FindUserBy(Expression<Func<UserViewModel, bool>> expression);
        bool DeActiveUser(int userId);
        int AddUser(CreateUserCommand user);
        int Update(UserUpdateCommand user);
        bool ActivateUser(int userId);
    }
}