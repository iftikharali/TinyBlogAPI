using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TinyBlog.Models
{
    public class Blog
    {
        public int ID { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// contains key as tags and value as comma separated tag value
        /// </summary>
        public Dictionary<string,string> MetaTag { get; set; }
        public string BrowserTitle { get; set; }
        public Guid Owner { get; set; }
        public string Url { get; set; }
        public string SortUrl { get; set; }
        public string About { get; set; }
        public bool IsActive { get; set; } = true;
        public string CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
