using System.Collections.Generic;
using System;
using System.Linq;
using System.Collections.Specialized;
using Vitality.Website.Areas.Presales.Models;

namespace Vitality.Website.Areas.Presales.Services
{
    public static class OptalitixQuoteRequestFactory
    {
        public static OptalitixQuoteRequest From(SaveApplicationModel quoteApplyModel, NameValueCollection utmCookie, string referenceId)
        {
            var request = new OptalitixQuoteRequest
            {
                ClaimsWithPreviousInsurer = quoteApplyModel.NoOfClaims,
                ContactOptIn = quoteApplyModel.MarketingPermission,
                Dependents = GetMemberList(new List<DateTime?> {
                    quoteApplyModel.PartnerDateOfBirth.ToDateTime(),
                    quoteApplyModel.Child1Dob.ToDateTime(),
                    quoteApplyModel.Child2Dob.ToDateTime(),
                    quoteApplyModel.Child3Dob.ToDateTime(),
                    quoteApplyModel.Child4Dob.ToDateTime(),
                    quoteApplyModel.Child5Dob.ToDateTime() }),
                HasInsurance = quoteApplyModel.InsuredStatus,
                MainMember = new OptalitixMember
                {
                    DateOfBirth = quoteApplyModel.DateOfBirth.ToDateTime(),
                    EmailAddress = quoteApplyModel.EmailAddress,
                    FirstName = quoteApplyModel.FirstName,
                    LastName = quoteApplyModel.LastName,
                    PhoneNumber = quoteApplyModel.PhoneNumber,
                    Postcode = quoteApplyModel.Postcode,
                },
                StartOfCoverDate = quoteApplyModel.CoverStartDate.ToDateTime()
            };

            if (!string.IsNullOrEmpty(referenceId))
            {
                request.QuoteReference = referenceId;
                request.OptalitixQuoteId = referenceId;
            }

            if (utmCookie == null)
            {
                return request;
            }

            var utmCookieSettings = Mvc.Models.UtmCookieSettings.Instance;
            request.UtmCampaign = utmCookie[utmCookieSettings.UtmCookieCampaignKey];
            request.UtmMedium = utmCookie[utmCookieSettings.UtmCookieMediumKey];
            request.UtmSource = utmCookie[utmCookieSettings.UtmCookieSourceKey];
            request.UtmTerm = utmCookie[utmCookieSettings.UtmCookieTermKey];
            return request;
        }

        private static List<OptalitixMember> GetMemberList(IEnumerable<DateTime?> additionalMemberDob)
        {
            var members = new List<OptalitixMember>();
            foreach (var memberDob in additionalMemberDob.Where(x => x.HasValue))
            {
                members.Add(new OptalitixMember { DateOfBirth = memberDob.Value });
            }
            return members;
        }        
    }
}
