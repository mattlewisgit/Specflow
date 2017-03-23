using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;
using Sitecore;
using Sitecore.WFFM.Abstractions.Actions;
using Vitality.Website.SC.Extensions;

namespace Vitality.Website.SC.WFFM.Helpers
{
    internal static class FormFieldsHelper
    {
        private readonly static IReadOnlyDictionary<Guid, Func<string, string>> FieldValueConvertors
            = new Dictionary<Guid, Func<string, string>>
            {
                { WffmConstants.FieldTypes.Date, s => s.ToDateTime().ToShortDateString() },
                { WffmConstants.FieldTypes.DatePicker, s => s.ToDateTime().ToShortDateString() },
                { WffmConstants.FieldTypes.Checkbox, s => s.ToBoolean().ToString() }
            };

        internal static IDictionary<string, string> ExtractFormFields(AdaptedResultList formFields)
        {
            var today = DateTime.Today;

            var cookie = GetUtmCookie();

            return formFields
                .ToDictionary(
                    f => FormatFieldName(f.FieldName),
                    f => FormatFieldValue(Guid.Parse(f.FieldID), f.Value))
                .AddRange(new Dictionary<string, string>
                {
                    { "{TODAY}", today.ToShortDateString() },
                    { "{DAY}", today.Day.ToString("D2") },
                    { "{MONTH}", today.Month.ToString("D2") },
                    { "{YEAR}", today.Year.ToString() },
                    { "{NEXTMONTH}", today.AddMonths(1).ToShortDateString() },
                    { "{NEXTYEAR}", today.AddYears(1).ToShortDateString() },
                    { "{UTM_SOURCE}", cookie != null ? cookie[Constants.CookieSettings.UtmCookieSource] : null },
                    { "{UTM_MEDIUM}", cookie != null ? cookie[Constants.CookieSettings.UtmCookieMedium] : null },
                    { "{UTM_CAMPAIGN}", cookie != null ? cookie[Constants.CookieSettings.UtmCookieCampaign] : null},
                    { "{UTM_TERM}", cookie != null ? cookie[Constants.CookieSettings.UtmCookieTerm] : null },
                    { "{UTM_CONTENT}", cookie != null ? cookie[Constants.CookieSettings.UtmCookieContent] : null },
                    { "{REF_URL}", cookie != null? cookie[Constants.CookieSettings.RefUrl] : null }
                });
        }

        private static string FormatFieldName(string fieldName)
        {
            return string.Format("{{{0}}}", fieldName.Replace(" ", string.Empty).ToUpperInvariant());
        }

        private static string FormatFieldValue(Guid fieldId, string fieldValue)
        {
            return FieldValueConvertors.ContainsKey(fieldId)
                ? FieldValueConvertors[fieldId](fieldValue) : fieldValue;
        }

        private static bool ToBoolean(this string @string)
        {
            return StringComparer.OrdinalIgnoreCase.Equals(@string, "yes");
        }

        private static DateTime ToDateTime(this string @string)
        {
            return DateUtil.IsoDateToDateTime(@string, DateTime.MinValue);
        }

        public static NameValueCollection GetUtmCookie()
        {
            var httpCookie = HttpContext.Current.Request.Cookies[ConfigurationManager.AppSettings["UtmCookieName"]];

            if (httpCookie != null)
            {
                return httpCookie.Values;
            }

            return null;
        }
    }
}
