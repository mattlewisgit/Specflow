namespace Vitality.Website.Areas.Presales.ComponentTemplates.FAQ
{
    using Vitality.Website.Areas.Global.Models;

    public class QuestionAnswer : SitecoreItem
    {
        public string QuestionText { get; set; }

        public string Preview { get; set; }

        public string Answer { get; set; }
    }
}