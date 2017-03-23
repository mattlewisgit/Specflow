using System;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Vitality.Website.Areas.Global.Models;
using Vitality.Website.Areas.Presales.SettingsTemplates;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.ContentCollection
{
    [SitecoreType(AutoMap = true)]
    public class SocialMediaItem : SitecoreItem
    {
        public SocialMediaItem()
        {
            Icon = new Image();
        }

        public string BackgroundColor { get; set; }
        public Link CallToAction { get; set; }
        public string CountDisplayText { get; set; }
        public Image Icon { get; set; }
        public string LeadIn { get; set; }
        // Only retriev ID as the full object needs to be retrieved back again 
        // As App key and secrete should not be passed from Client side
        [SitecoreField("Settings")]
        public Guid SettingsId { get; set; }
    }
}
