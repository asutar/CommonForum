using CommonForum.Areas.Post.Models;
using CommonForum.DB;
using CommonForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CommonForum.Controllers
{
    public class HomeController : Controller
    {
        DataAccessLayer _objDataAccessLayer = new DataAccessLayer();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public JsonResult GetPostDetails(DataTableAjaxPostModel model, string SRNO)
        {
            PostDetails_Pagingation _Pagingation = new PostDetails_Pagingation();
            PostDetails _model = new PostDetails();
            if (SRNO == "0")
            {
                _model.SortColumn = "SRNO"; ;
                _model.SortOrder = "desc";
                _model.OffsetValue = 0;
                _model.PageSize = 10;
                _model.SearchText = model.search.value;
            }
            else
            {
                _model.SortColumn = "SRNO"; ;
                _model.SortOrder = "desc";
                _model.OffsetValue = 0;
                _model.PageSize = 10;
                _model.SearchText = null;
                _model.SRNO = Convert.ToInt32(SRNO);
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
        public ActionResult Login()
        {
            ViewBag.Message = "Login..";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel _loginmodel, string returnUrl)
        {
            User _user = new User();
            _user = _objDataAccessLayer.ValidateUserLogin(_loginmodel.UserName, _loginmodel.Password);

            if (_user.FLAG == 1)
            {
                Session["USER_ID"] =Convert.ToInt32(_user.USER_ID);
                return RedirectToAction("Index", "Dashboard", new { area = "Dashboard" });
            }
            else
            {
                return RedirectToAction("Login","Home");
            }
            //return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();

            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");

        }
    }
}