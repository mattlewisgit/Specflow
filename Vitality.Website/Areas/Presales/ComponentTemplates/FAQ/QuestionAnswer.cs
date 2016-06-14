using Glass.Mapper.Sc.Configuration.Attributes;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.Models.FAQ
{
    public class QuestionAnswer : SitecoreItem
    {
        public string QuestionText { get; set; }

        public string Preview { get; set; }

        public string Answer { get; set; }
    }
}