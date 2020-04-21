using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TinyBlog.Models
{
    public class Recommend
    {
        public User RecommendBy { get; set; }
        public User RecommendTo { get; set; }
    }
    public class Blog
    {
        public Blog()
        {
            this.MetaTag = new Dictionary<string, string>();
            this.Tags = new List<Tag>();
        }
        public uint BlogKey { get; set; }
        public Guid BlogGuid { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string MainContentImageUrl { get; set; }
        public string MainContentImageSubtitle { get; set; }
        /// <summary>
        /// contains key as tags and value as comma separated tag value
        /// </summary>
        public Dictionary<string,string> MetaTag { get; set; }
        public string BrowserTitle { get; set; }
        public User Owner { get; set; }
        public string Url { get; set; }
        public string SortUrl { get; set; }
        public string Content { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public bool IsActive { get; set; } = true;
        public List<User> Subscribers { get; set; }
        public int Votes { get; set; }
        /// <summary>
        /// When user Recommend he/she can add users as well whome he specifically want to recommend
        /// </summary>
        public List<Recommend> Recommends { get; set; }
        public DateTime CreatedAt { get; set; }
        public User CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User UpdatedBy { get; set; }
    }
}
