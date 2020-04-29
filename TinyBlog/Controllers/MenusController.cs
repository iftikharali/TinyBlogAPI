using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TinyBlog.Models;
using TinyBlog.Repositories.Interfaces;

namespace TinyBlog.Controllers
{
    [Route("api/v1/menu")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        IMenuRepository menuRepository;

        public MenusController(IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        // GET: api/v1/menus
        [HttpGet]
        [Route("~/api/v1/menus/")]
        public IEnumerable<Menu> Get()
        {
            return menuRepository.GetMenus();
        }
    }
}