using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using TinyBlog.Extensions;
using TinyBlog.Helper;
using TinyBlog.Models;
using TinyBlog.Repositories.Interfaces;
using TinyBlog.Services.Interfaces;

namespace TinyBlog.Controllers
{
    [Route("api/v1/category")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService categoryService;
        private readonly Appsettings _appSettings;
        
        public CategoriesController(ICategoryService categoryService, IOptions<Appsettings> options)
        {
            this.categoryService = categoryService;
            this._appSettings = options.Value;
        }

        [HttpGet]
        [Route("~/api/v1/categories")]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await this.categoryService.GetCategories();
        }

        [HttpGet]
        [Route("{categoryKey}")]
        public async Task<Category> Get(int categoryKey)
        {
            return await this.categoryService.GetCategory(categoryKey);
        }
        [HttpPost]
        [Authorize]
        public async Task<Category> Create([FromBody] Category category)
        {
            return await this.categoryService.CreateCategory(new ApplicationContext(this.GetIdentityKey(), _appSettings.BaseUrl), category);
        }

    }
}