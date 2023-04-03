using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommonForum.Areas.Answers.Models
{
    public class AnswerDetails
    {
        public int ANSWERS_ID { get; set; }
        public int ASKED_QUESTIONS_ID { get; set; }
        public string ANSWER { get; set; }
        public int USER_ID { get; set; }
        public string USER_NAME { get; set; }
        public int ADDED_BY { get; set; }
        public string ADDED_DATETIME { get; set; }
    }
}