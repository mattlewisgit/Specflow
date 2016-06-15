namespace Vitality.Website.Areas.Presales.ComponentTemplates.FAQ
{
    using System.Collections.Generic;

    using Glass.Mapper.Sc.Configuration.Attributes;
    using Glass.Mapper.Sc.Fields;

    using Vitality.Website.Areas.Global.Models;

    public class FeaturedQuestions : SitecoreItem
    {
        public string Title { get; set; }

        public string Subtitle { get; set; }

        [SitecoreChildren]
        public IEnumerable<QuestionAnswer> Questions { get; set; }

        public Link CTA { get; set; }
    }
}