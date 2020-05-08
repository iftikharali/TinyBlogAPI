using System;
using System.Collections.Generic;
using System.Text;

namespace TinyBlog.Models
{
    public class Tag
    {
        public string TagKey { get; set; }
        public Guid TagGuid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public User CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User UpdatedBy { get; set; }
    }
}
