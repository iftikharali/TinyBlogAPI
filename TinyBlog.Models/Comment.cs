using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TinyBlog.Models
{
    public class Comment
    {
        public uint CommentKey { get; set; }
        public Guid CommentGuid { get; set; }
        public Comment ParentComment { get; set; }
        public string Content { get; set; }
        public Post Post { get; set; }
        public DateTime CreatedAt { get; set; }
        public User CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User UpdatedBy { get; set; }
    }
}
