using System;
using System.Collections.Generic;
using System.Text;

namespace TinyBlog.Models
{
    public class MetaTag
    {
        public string MetaTagKey { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public User CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User UpdatedBy { get; set; }
    }
}
