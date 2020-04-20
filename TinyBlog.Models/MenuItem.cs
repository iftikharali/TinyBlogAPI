using System;
using System.Collections.Generic;
using System.Text;

namespace TinyBlog.Models
{
    public class MenuItem
    {
        public uint MenuItemKey { get; set; }
        public Guid MenuItemGuid { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public User CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User UpdatedBy { get; set; }
    }
}
