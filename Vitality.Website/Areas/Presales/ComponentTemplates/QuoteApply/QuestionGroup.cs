﻿using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.QuoteApply
{
    public class QuestionGroup : SitecoreItem
    {
        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<Question> Questions { get; set; }
        public string HelpText { get; set; }
        public string Label { get; set; }
        public string ValidationMessage { get; set; }
    }
}
