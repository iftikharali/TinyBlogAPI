using System;
using System.Collections.Generic;
using System.Text;

namespace TinyBlog.Models
{
    public class Category
    {
        public uint CategoryKey { get; set; }
        public Guid CategoryGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public User CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User UpdatedBy { get; set; }
    }
}
