using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommonForum.Areas.Post.Models
{
    public class Comment
    {
        public int COMMENT_ID { get; set; }
        public string COMMENT { get; set; }
        public string ADDED_BY { get; set; }
        public string ADDED_BY_DATETIME { get; set; }
        public int POST_ID { get; set; }
    }
}