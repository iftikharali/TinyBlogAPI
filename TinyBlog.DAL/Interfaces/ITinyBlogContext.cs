using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinyBlog.Models;

namespace TinyBlog.DAL.Interfaces
{
    public interface ITinyBlogContext
    {
        bool DeleteUser(User user);
        bool DeleteUser(Guid userId);
        Task<User> GetUser(uint id);
        User GetLoggedInUser(uint id);
        User CreateUser(User user);
        User GetUser(Guid userGuid);
        IEnumerable<User> GetUsers();
        bool DeleteUser(uint UserKey);
        bool UpdateUserEmail(string email);
        bool UpdateUserName(string name);
        bool UpdateUserPassword(string password);
        bool UpdateUserPhone(string phoneNumber);

    }
}
