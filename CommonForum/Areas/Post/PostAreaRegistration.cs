using System.Web.Mvc;

namespace CommonForum.Areas.Post
{
    public class PostAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Post";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Post_default",
                "Post/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}