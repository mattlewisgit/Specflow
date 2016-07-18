namespace Vitality.Website.Extensions.Views
{
    using Glass.Mapper.Sc.Web.Mvc;

    using Vitality.Website.Areas.Presales.SettingsTemplates;
    using Vitality.Website.SC.Pipelines.HttpRequest;

    public static class CookieMessageExtensions
    {
        public static bool ShowCookieMessage(this GlassView<CookieSettings> view)
        {
            var cookieMessageCookie = view.Request.Cookies.Get(CookieMessage.Name);
            if (cookieMessageCookie != null)
            {
                return cookieMessageCookie.Value == CookieMessage.Show;
            }
            return true;
        }
    }
}