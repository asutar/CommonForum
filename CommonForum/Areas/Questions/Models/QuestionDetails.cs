using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommonForum.Areas.Questions.Models
{
    public class QuestionDetails
    {
        public int ASKED_QUESTIONS_ID { get; set; }
        public string TITLE { get; set; }
        public string STOPPER_DETAILS { get; set; }
        public string ADDED_BY { get; set; }
        public string ADDED_BY_DATETIME { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        public int OffsetValue { get; set; }
        public int PageSize { get; set; }
        public string SearchText { get; set; }
        public int POST_VIEW { get; set; }
        public int ANSWER_COUNT { get; set; }
        public string TOPICS { get; set; }
    }
    public class QuestionDetails_Pagingation
    {
        public List<QuestionDetails> _Question { get; set; }
        public int filteredCount { get; set; }
    }
    public class QuestionDetailsModelResponse
    {

        public QuestionDetails_Pagingation Data { get; set; }

    }
}