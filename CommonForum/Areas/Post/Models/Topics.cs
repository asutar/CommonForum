using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommonForum.Areas.Post.Models
{
    public class Topics
    {
        public int TOPICS_ID { get; set; }
        public string TOPIC { get; set; }
        public string ADDED_BY { get; set; }
        public string ADDED_BY_DATETIME { get; set; }
    }
}