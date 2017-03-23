namespace Vitality.Website.Areas.Presales.ComponentTemplates.FAQ
{
    using Glass.Mapper.Sc.Fields;

    using Vitality.Website.Areas.Global.Models;

    public class FaqPreview : SitecoreItem
    {
        public string QuestionText { get; set; }

        public string AnswerText { get; set; }

        public Link ReadMoreLink { get; set; }
    }
}
