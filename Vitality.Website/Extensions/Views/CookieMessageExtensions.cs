namespace Vitality.Website.Extensions.Views
{
    using System;

    using Glass.Mapper.Sc.Web.Mvc;

    using Areas.Presales.SettingsTemplates;

    public static class CookieMessageExtensions
    {
        private const string CookieMessageKey = "hasReadCookieMessage";

        public static bool ShowCookieMessage(this GlassView<CookieSettings> view)
        {
            if (view.IsInEditingMode)
            {
                return false;
            }

            var cookieMessageCookie = view.Request.Cookies.Get(CookieMessageKey);
            if (cookieMessageCookie != null)
            {
                return !cookieMessageCookie.Value.Equals("true", StringComparison.OrdinalIgnoreCase);
            }
            return true;
        }
    }
}
