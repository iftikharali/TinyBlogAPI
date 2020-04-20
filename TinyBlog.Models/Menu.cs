using System;
using System.Collections.Generic;
using System.Text;

namespace TinyBlog.Models
{
    public class Menu
    {
        public string MenuKey { get; set; }
        public Guid MenuGuid { get; set; }
        public string Title { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public User CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User UpdatedBy { get; set; }
    }
}
