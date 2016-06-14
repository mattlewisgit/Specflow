using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Fields;
using Vitality.Website.Areas.Global.Models;
using Vitality.Website.Areas.Presales.BaseTemplates;

namespace Vitality.Website.Areas.Presales.PageTemplates
{
    public class BasePage : SitecoreItem, IDuplicateContentPage, IIndexationPage, IOpenGraphPage, ISerpAppearancePage, ITwitterPage
    {
        public string Canonical { get; set; }
        public string Robots { get; set; }
        public string OpenGraphTitle { get; set; }
        public string OpenGraphType { get; set; }
        public string OpenGraphUrl { get; set; }
        public Image OpenGraphImage { get; set; }
        public string OpenGraphSiteName { get; set; }
        public string OpenGraphDescription { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TwitterSite { get; set; }
        public string TwitterTitle { get; set; }
        public string TwitterDescription { get; set; }
        public Image TwitterImage { get; set; }
    }
}