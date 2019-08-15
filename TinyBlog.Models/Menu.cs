using System;
using System.Collections.Generic;
using System.Text;

namespace TinyBlog.Models
{
    public class Menu
    {
        public string ID { get; set; }
        public string Title { get; set; }

        public ICollection<MenuItem> MenuItems { get; set; }
    }
}
