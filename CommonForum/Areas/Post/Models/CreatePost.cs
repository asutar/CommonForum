using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommonForum.Areas.Post.Models
{
    public class CreatePost
    {
        public int SRNO { get; set; }
        public string TITLE { get; set; }
        [AllowHtml]
        public string POST { get; set; }
        public int ADDED_DATE { get; set; }
        public int USER_ID { get; set; }
        public List<Topics> TOPICS_ID { get; set; }
    }
}