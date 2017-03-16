namespace Vitality.Website.Areas.Presales
{
    using System.Web.Mvc;

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
            // Method intentionally left empty.
        }
    }
}
