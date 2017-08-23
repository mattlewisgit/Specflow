using System;

namespace Vitality.Website.Areas.Presales.Models.QuoteApply
{
    public class QuoteApplication
    {
        public DateTime Child1Dob { get; set; }
        public DateTime Child2Dob { get; set; }
        public DateTime Child3Dob { get; set; }
        public DateTime Child4Dob { get; set; }
        public DateTime Child5Dob { get; set; }
        public DateTime CoverStartDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public int InsuredStatus { get; set; }
        public string LastName { get; set; }
        public bool MarketingPermission { get; set; }
        public int MembersToInsure { get; set; }
        public int NoOfChildren { get; set; }
        public int NoOfClaimFreeYears { get; set; }
        public string NoOfClaims { get; set; }
        public DateTime PartnerDateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Postcode { get; set; }
        public string Title { get; set; }
    }
}
