using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.QuoteApply
{
    using  Global.Models;

    public class QuoteApplyForm : SitecoreItem
    {
        public string TermsAndCondition { get; set; }

        // Field Data
        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<KeyValuePair> CurrentInsuredStatusData { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<LinkItem> TitleData { get; set; }


        // Field Labels
        public string ClaimFreeLabel { get; set; }
        public string ContactNumberLabel { get; set; }
        public string CoverForLabel { get; set; }
        public string CoverStartLabel { get; set; }
        public string CurrentlyInsuredLabel { get; set; }
        public string DateFormatLabel { get; set; }
        public string DateOfBirthlabel { get; set; }
        public string DobSeperatorLabel { get; set; }
        public string EmailLabel { get; set; }
        public string FirstNameLabel { get; set; }
        public string KidsPreLabel { get; set; }
        public string KidsPostLabel { get; set; }
        public string LastDobSeperatorLabel { get; set; }
        public string LastNameLabel { get; set; }
        public string NameLabel { get; set; }
        public string NoOfClaimsPreLabel { get; set; }
        public string NoOfClaimsPostLabel { get; set; }
        public string PartnerDateOfBirthLabel { get; set; }

        // Field Help Texts
        public string CoverStartHelpTexts { get; set; }
        public string EmailHelpTexts { get; set; }
    }
}

