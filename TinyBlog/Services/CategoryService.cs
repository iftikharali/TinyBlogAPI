using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyBlog.Models;
using TinyBlog.Repositories.Interfaces;
using TinyBlog.Services.Interfaces;

namespace TinyBlog.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository categoryRepository; 
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public async Task<Category> CreateCategory(ApplicationContext context, Category category)
        {
            category.CategoryGuid = Guid.NewGuid();
            return await this.categoryRepository.CreateCategory(context, category).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await this.categoryRepository.GetCategories().ConfigureAwait(false);
        }

        public async Task<Category> GetCategory(int categoryKey)
        {
            return await this.categoryRepository.GetCategory(categoryKey);
        }
    }
}
