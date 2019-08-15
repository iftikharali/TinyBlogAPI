using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyBlog.DAL;
using TinyBlog.Models;
using TinyBlog.Repositories.Interfaces;

namespace TinyBlog.Repositories
{
    public class UserRepository : IUserRepository
    {
        private TinyBlogContext _context;
        public UserRepository()
        {
            _context = new TinyBlogContext();
        }
        public UserRepository(TinyBlogContext context)
        {
            _context = context;
        }

        public User CreateUser(User user)
        {
            return _context.CreateUser(user);
        }

        public bool DeleteUser(User user)
        {
           return _context.DeleteUser(user);
        }

        public bool DeleteUser(Guid UserId)
        {
            return _context.DeleteUser(UserId);
        }

        public bool DeleteUser(int Id)
        {
            return _context.DeleteUser(Id);
        }

        public User GetUser(int Id)
        {
            return _context.GetUser(Id);
        }

        public User GetUser(Guid UserId)
        {
            return _context.GetUser(UserId);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.GetUsers();
        }

        public bool UpdateUserEmail(string Email)
        {
            return _context.UpdateUserEmail(Email);
        }

        public bool UpdateUserName(string Name)
        {
            return _context.UpdateUserName(Name);
        }

        public bool UpdateUserPassword(string Password)
        {
            return _context.UpdateUserPassword(Password);
        }

        public bool UpdateUserPhone(string PhoneNumber)
        {
            return _context.UpdateUserPhone(PhoneNumber);
        }
    }
}
