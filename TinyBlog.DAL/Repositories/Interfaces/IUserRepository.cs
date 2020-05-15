using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyBlog.Models;

namespace TinyBlog.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers(ApplicationContext context);
        Task<User> GetUser(int Id, ApplicationContext context);
        Task<User> GetUser(Guid UserId, ApplicationContext context);
        bool UpdateUserName(string Name);
        bool UpdateUserEmail(string Email);
        bool UpdateUserPassword(string Password);
        bool UpdateUserPhone(string PhoneNumber);
        bool DeleteUser(User user);
        bool DeleteUser(Guid UserId);
        bool DeleteUser(int Id);
        Task<User> CreateUser(ApplicationContext context, User user);
        User GetLoggedInUser(int id, ApplicationContext context);
        Task<User> UpdateUser(ApplicationContext context, User user);
    }
}
