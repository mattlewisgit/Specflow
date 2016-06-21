using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.Models.FAQ
{
    using Glass.Mapper.Sc.Fields;

    public class FaqPreview : SitecoreItem
    {
        public string QuestionText { get; set; }

        public string AnswerText { get; set; }

        public Link ReadMoreLink { get; set; }
    }
}