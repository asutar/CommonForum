using CommonForum.Areas.Post.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommonForum.Models
{
    public class Question
    {
        public int ASKED_QUESTIONS_ID { get; set; }
        public string TITLE { get; set; }
        [AllowHtml]
        public string STOPPER_DETAILS { get; set; }
        public int ADDED_BY { get; set; }
        public DateTime ADDED_BY_DATETIME { get; set; }
        public List<Topics> TOPICS_ID { get; set; }
    }
}