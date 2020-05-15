using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyBlog.Models;
using TinyBlog.Repositories.Interfaces;

namespace TinyBlog.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        public Menu GetMenu(int MenuKey)
        {
            return new Menu()
            {
                MenuKey = MenuKey,
                Title = "Home",
                Link = "#"
            };
        }

        public IEnumerable<Menu> GetMenus()
        {
            List<Menu> menus = new List<Menu>();
            Menu menu1 = new Menu()
            {
                Title = "Create New Post",
                Link = "http://localhost:4200/post/create",
                IsEnable = true
            };
            menus.Add(menu1);
            Menu menu2 = new Menu()
            {
                Title = "Artificial Intelligence",
                Link = "#",
                IsEnable = true
            };

            menus.Add(menu2);
            Menu menu3 = new Menu()
            {
                Title = "Promotions",
                Link = "#",
                IsEnable = true
            };
            menus.Add(menu3);
            Menu menu4 = new Menu()
            {
                Title = "More",
                Link = "",
                IsEnable = true,
                MenuItems = new List<Menu>()
            };
            Menu menu5 = new Menu()
            {
                Title = "Technology",
                Link = "",
                IsEnable = true
            };
            Menu menu6 = new Menu()
            {
                Title = "Science",
                Link = "",
                IsEnable = true
            };
            Menu menu7 = new Menu()
            {
                Title = "Spirituality",
                Link = "",
                IsEnable = true
            };

            menu4.MenuItems.Add(menu5);
            menu4.MenuItems.Add(menu6);
            menu4.MenuItems.Add(menu7);

            menus.Add(menu4);

            Menu menu8 = new Menu()
            {
                Title = "Nature",
                Link = "",
                IsEnable = true,
                MenuItems = new List<Menu>()
            };
            Menu menu9 = new Menu()
            {
                Title = "Animal",
                Link = "",
                IsEnable = true
            };
            Menu menu10 = new Menu()
            {
                Title = "Birds",
                Link = "",
                IsEnable = true
            };
            Menu menu11 = new Menu()
            {
                Title = "Herbs & Surbs",
                Link = "",
                IsEnable = true
            };

            menu8.MenuItems.Add(menu9);
            menu8.MenuItems.Add(menu10);
            menu8.MenuItems.Add(menu11);

            menus.Add(menu8);
            return menus;
        }
    }
}
