using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TinyBlog.Models;
using TinyBlog.Repositories.Interfaces;

namespace TinyBlog.Controllers
{
    [Route("api/v1/category")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryRepository categoryRepositiory;
        public CategoriesController(ICategoryRepository categoryRepositiory)
        {
            this.categoryRepositiory = categoryRepositiory;
        }

        [HttpGet]
        [Route("~/api/v1/categories")]
        public IEnumerable<Category> GetCategories()
        {
            return this.categoryRepositiory.GetCategories();
        }
    }
}