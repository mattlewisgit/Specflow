using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Humanizer;
using Vitality.Website.Areas.Presales.ComponentTemplates.QuoteApply;

namespace Vitality.Website.Extensions.Views
{
    public static class AcknowledgementExtensions
    {
        private const string AsapText = "AsapText";
        private const string AtText = "AtText";
        private const string CallYouText = "CallYouText";
        private const string CbTime = "cbtime";
        private const string CbDate = "cbdate";
        private const string Name = "name";
        private const string OnText = "OnText";
        private const string Seperator = "Seperator";
        private const string Telephone = "telephone";
        private const string ThanksText = "ThanksText";
        private const string TomorrowText = "TomorrowText";

        public static string DisplayMessage
            (this Acknowledgement model, NameValueCollection queryParams)
        {
            var callbackTime = queryParams[CbTime];
            var callbackDateString = queryParams[CbDate];
            var onText = model.AdditionalData[OnText];

            var messageParts = new List<string>
            {
                model.AdditionalData[ThanksText],
                $"{queryParams[Name]}{model.AdditionalData[Seperator]}",
                model.AdditionalData[CallYouText]
            };


            DateTime callbackDate;
            if (DateTime.TryParse(callbackDateString, out callbackDate))
            {
                // Seleted Today but out of opening hours
                var isCallbackTimeAvailable = string.IsNullOrEmpty(callbackTime);
                if (callbackDate.Date == DateTime.Now.Date && isCallbackTimeAvailable)
                {
                    messageParts.Add(model.AdditionalData[TomorrowText]);
                }
                else
                {
                    var callbackDateFormatted = $"{callbackDate.Day.Ordinalize()} {callbackDate:MMMM}";
                    messageParts.Add(isCallbackTimeAvailable
                        ? $"{onText} {callbackDateFormatted}"
                        : $"{model.AdditionalData[AtText]} {callbackTime} {onText} {callbackDateFormatted}");
                }
            }
            else
            {
                messageParts.Add(model.AdditionalData[AsapText]);
            }
            messageParts.Add(onText);
            messageParts.Add(queryParams[Telephone]);
            return FormatMessage(messageParts);
        }

        private static string FormatMessage(IEnumerable<string> messageParts) => string.Join(" ", messageParts.Where(m => !string.IsNullOrEmpty(m)));
    }
}
