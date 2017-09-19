﻿using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Vitality.Website.Areas.Global.Models;
using Vitality.Website.Areas.Presales.ComponentTemplates.Generic;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.QuoteApply
{
    public class QuoteResult : SitecoreItem
    {
        public string PersonalisedGreetingText { get; set; }
        public string IntroductionText { get; set; }
        public Image PrimaryImage { get; set; }
        public Link AlternativeCallToAction { get; set; }
        public string AlternativeCallToActionText { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<Benefit> Benefits { get; set; }

        public Link CallToAction { get; set; }
        public string CallToActionText { get; set; }
        public string HelpText { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<Permutation> Permutations { get; set; }

        public string PrintText { get; set; }
        public string QuoteReferenceText { get; set; }
        public string QuoteValidText { get; set; }
        public Link ServiceOutagePage { get; set; }
        public string TooltipText { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<Content> MarketingMessages { get; set; }
        public string MarketingLoadingSubtitle { get; set; }
        public double MarketingMessageTimeOut{ get; set; }
    }
}
