using CommonForum.Areas.Post.Models;
using CommonForum.DB;
using CommonForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommonForum.Areas.Post.Controllers
{
    public class CreatePostController : Controller
    {
        DataAccessLayer _objDataAccessLayer = new DataAccessLayer();
        // GET: Post/CreatePost
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Post(CreatePost _model)
        {
           bool Result= _objDataAccessLayer.CreatePost(_model);

            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PostDetails()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetPostDetails(DataTableAjaxPostModel model, string SRNO)
        {
            PostDetails_Pagingation _Pagingation = new PostDetails_Pagingation();
            PostDetails _model = new PostDetails();
            if (SRNO != "0")
            {
                _model.SortColumn = "SRNO"; ;
                _model.SortOrder = "desc";
                _model.OffsetValue = 0;
                _model.PageSize = 10;
                _model.SearchText = null;
                _model.SRNO = Convert.ToInt32(SRNO);
            }
            else
            {
                _model.SortColumn = "SRNO"; ;
                _model.SortOrder = "desc";
                _model.OffsetValue = 0;
                _model.PageSize = 10;
                _model.SearchText = model.search.value;

            }
            try
            {
                _Pagingation = _objDataAccessLayer.GetPostDetails(_model);
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
                data = _Pagingation._Postdetails
            });

        }
        public ActionResult PostRead()
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
        [HttpPost]
        public JsonResult GetTopics(Topics model)
        {

            List<Topics> _ListComment = new List<Topics>();


            try
            {
                _ListComment = _objDataAccessLayer.GetTopics(model);
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