﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyBlog.Models;

namespace TinyBlog.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(int CategoryKey);
        Task<Category> CreateCategory(ApplicationContext context, Category category);
    }
}
