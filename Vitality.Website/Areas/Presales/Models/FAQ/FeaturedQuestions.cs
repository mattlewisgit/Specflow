using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.Models.FAQ
{
    public class FeaturedQuestions : SitecoreItem
    {
        public string Title { get; set; }

        public string Subtitle { get; set; }

        [SitecoreChildren]
        public IEnumerable<QuestionAnswer> Questions { get; set; }

        public Link CTA { get; set; }
    }
}