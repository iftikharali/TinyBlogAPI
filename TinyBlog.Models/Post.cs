using System;
using System.Collections.Generic;
using System.Text;

namespace TinyBlog.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string Title { get; set; }
        /// <summary>
        /// contains key as tags and value as comma separated tag value
        /// </summary>
        public Dictionary<string, string> MetaTag { get; set; }
        public string BrowserTitle { get; set; }
        public Guid Author { get; set; }
        public string Url { get; set; }
        public string SortUrl { get; set; }
        public string Excerpt { get; set; }
        public string Content { get; set; }
        public bool IsPublished { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public int BlogID { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
    }
}
