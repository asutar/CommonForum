using CommonForum.Areas.Answers.Models;
using CommonForum.Areas.Post.Models;
using CommonForum.Areas.Questions.Models;
using CommonForum.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CommonForum.DB
{
    public class DataAccessLayer
    {
        string CON_STRING = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        public bool CreatePost(CreatePost _model)
        {
            bool RowsAffected = false;
            object objReturn = null;
            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                int USER_ID = Convert.ToInt32(HttpContext.Current.Session["_USER_ID"]);
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "PROC_CREATE_POST";
                cmd.Parameters.Add("@TITLE", SqlDbType.VarChar).Value = _model.TITLE;
                cmd.Parameters.Add("@POST", SqlDbType.VarChar).Value = _model.POST;
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = USER_ID;

                DataTable dtTopics = new DataTable("TB_TOPICS");
                dtTopics.Columns.Add("TOPICS_ID", typeof(string));
                foreach (Topics data in _model.TOPICS_ID)
                {
                    if (_model.TOPICS_ID != null)
                        dtTopics.Rows.Add(data.TOPICS_ID);
                }

                cmd.Parameters.AddWithValue("@TOPICS_LIST", dtTopics);

                cmd.Parameters.Add("@RowCount", SqlDbType.Int);
                cmd.Parameters["@RowCount"].Direction = ParameterDirection.Output;

              
                con.Open();
                objReturn = cmd.ExecuteScalar();
                RowsAffected = Convert.ToBoolean(cmd.Parameters["@RowCount"].Value);
                con.Close();
            }
            return RowsAffected;
        }
        public PostDetails_Pagingation GetPostDetails(PostDetails _model)
        {
            int USER_ID =Convert.ToInt32(HttpContext.Current.Session["_USER_ID"]);

            List<PostDetails> PostDetails = new List<PostDetails>();
            PostDetails_Pagingation _Pagingation = new PostDetails_Pagingation();
            int TotalRecord = 0;
            string strIdleTime = string.Empty;

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_POST_DETAILS";

                cmd.Parameters.Add("@SRNO", SqlDbType.Int).Value = _model.SRNO;
                cmd.Parameters.Add("@SORTCOLUMN", SqlDbType.VarChar).Value = _model.SortColumn == null ? "" : _model.SortColumn;
                cmd.Parameters.Add("@SORTORDER", SqlDbType.VarChar).Value = _model.SortOrder == null ? "" : _model.SortOrder;
                cmd.Parameters.Add("@OFFSETVALUE", SqlDbType.Int).Value = _model.OffsetValue;
                cmd.Parameters.Add("@PAGINGSIZE", SqlDbType.Int).Value = _model.PageSize;
                cmd.Parameters.Add("@SEARCHTEXT", SqlDbType.VarChar).Value = _model.SearchText == null ? "" : _model.SearchText;

                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        TotalRecord = Convert.ToInt32(dr["TOTALCOUNT"]);

                        PostDetails.Add(new PostDetails
                        {
                            SRNO = Convert.ToInt32(dr["SRNO"]),
                            TITLE = Convert.ToString(dr["TITLE"]),
                            POST = Convert.ToString(dr["POST"]),
                            ADDED_DATE = Convert.ToString(dr["ADDED_DATE"]),
                            ADDED_BY = Convert.ToString(dr["ADDED_BY"]),
                            POST_VIEW = Convert.ToInt32(dr["POST_VIEW"]),
                            COMMENT_COUNT = Convert.ToInt32(dr["COMMENT_COUNT"]),
                        });
                    }
                }
            }

            _Pagingation._Postdetails = PostDetails;
            _Pagingation.filteredCount = TotalRecord;

            return _Pagingation;
        }
        public bool PostComment(Comment _model)
        {
            bool RowsAffected = false;
            object objReturn = null;
            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "PROC_ADD_COMMENT";
                cmd.Parameters.Add("@COMMENT", SqlDbType.VarChar).Value = _model.COMMENT;
                cmd.Parameters.Add("@ADDED_BY", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@POST_ID", SqlDbType.Int).Value =_model.POST_ID;

                cmd.Parameters.Add("@RowCount", SqlDbType.Int);
                cmd.Parameters["@RowCount"].Direction = ParameterDirection.Output;

                con.Open();
                objReturn = cmd.ExecuteScalar();
                RowsAffected = Convert.ToBoolean(cmd.Parameters["@RowCount"].Value);
                con.Close();
            }
            return RowsAffected;
        }
        public List<Comment> GetComment(Comment _model)
        {

            List<Comment> PostDetails = new List<Comment>();
            string strIdleTime = string.Empty;

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_COMMENT";

                cmd.Parameters.Add("@POST_ID", SqlDbType.Int).Value = _model.POST_ID;

                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        PostDetails.Add(new Comment
                        {
                            COMMENT_ID = Convert.ToInt32(dr["COMMENT_ID"]),
                            COMMENT = Convert.ToString(dr["COMMENT"]),
                            ADDED_BY = Convert.ToString(dr["ADDED_BY"]),
                            ADDED_BY_DATETIME = Convert.ToString(dr["ADDED_BY_DATETIME"]),
                            POST_ID = Convert.ToInt32(dr["POST_ID"]),
                        });
                    }
                }
            }
            

            return PostDetails;
        }
        public List<Topics> GetTopics(Topics _model)
        {

            List<Topics> Topics = new List<Topics>();
            string strIdleTime = string.Empty;

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_TOPICS";

                cmd.Parameters.Add("@TOPICS_ID", SqlDbType.Int).Value = _model.TOPICS_ID;

                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        Topics.Add(new Topics
                        {
                            TOPICS_ID = Convert.ToInt32(dr["TOPICS_ID"]),
                            TOPIC = Convert.ToString(dr["TOPIC"])
                        });
                    }
                }
            }


            return Topics;
        }
        public User ValidateUserLogin(string loginName, string password)
        {
            DTOUserLoginReturnGet ReturnList = new DTOUserLoginReturnGet();
            DataTable dt = new DataTable();
            User _model = new User();
            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_VALIDATE_USER";

                cmd.Parameters.Add("@EMAIL_ID", SqlDbType.VarChar).Value = loginName;
                cmd.Parameters.Add("@PASSWORD", SqlDbType.VarChar).Value = password;

                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        _model.EMAIL_ID = Convert.ToString(dr["EMAIL_ID"].ToString());
                        _model.USER_ID = Convert.ToInt32(dr["USER_ID"]);
                        _model.FLAG = Convert.ToInt32(dr["Flag"].ToString());
                    }
                }

            }

            return _model;
        }
        public bool AskQuestion(Question _model)
        {
            bool RowsAffected = false;
            object objReturn = null;
            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "PROC_ADD_QUESTION";
                cmd.Parameters.Add("@TITLE", SqlDbType.VarChar).Value = _model.TITLE;
                cmd.Parameters.Add("@STOPPER_DETAILS", SqlDbType.VarChar).Value = _model.STOPPER_DETAILS;
                cmd.Parameters.Add("@ADDED_BY", SqlDbType.VarChar).Value = _model.ADDED_BY;

                DataTable dtTopics = new DataTable("TB_TOPICS");
                dtTopics.Columns.Add("TOPICS_ID", typeof(string));
                foreach (Topics data in _model.TOPICS_ID)
                {
                    if (_model.TOPICS_ID != null)
                        dtTopics.Rows.Add(data.TOPICS_ID);
                }

                cmd.Parameters.AddWithValue("@TOPICS_LIST", dtTopics);

                cmd.Parameters.Add("@RowCount", SqlDbType.Int);
                cmd.Parameters["@RowCount"].Direction = ParameterDirection.Output;


                con.Open();
                objReturn = cmd.ExecuteScalar();
                RowsAffected = Convert.ToBoolean(cmd.Parameters["@RowCount"].Value);
                con.Close();
            }
            return RowsAffected;
        }
        public QuestionDetails_Pagingation GeQuestionDetails(QuestionDetails _model)
        {

            List<QuestionDetails> PostDetails = new List<QuestionDetails>();
            QuestionDetails_Pagingation _Pagingation = new QuestionDetails_Pagingation();
            int TotalRecord = 0;
            string strIdleTime = string.Empty;

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_QUESTIONDETAILS";

                cmd.Parameters.Add("@ASKED_QUESTIONS_ID", SqlDbType.Int).Value = _model.ASKED_QUESTIONS_ID;
                cmd.Parameters.Add("@SORTCOLUMN", SqlDbType.VarChar).Value = _model.SortColumn == null ? "" : _model.SortColumn;
                cmd.Parameters.Add("@SORTORDER", SqlDbType.VarChar).Value = _model.SortOrder == null ? "" : _model.SortOrder;
                cmd.Parameters.Add("@OFFSETVALUE", SqlDbType.Int).Value = _model.OffsetValue;
                cmd.Parameters.Add("@PAGINGSIZE", SqlDbType.Int).Value = _model.PageSize;
                cmd.Parameters.Add("@SEARCHTEXT", SqlDbType.VarChar).Value = _model.SearchText == null ? "" : _model.SearchText;

                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        TotalRecord = Convert.ToInt32(dr["TOTALCOUNT"]);

                        PostDetails.Add(new QuestionDetails
                        {
                            ASKED_QUESTIONS_ID = Convert.ToInt32(dr["ASKED_QUESTIONS_ID"]),
                            TITLE = Convert.ToString(dr["TITLE"]),
                            STOPPER_DETAILS = Convert.ToString(dr["STOPPER_DETAILS"]),
                            ADDED_BY_DATETIME = Convert.ToString(dr["ADDED_BY_DATETIME"]),
                            ADDED_BY = Convert.ToString(dr["ADDED_BY"]),
                            POST_VIEW = Convert.ToInt32(dr["POST_VIEW"]),
                            ANSWER_COUNT = Convert.ToInt32(dr["ANSWER_COUNT"]),
                        });
                    }
                }
            }

            _Pagingation._Question = PostDetails;
            _Pagingation.filteredCount = TotalRecord;

            return _Pagingation;
        }
        public bool PostAnswer(Answer _model)
        {
            bool RowsAffected = false;
            object objReturn = null;
            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "PROC_ADD_ANSWER";
                cmd.Parameters.Add("@ASKED_QUESTIONS_ID", SqlDbType.Int).Value = _model.ASKED_QUESTIONS_ID;
                cmd.Parameters.Add("@ANSWER", SqlDbType.VarChar).Value = _model.ANSWER;
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = _model.USER_ID;
                cmd.Parameters.Add("@USER_NAME", SqlDbType.VarChar).Value = _model.USER_NAME;

                cmd.Parameters.Add("@RowCount", SqlDbType.Int);
                cmd.Parameters["@RowCount"].Direction = ParameterDirection.Output;


                con.Open();
                objReturn = cmd.ExecuteScalar();
                RowsAffected = Convert.ToBoolean(cmd.Parameters["@RowCount"].Value);
                con.Close();
            }
            return RowsAffected;
        }
        public List<AnswerDetails> GeAnswerDetails(AnswerDetails _model)
        {

            List<AnswerDetails> _list = new List<AnswerDetails>();
            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_ANSWER";

                cmd.Parameters.Add("@ASKED_QUESTIONS_ID", SqlDbType.Int).Value = _model.ASKED_QUESTIONS_ID;

                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        _list.Add(new AnswerDetails
                        {
                            ANSWERS_ID = Convert.ToInt32(dr["ANSWERS_ID"]),
                            ANSWER = Convert.ToString(dr["ANSWER"]),
                            USER_NAME = Convert.ToString(dr["USER_NAME"]),
                            ADDED_DATETIME = Convert.ToString(dr["ADDED_DATETIME"]),
                        });
                        
                    }
                }
            }
            
            return _list;
        }
        public bool AddPostViews(int POST_ID)
        {
            bool RowsAffected = false;
            object objReturn = null;
            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "PROC_ADD_POST_VIEWS";
                cmd.Parameters.Add("@POST_ID", SqlDbType.Int).Value = POST_ID;

                cmd.Parameters.Add("@RowCount", SqlDbType.Int);
                cmd.Parameters["@RowCount"].Direction = ParameterDirection.Output;

                con.Open();
                objReturn = cmd.ExecuteScalar();
                RowsAffected = Convert.ToBoolean(cmd.Parameters["@RowCount"].Value);
                con.Close();
            }
            return RowsAffected;
        }
        public bool AddQuestionViews(int ASKED_QUESTIONS_ID)
        {
            bool RowsAffected = false;
            object objReturn = null;
            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "PROC_ADD_QUESTION_VIEWS";
                cmd.Parameters.Add("@ASKED_QUESTIONS_ID", SqlDbType.Int).Value = ASKED_QUESTIONS_ID;

                cmd.Parameters.Add("@RowCount", SqlDbType.Int);
                cmd.Parameters["@RowCount"].Direction = ParameterDirection.Output;

                con.Open();
                objReturn = cmd.ExecuteScalar();
                RowsAffected = Convert.ToBoolean(cmd.Parameters["@RowCount"].Value);
                con.Close();
            }
            return RowsAffected;
        }
        public bool Signup(Signup model)
        {
            bool RowsAffected = false;
            object objReturn = null;
            DTOUserLoginReturnGet ReturnList = new DTOUserLoginReturnGet();
            DataTable dt = new DataTable();
            User _model = new User();
            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_REGISTER_USER";

                cmd.Parameters.Add("@USER_ID", SqlDbType.UniqueIdentifier).Value = model.USER_GUID;
                cmd.Parameters.Add("@USER_NAME", SqlDbType.VarChar).Value = model.UserName;
                cmd.Parameters.Add("@PASSWORD", SqlDbType.VarChar).Value = model.Password;
                cmd.Parameters.Add("@EMAIL_ID", SqlDbType.VarChar).Value = model.Email;
                cmd.Parameters.Add("@ACTIVATION_CODE", SqlDbType.UniqueIdentifier).Value = model.ActivationCode;

                cmd.Parameters.Add("@RowCount", SqlDbType.Int);
                cmd.Parameters["@RowCount"].Direction = ParameterDirection.Output;

                con.Open();
                objReturn = cmd.ExecuteScalar();
                RowsAffected = Convert.ToBoolean(cmd.Parameters["@RowCount"].Value);
                con.Close();

            }

            return RowsAffected;
        }
        public bool ValidateUserEmail(Signup _model)
        {
            bool RowsAffected = false;
            object objReturn = null;
            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "PROC_VALIDATE_USER_EMAIL";
                cmd.Parameters.Add("@EMAIL_ID", SqlDbType.VarChar).Value = _model.Email;
                cmd.Parameters.Add("@RowCount", SqlDbType.Int);
                cmd.Parameters["@RowCount"].Direction = ParameterDirection.Output;


                con.Open();
                objReturn = cmd.ExecuteScalar();
                RowsAffected = Convert.ToBoolean(cmd.Parameters["@RowCount"].Value);
                con.Close();
            }
            return RowsAffected;
        }
    }
}