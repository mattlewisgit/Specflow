using System.Collections.Generic;
using System.Collections.Specialized;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.Generic
{
    public class CountdownTimer : SitecoreItem
    {
        public NameValueCollection Labels { get; set; }
        public string RichText { get; set; }
    }
}
