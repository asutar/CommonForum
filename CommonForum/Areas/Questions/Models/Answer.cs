using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommonForum.Areas.Questions.Models
{
    public class Answer
    {
        public int ASKED_QUESTIONS_ID { get; set; }
        [AllowHtml]
        public string ANSWER { get; set; }
        public int USER_ID { get; set; }
        public string USER_NAME { get; set; }
        public int ADDED_BY { get; set; }
    }
}