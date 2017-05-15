using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;
using Sitecore;
using Sitecore.WFFM.Abstractions.Actions;
using Vitality.Mvc.Models;
using Vitality.Mvc.Utilities;

namespace Vitality.Website.SC.WFFM.Helpers
{
    using Core;

    internal static class FormFieldsHelper
    {
        private static readonly IReadOnlyDictionary<Guid, Func<string, string>> FieldValueConvertors
            = new Dictionary<Guid, Func<string, string>>
            {
                { WffmConstants.FieldTypes.Date, s => s.ToDateTime().ToShortDateString() },
                { WffmConstants.FieldTypes.DatePicker, s => s.ToDateTime().ToShortDateString() },
                { WffmConstants.FieldTypes.Checkbox, s => s.ToBoolean().ToString() }
            };

        internal static IDictionary<string, string> ExtractFormFields(AdaptedResultList formFields)
        {
            var today = DateTime.Today;

            var formFieldsDictionary =  formFields
                .ToDictionary(
                    f => FormatFieldName(f.FieldName),
                    f => FormatFieldValue(Guid.Parse(f.FieldID), f.Value))
                .AddRange(new Dictionary<string, string>
                {
                    {"{TODAY}", today.ToShortDateString()},
                    {"{DAY}", today.Day.ToString("D2")},
                    {"{MONTH}", today.Month.ToString("D2")},
                    {"{YEAR}", today.Year.ToString()},
                    {"{NEXTMONTH}", today.AddMonths(1).ToShortDateString()},
                    {"{NEXTYEAR}", today.AddYears(1).ToShortDateString()}
                });

            var utmCookie = UtmCookieHelper.GetUtmCookie(new HttpRequestWrapper(HttpContext.Current.Request));

            if (utmCookie != null)
            {
                var utmCookieSettings = UtmCookieSettings.Instance;

                formFieldsDictionary.Add($"{{{utmCookieSettings.UtmCookieCampaignKey.ToUpper()}}}", utmCookie[utmCookieSettings.UtmCookieCampaignKey]);
                formFieldsDictionary.Add($"{{{utmCookieSettings.UtmCookieContentKey.ToUpper()}}}", utmCookie[utmCookieSettings.UtmCookieContentKey]);
                formFieldsDictionary.Add($"{{{utmCookieSettings.UtmCookieMediumKey.ToUpper()}}}", utmCookie[utmCookieSettings.UtmCookieMediumKey]);
                formFieldsDictionary.Add($"{{{utmCookieSettings.UtmCookieRefUrlKey.ToUpper()}}}", utmCookie[utmCookieSettings.UtmCookieRefUrlKey]);
                formFieldsDictionary.Add($"{{{utmCookieSettings.UtmCookieSourceKey.ToUpper()}}}", utmCookie[utmCookieSettings.UtmCookieSourceKey]);
                formFieldsDictionary.Add($"{{{utmCookieSettings.UtmCookieTermKey.ToUpper()}}}", utmCookie[utmCookieSettings.UtmCookieTermKey]);
            }
            return formFieldsDictionary;
        }

        private static string FormatFieldName(string fieldName)
        {
            return $"{{{fieldName.Replace(" ", string.Empty).ToUpperInvariant()}}}";
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
    }
}
