using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TinyBlog.Models
{
    public class Blog
    {
        public Blog()
        {
            this.MetaTag = new Dictionary<string, string>();
            this.Tags = new List<Tag>();
        }
        public int ID { get; set; }
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string MainContentImageUrl { get; set; }
        public string MainContentImageSubtitle { get; set; }
        /// <summary>
        /// contains key as tags and value as comma separated tag value
        /// </summary>
        public Dictionary<string,string> MetaTag { get; set; }
        public string BrowserTitle { get; set; }
        public int Owner { get; set; }
        public string Url { get; set; }
        public string SortUrl { get; set; }
        public string Content { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
    }
}
