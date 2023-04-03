using CommonForum.Areas.Post.Models;
using CommonForum.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommonForum.Controllers
{
    public class ReadPostController : Controller
    {
        DataAccessLayer _objDataAccessLayer = new DataAccessLayer();
        // GET: ReadPost
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetReadPOst(PostDetails model)
        {
            PostDetails_Pagingation _Pagingation = new PostDetails_Pagingation();
            PostDetails _model = new PostDetails();

            _model.SortColumn = "SRNO"; ;
            _model.SortOrder = "desc";
            _model.OffsetValue = 0;
            _model.PageSize = 10;
            _model.SearchText = null;
            _model.SRNO = Convert.ToInt32(model.SRNO);
            try
            {
                _Pagingation = _objDataAccessLayer.GetPostDetails(_model);
                _objDataAccessLayer.AddPostViews(model.SRNO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(new
            {
                data = _Pagingation._Postdetails
            });

        }
        [HttpPost]
        public JsonResult PostComment(Comment model)
        {
            bool Result = _objDataAccessLayer.PostComment(model);

            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetComment(Comment model)
        {

            List<Comment> _ListComment = new List<Comment>();


            try
            {
                _ListComment = _objDataAccessLayer.GetComment(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(new
            {
                data = _ListComment
            });

        }
    }
}