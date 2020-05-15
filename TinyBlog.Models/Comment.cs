using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TinyBlog.Models
{
    public class Comment
    {
        public int CommentKey { get; set; }
        public Guid CommentGuid { get; set; }
        public Comment ParentComment { get; set; }
        public string Content { get; set; }
        public int? ParentCommentKey
        {
            get
            {
                if (ParentComment != null)
                {
                    return ParentComment.CommentKey;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (ParentComment == null && value!=null)
                {
                    ParentComment = new Comment() { CommentKey = value.Value};
                }
            }
        }
        public int PostKey { get
            {
                if (Post != null)
                {
                    return Post.PostKey;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (Post == null)
                {
                    Post = new Post() { PostKey = value };
                }
            }
        }
        public Post Post { get; set; }
        public DateTime CreatedAt { get; set; }
        public User CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User UpdatedBy { get; set; }
    }
}
