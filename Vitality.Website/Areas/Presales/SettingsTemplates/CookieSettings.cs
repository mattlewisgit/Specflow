﻿namespace Vitality.Website.Areas.Presales.SettingsTemplates
{
    using Glass.Mapper.Sc.Configuration.Attributes;

    using Vitality.Website.Areas.Global.Models;

    [SitecoreType(Cachable = true)]
    public class CookieSettings : SitecoreItem
    {
        public string Message { get; set; }

        public string AcceptText { get; set; }

        public int ExpirationInDays { get; set; }
    }
}