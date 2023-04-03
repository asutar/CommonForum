using CommonForum.Areas.Answers.Models;
using CommonForum.Areas.Questions.Models;
using CommonForum.DB;
using CommonForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommonForum.Controllers
{
    public class ReadQuestionController : Controller
    {
        DataAccessLayer _objDataAccessLayer = new DataAccessLayer();
        // GET: ReadQuestion
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetQuestionDetails(DataTableAjaxPostModel model, string SRNO)
        {
            QuestionDetails_Pagingation _Pagingation = new QuestionDetails_Pagingation();
            QuestionDetails _model = new QuestionDetails();
            if (SRNO == null)
            {
                _model.SortColumn = "ADDED_BY_DATETIME"; ;
                _model.SortOrder = "desc";
                _model.OffsetValue = 0;
                _model.PageSize = 10;
                _model.SearchText = model.search.value;
                _model.ASKED_QUESTIONS_ID = Convert.ToInt32(SRNO);
            }
            else
            {
                  _model.SortColumn = "ADDED_BY_DATETIME"; ;
                _model.SortOrder = "desc";
                _model.OffsetValue = 0;
                _model.PageSize = 10;
                _model.ASKED_QUESTIONS_ID = Convert.ToInt32(SRNO);
            }
            
            try
            {
                _Pagingation = _objDataAccessLayer.GeQuestionDetails(_model);
                _objDataAccessLayer.AddQuestionViews(_model.ASKED_QUESTIONS_ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(new
            {
                draw = model.draw,
                recordsTotal = _Pagingation.filteredCount,
                recordsFiltered = _Pagingation.filteredCount,
                data = _Pagingation._Question
            });

        }
        [HttpPost]
        public JsonResult PostAnswer(Answer _model)
        {
            _model.USER_ID = Convert.ToInt32(Session["USER_ID"]);

            bool Result = _objDataAccessLayer.PostAnswer(_model);

            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetAnswers(AnswerDetails model)
        {

            List<AnswerDetails> _model = new List<AnswerDetails>();
            try
            {
                _model = _objDataAccessLayer.GeAnswerDetails(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(new
            {
                data = _model
            });

        }
    }
}