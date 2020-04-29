using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyBlog.Models;

namespace TinyBlog.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
    }
}
