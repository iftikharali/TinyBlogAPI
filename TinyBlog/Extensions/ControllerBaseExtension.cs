using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TinyBlog.Extensions
{
    public static class ControllerBaseExtension
    {
        public static int GetIdentityKey(this ControllerBase controller)
        {
            var identity = controller.User.Identity as ClaimsIdentity;
            int UserKey = Convert.ToInt32(identity.Claims.ToList()?.FirstOrDefault()?.Value);
            return UserKey;
        }
    }
}
