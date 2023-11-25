using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string? Email { get; private set; }
        public string Password { get;private set; }
        public bool IsActive { get;private set; }
        public string Token { get; private set; }
        public User() { }

        public void DeActivate()
        {
            this.IsActive = false;
        }
        public void Activate()
        {
            this.IsActive = true;
        }
        public User(string username, string? email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
            IsActive = true;
        }
        public User(string username, string? email, string password, string token) : this(username, email, password)
        {
            Token = token;
        }
        public User(int id, string username, string? email, string password, bool isActive, string token)
        {
            Id = id;
            Username = username;
            Email = email;
            Password = password;
            IsActive = isActive;
            Token = token;
        }
    }
}
