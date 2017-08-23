using Glass.Mapper.Sc.Fields;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.QuoteApply
{
    public class Benefit : SitecoreItem
    {
        public bool IsEditable { get; set; }
        public Image Icon { get; set; }
        public string Title { get; set; }
        public string Tooltip { get; set; }
    }
}
