using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyBlog.Models;
using TinyBlog.Repositories;
using TinyBlog.Repositories.Interfaces;
using TinyBlog.Services.Interfaces;

namespace TinyBlog.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        private List<User> _users;
        public async Task<User> Authenticate(string email, string password)
        {
            userRepository = new UserRepository();
            _users = userRepository.GetUsers().ToList();
            var user = await Task.Run(() => _users.SingleOrDefault(x => x.Email == email && x.Password == password));

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so return user details without password
            user.Password = null;
            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            // return users without passwords
            return await Task.Run(() => _users.Select(x => {
                x.Password = null;
                return x;
            }));
        }
    }
}
