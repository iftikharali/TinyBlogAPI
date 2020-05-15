using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyBlog.Models;

namespace TinyBlog.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetLoggedInUser(int userKey,ApplicationContext context);
        Task<User> GetUser(int userKey, ApplicationContext context);
        Task<IEnumerable<User>> GetUsers(ApplicationContext context);
        Task<User> CreateUser(ApplicationContext context, User user);
        Task<User> UpdateUser(ApplicationContext context, User user);
        void UpdateUserName(string name);
        void DeleteUser(int id);
        string SaveProfile(IFormFile formFile,string folderName);
    }
}
