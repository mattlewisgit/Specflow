using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.Generic
{
    public class MessageBox : SitecoreItem
    {
        public string MessageHeading { get; set; }
        public string MessageText { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public KeyValuePair MessageType { get; set; }
    }
}
