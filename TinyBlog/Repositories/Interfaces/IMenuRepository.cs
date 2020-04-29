﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyBlog.Models;

namespace TinyBlog.Repositories.Interfaces
{
    public interface IMenuRepository
    {
        Menu GetMenu(uint MenuKey);
        IEnumerable<Menu> GetMenus();
    }
}
