using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyBlog.Models;

namespace TinyBlog.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(uint Id);
        User GetUser(Guid UserId);
        bool UpdateUserName(string Name);
        bool UpdateUserEmail(string Email);
        bool UpdateUserPassword(string Password);
        bool UpdateUserPhone(string PhoneNumber);
        bool DeleteUser(User user);
        bool DeleteUser(Guid UserId);
        bool DeleteUser(uint Id);
        User CreateUser(User user);
    }
}
