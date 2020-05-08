using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyBlog.Models;

namespace TinyBlog.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(uint Id);
        Task<User> GetUser(Guid UserId);
        bool UpdateUserName(string Name);
        bool UpdateUserEmail(string Email);
        bool UpdateUserPassword(string Password);
        bool UpdateUserPhone(string PhoneNumber);
        bool DeleteUser(User user);
        bool DeleteUser(Guid UserId);
        bool DeleteUser(uint Id);
        Task<User> CreateUser(ApplicationContext context, User user);
        User GetLoggedInUser(uint id);
    }
}
