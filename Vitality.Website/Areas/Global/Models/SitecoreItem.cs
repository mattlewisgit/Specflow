using System.Collections.Generic;
using System.Linq;
using Glass.Mapper.Sc;

namespace Vitality.Website.Areas.Global.Models
{
    using System;

    using Glass.Mapper.Sc.Configuration;
    using Glass.Mapper.Sc.Configuration.Attributes;

    public class SitecoreItem
    {
        [SitecoreId]
        public Guid Id { get; set; }

        [SitecoreInfo(SitecoreInfoType.Name)]
        public string Name { get; set; }

        [SitecoreInfo(SitecoreInfoType.TemplateId)]
        public Guid TemplateId { get; set; }

        [SitecoreInfo(SitecoreInfoType.TemplateName)]
        public string TemplateName { get; set; }
        
        [SitecoreInfo(SitecoreInfoType.Path)]
        public string Path { get; set; }

        [SitecoreInfo(SitecoreInfoType.FullPath)]
        public string FullPath { get; set; }
        
        [SitecoreInfo(SitecoreInfoType.Url)]
        public string Url { get; set; }
    }
}