using System.Collections.Generic;
using System;

namespace Vitality.Website.Areas.Presales.Models
{
    public class OptalitixQuoteRequest
    {
        public string OptalitixQuoteId { get; set; }
        public int FamilySize { get; set; }
        public string QuoteReference { get; set; }
        public bool HasInsurance { get; set; }
        public bool ExistingCustomer { get; set; }
        public string YearsWithPreviousInsurer { get; set; }
        public string ClaimsWithPreviousInsurer { get; set; }
        public bool ContactOptIn { get; set; }
        public DateTime? StartOfCoverDate { get; set; }
        public string SessionID { get; set; }
        public string UserAgent { get; set; }
        public OptalitixMember MainMember { get; set; } = new OptalitixMember();
        public List<OptalitixMember> Dependents { get; set; } = new List<OptalitixMember>();
        public object Cookies { get; set; }
        public Dictionary<string, string> AdditionalParameters { get; set; } = new Dictionary<string, string>();
        public int NumQuotes { get; set; }
        public string UtmMedium { get; set; }
        public string UtmSource { get; set; }
        public string UtmCampaign { get; set; }
        public string UtmTerm { get; set; }
        public string UtmAdGroup { get; set; }
    }

}
