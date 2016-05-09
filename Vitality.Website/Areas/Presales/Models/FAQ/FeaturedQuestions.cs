using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.Models.FAQ
{
    //[SitecoreType(Cachable = false)]
    public class FeaturedQuestions : SitecoreItem
    {
        [SitecoreField]
        public string Title { get; set; }

        [SitecoreField]
        public string Subtitle { get; set; }

        [SitecoreChildren]
        public IEnumerable<QuestionAnswer> Questions { get; set; }

        [SitecoreField]
        public Link CTA { get; set; }
    }
}