using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommonForum.Areas.Post.Models
{
    public class PostDetails
    {
        public int SRNO { get; set; }
        public string TITLE { get; set; }
        public string POST { get; set; }
        public string ADDED_BY { get; set; }
        public string ADDED_DATE { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        public int OffsetValue { get; set; }
        public int PageSize { get; set; }
        public string SearchText { get; set; }
        public int POST_VIEW { get; set; }
        public int COMMENT_COUNT { get; set; }
        public int USER_ID { get; set; }
        public string TOPICS { get; set; }
    }
    public class PostDetails_Pagingation
    {
        public List<PostDetails> _Postdetails { get; set; }
        public int filteredCount { get; set; }
    }
    public class PostDetailsModelResponse 
    {

        public PostDetails_Pagingation Data { get; set; }

    }
}