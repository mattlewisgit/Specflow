﻿using System.Collections.Generic;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.QuoteApply
{
    public class QuoteApplyFormViewModel
    {
        public string TermsAndCondition { get; set; }

        // Field Data
        public List<KeyValuePair<string, string>> CurrentInsuredStatuses { get; set; }
        public List<KeyValuePair<string, string>> Salutations { get; set; }

        // Field Labels
        public string ClaimFreeLabel { get; set; }
        public string ContactNumberLabel { get; set; }
        public string CoverForLabel { get; set; }
        public string CoverStartLabel { get; set; }
        public string CurrentlyInsuredLabel { get; set; }
        public string DateFormatLabel { get; set; }
        public string DateOfBirthLabel { get; set; }
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

        // Validation Messages
        public string ContactNumberValidation { get; set; }
        public string DateValidation { get; set; }
        public string EmailValidation { get; set; }
        public string NameValidation { get; set; }
    }
}

