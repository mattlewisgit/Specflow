using Glass.Mapper.Sc.Configuration.Attributes;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.Models.FAQ
{
    public class QuestionAnswer : SitecoreItem
    {
        [SitecoreField("Question Text")]
        public string QuestionText { get; set; }

        [SitecoreField]
        public string Preview { get; set; }

        [SitecoreField]
        public string Answer { get; set; }
    }
}