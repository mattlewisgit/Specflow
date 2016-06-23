using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.SettingsTemplates
{
    public class Website : SitecoreItem
    {
        public string GoogleSiteVerification { get; set; }
        public string BingSiteVerification { get; set; }
    }
}