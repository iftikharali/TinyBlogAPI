using System;
using System.Collections.Generic;
using System.Text;

namespace TinyBlog.Models
{
    public class ApplicationContext
    {
        public int UserKey {get;set;}
        public ApplicationContext(int UserKey)
        {
            this.UserKey = UserKey==0?1:UserKey;
        }
    }
}
