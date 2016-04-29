using System.Web.Mvc;

namespace Vitality.Website.Areas.Presales
{
    public class PresalesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Presales";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            /*context.MapRoute(
                "Presales_default",
                "Presales/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );*/
        }
    }
}