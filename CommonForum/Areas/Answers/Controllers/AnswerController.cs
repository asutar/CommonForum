using CommonForum.Areas.Answers.Models;
using CommonForum.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommonForum.Areas.Answers.Controllers
{
    public class AnswerController : Controller
    {
        DataAccessLayer _objDataAccessLayer = new DataAccessLayer();
        // GET: Answers/Answer
        public ActionResult Index()
        {
            return View();
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