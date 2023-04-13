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
        public ActionResult Signup()
        {
            ViewBag.Message = "";

            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(LoginModel _loginmodel, string returnUrl)
        //{
        //    User _user = new User();
        //    _user = _objDataAccessLayer.ValidateUserLogin(_loginmodel.UserName, _loginmodel.Password);

        //    if (_user.FLAG == 1)
        //    {
        //        Session["_USER_ID"] =Convert.ToInt32(_user.USER_ID);
        //        return RedirectToAction("Index", "Dashboard", new { area = "Dashboard" });
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login","Home");
        //    }
        //    //return View();
        //}
        [HttpPost]
        public JsonResult Login(LoginModel _loginmodel)
        {
            UserDetailsModel _list = new UserDetailsModel();
            User _user = new User();

            _user = _objDataAccessLayer.ValidateUserLogin(_loginmodel.UserName, _loginmodel.Password);
            Session["_USER_ID"] = Convert.ToInt32(_user.USER_ID);
            Session["_USER_NAME"] = Convert.ToString(_user.USER_NAME);
            Session["_EMAIL_ID"] = Convert.ToString(_user.EMAIL_ID);


            return Json(new { data= _user });
        }
        [HttpPost]
        public JsonResult Signup(Signup _model)
        {
            bool Return = false;
            bool IsRegisterUser = false;
            Return = _objDataAccessLayer.ValidateUserEmail(_model);
            string message = string.Empty;

            switch (Return)
            {
                case true:
                    message = "Supplied email address has already been used.";
                    break;
                case false:
                    IsRegisterUser=RegisterUser(_model);
                    message = "Registration successful, please check your email to verify email id.";
                    break;
                default:
                    message = "Enabled to process your request.";
                    break;
            }
            ViewBag.Message = message;

            return Json(new { data = IsRegisterUser });
        }
        public bool RegisterUser(Signup _model)
        {
            Guid USERID = Guid.NewGuid();
            _model.USER_GUID = USERID;
            Guid activationCode = Guid.NewGuid();
            _model.ActivationCode = activationCode;

            bool Return = true;
            Return =_objDataAccessLayer.Signup(_model);
            if (Return)
            {
                SendEmail(_model);
            }
            else
            {

            }
            return Return;
        }
        public void SendEmail(Signup _model)
        {

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