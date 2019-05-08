using System.Web.Mvc;

namespace SiliconValley.InformationSystem.Web.Areas.dalei
{
    public class daleiAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "dalei";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "dalei_default",
                "dalei/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}