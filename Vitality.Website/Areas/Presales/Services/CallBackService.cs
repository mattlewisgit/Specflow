using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;
using Sitecore.Data;
using Vitality.Core;
using Vitality.Mvc.Models;
using Vitality.Mvc.Utilities;
using Vitality.Website.Areas.Presales.Handlers.CallBack;
using Vitality.Website.Areas.Presales.Models;
using Vitality.Website.SC.WFFM;

namespace Vitality.Website.Areas.Presales.Services
{
    public class CallBackService : ICallBackService
    {
        public async Task<HttpResponseMessage> Post(CallBackPostRequest postData)
        {
            var dict = CreateCallProData(postData);
            return await CallProConnector.CreateCallProData(dict);
        }

        public static Dictionary<string, string> CreateCallProData(CallBackPostRequest callBackPostRequest)
        {
            var today = new DateTime();

            var formFieldsDictionary = new Dictionary<string, string>
            {
                {"{TODAY}", today.ToShortDateString()},
                {"{DAY}", today.Day.ToString("D2")},
                {"{MONTH}", today.Month.ToString("D2")},
                {"{YEAR}", today.Year.ToString()},
                {"{NEXTMONTH}", today.AddMonths(1).ToShortDateString()},
                {"{NEXTYEAR}", today.AddYears(1).ToShortDateString()},
                {"{TELEPHONENUMBER}", callBackPostRequest.PostData.Telephone},
                {"{TITLE}", callBackPostRequest.PostData.Title},
                {"{FIRSTNAME}", callBackPostRequest.PostData.Firstname},
                {"{SURNAME}", callBackPostRequest.PostData.Lastname},
                {"{EMAIL}", callBackPostRequest.PostData.Email},
                {"{ANAL88}", callBackPostRequest.PostData.CallBackTime}
            };

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
    }
}