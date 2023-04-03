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
    public class AskQuestionController : Controller
    {
        DataAccessLayer _objDataAccessLayer = new DataAccessLayer();
        // GET: AskQuestion
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AskQuestion(Question _model)
        {
            _model.ADDED_BY = Convert.ToInt32(Session["USER_ID"]);

            bool Result = _objDataAccessLayer.AskQuestion(_model);

            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetQuestionDetails(DataTableAjaxPostModel model, string SRNO)
        {
            QuestionDetails_Pagingation _Pagingation = new QuestionDetails_Pagingation();
            QuestionDetails _model = new QuestionDetails();

            _model.SortColumn = "ADDED_BY_DATETIME"; ;
            _model.SortOrder = "desc";
            _model.OffsetValue = 0;
            _model.PageSize = 10;
            _model.SearchText = model.search.value;
            _model.ASKED_QUESTIONS_ID = Convert.ToInt32(SRNO);
            try
            {
                _Pagingation = _objDataAccessLayer.GeQuestionDetails(_model);
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
    }
}