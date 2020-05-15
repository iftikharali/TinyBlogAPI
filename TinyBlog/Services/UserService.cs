using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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
            user.UserGuid = Guid.NewGuid();
            return await this.userRepository.CreateUser(context, user);
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetLoggedInUser(int userKey, ApplicationContext context)
        {
            return await this.userRepository.GetUser(userKey,context);
        }

        public async Task<User> GetUser(int userKey, ApplicationContext context)
        {
            //filter all the data which user don't want to show
            return await this.userRepository.GetUser(userKey,context);
        }

        public async Task<IEnumerable<User>> GetUsers(ApplicationContext context)
        {
            return await this.userRepository.GetUsers(context).ConfigureAwait(false);
        }

        public string SaveProfile(IFormFile formFile,string folderName)
        {
            Directory.CreateDirectory(folderName);
            var file = formFile;
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(folderName, fileName);
                var dbPath = Path.Combine(folderName, fileName);
                bool IsFileExists = true;
                int counterToAdd = 1;
                while (IsFileExists)
                {
                    if (File.Exists(fullPath))
                    {
                        string FileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                        string FileExtension = Path.GetExtension(fileName);
                        fullPath = Path.Combine(folderName, FileNameWithoutExtension + "(" + (counterToAdd++) + ")" + FileExtension);

                    }
                    else
                    {
                        IsFileExists = false;
                    }
                }
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return Path.GetFileName(fullPath);
            }
            else
            {
                return null;
            }
        }

        public async Task<User> UpdateUser(ApplicationContext context, User user)
        {
            return await this.userRepository.UpdateUser(context,user);
        }

        public void UpdateUserName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
