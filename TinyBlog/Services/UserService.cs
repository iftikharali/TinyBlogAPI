using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyBlog.Models;
using TinyBlog.Repositories.Interfaces;
using TinyBlog.Services.Interfaces;

namespace TinyBlog.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<User> CreateUser(ApplicationContext context, User user)
        {
            return await this.userRepository.CreateUser(context, user);
        }

        public void DeleteUser(uint id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetLoggedInUser(uint userKey)
        {
            return await this.userRepository.GetUser(userKey);
        }

        public async Task<User> GetUser(uint userKey)
        {
            //filter all the data which user don't want to show
            return await this.userRepository.GetUser(userKey);
        }

        public Task<IEnumerable<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
