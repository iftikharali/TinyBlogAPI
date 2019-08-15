using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TinyBlog.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public int Post_Id { get; set; }
        public string CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public string UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
    }
}
