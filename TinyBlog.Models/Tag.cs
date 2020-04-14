using System;
using System.Collections.Generic;
using System.Text;

namespace TinyBlog.Models
{
    public class Tag
    {
        public string ID { get; set; }
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
    }
}
