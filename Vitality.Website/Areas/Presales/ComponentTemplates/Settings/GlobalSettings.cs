using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vitality.Website.Areas.Presales.Models.Settings
{
    public class GlobalSettings
    {
        public string OpenGraphUrl { get; set; }
        public string OpenGraphFacebokUrl { get; set; }
        public string OpenGraphLocale { get; set; }
        public string OpenGraphArticlePublisher { get; set; }
        public string OpenGraphIosAppStoreId { get; set; }
        public string OpenGraphIosAppStoreName { get; set; }

        public string TwitterCard { get; set; }
        public string TwitterSite { get; set; }
        public string S { get; set; }
    }
}