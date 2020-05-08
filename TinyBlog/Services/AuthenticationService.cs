using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TinyBlog.Helper;
using TinyBlog.Models;
using TinyBlog.Repositories;
using TinyBlog.Repositories.Interfaces;
using TinyBlog.Services.Interfaces;


namespace TinyBlog.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private IUserRepository userRepository;
        private List<AuthenticatedUser> _users;
        private IMapper mapper;
        private readonly Appsettings _appSettings;

        public AuthenticationService(IMapper mapper, IOptions<Appsettings> option, IUserRepository repository) {
            this.mapper = mapper;
            this._appSettings = option.Value;
            this.userRepository = repository;
        }
        public async Task<AuthenticatedUser> Authenticate(string email, string password)
        {
            var userList = await userRepository.GetUsers().ConfigureAwait(false);
            _users = this.mapper.Map<List<AuthenticatedUser>>(userList.ToList());
            //_users = ;

            var user = await Task.Run(() => _users.SingleOrDefault(x => x.Email == email));
            User _user;
            if (user == null)
            {
                return null;
            }
            else
            {
                _user = await userRepository.GetUser(user.UserKey);

            }

            AuthenticatedUser authenticatedUser = this.mapper.Map<AuthenticatedUser>(_user);
            // return null if user not found
            if (authenticatedUser == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserKey.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };


            //return user details without password

            var token = tokenHandler.CreateToken(tokenDescriptor);
            authenticatedUser.Token = tokenHandler.WriteToken(token);
            authenticatedUser.Password = null;
            return authenticatedUser;

            
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
