using System;
using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.QuoteApply
{
    public class BenefitOption : SitecoreItem
    {
        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public KeyValuePair Code { get; set; }
        public string Description { get; set; }
        public IEnumerable<Guid> Permutations { get; set; }
        public string Title { get; set; }
    }
}
