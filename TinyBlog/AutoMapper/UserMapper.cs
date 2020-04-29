using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyBlog.Models;

namespace TinyBlog.AutoMapper
{
    public class UserMapper: Profile
    {
        public UserMapper()
        {
            CreateMap<User, AuthenticatedUser>();
        }
    }
}
