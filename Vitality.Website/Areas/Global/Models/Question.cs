﻿using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace Vitality.Website.Areas.Global.Models
{
    public class Question : SitecoreItem
    {
        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public KeyValuePair ControlType { get; set; }
        public string DefaultValue { get; set; }
        public string Key { get; set; }
        public string Label { get; set; }
        public string Placeholder { get; set; }
        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<KeyValuePair>  RelatedData { get; set; }
        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<KeyValuePair> Validations { get; set; }
    }
}
