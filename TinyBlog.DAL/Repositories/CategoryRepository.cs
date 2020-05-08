using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyBlog.Models;
using TinyBlog.Repositories.Interfaces;

namespace TinyBlog.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            for (uint i = 1; i < 11; i++){
                Category category = new Category()
                {
                    Name = "Category " + i,
                    CategoryKey = 123 + i,
                    Link = "category/123"+i+"/category-"+i
                };
                categories.Add(category);
            }
            return categories;
        }
    }
}
