using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyBlog.Models;

namespace TinyBlog.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetLoggedInUser(uint userKey);
        Task<User> GetUser(uint userKey);
        Task<IEnumerable<User>> GetUsers();
        Task<User> CreateUser(ApplicationContext context, User user);
        Task<User> UpdateUser(User user);
        void UpdateUserName(string name);
        void DeleteUser(uint id);
    }
}
