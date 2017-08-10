using System;
using System.Collections.Specialized;
using Humanizer;
using Shouldly;
using Vitality.Website.Areas.Presales.ComponentTemplates.QuoteApply;
using Vitality.Website.Extensions.Views;
using Xunit;
using System.Globalization;
using System.Threading;

namespace Vitality.Website.UnitTests.Extensions.View
{
    public class AcknowledgementExtensionsTests
    {
        public class DisplayMessage
        {
            private readonly Acknowledgement _model;
            private readonly NameValueCollection _queryParams;
            private readonly string _futureDateString;
            private readonly string _todayString;
            private readonly string _futureDateFormatted;
            private readonly string _todayFormatted;
            private const string Telephone = "01202743214";
            public DisplayMessage()
            {
                // Enforce current culture...
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

                _model = new Acknowledgement
                {
                    AdditionalData = new NameValueCollection
                    {
                        {"CallYouText", "we'll call you back"},
                        {"ThanksText", "Thanks"},
                        {"AsapText", "in the next half an hour"},
                        {"AtText", "at"},
                        {"TomorrowText", "next working day"},
                        {"OnText", "on"},
                        {"Seperator", ","}
                    }
                };
                _queryParams = new NameValueCollection
                {
                    {"name", "Joe"},
                    {"telephone", Telephone},
                };
                var today = DateTime.Now;
                var futureDate = today.AddDays(5);
                _todayString = $"{today:dd/MM/yyyy}";
                _futureDateString = $"{futureDate:dd/MM/yyyy}";
                _todayFormatted =  $"{today.Day.Ordinalize()} {today:MMMM}";
                _futureDateFormatted = $"{futureDate.Day.Ordinalize()} {futureDate:MMMM}";
            }

            [Fact]
            public void Callback_future_date_and_time_available()
            {
                _queryParams.Add("cbdate", _futureDateString);
                _queryParams.Add("cbtime", "10:00 - 10:30");
                _model.DisplayMessage(_queryParams)
                    .ShouldBe($"Thanks Joe, we'll call you back at 10:00 - 10:30 on {_futureDateFormatted} on {Telephone}");
            }

            [Fact]
            public void Callback_future_date_no_time_available()
            {
                _queryParams.Add("cbdate", _futureDateString);
                _model.DisplayMessage(_queryParams)
                    .ShouldBe($"Thanks Joe, we'll call you back on {_futureDateFormatted} on {Telephone}");
            }

            [Fact]
            public void Callback_today_and_time_available()
            {
                _queryParams.Add("cbdate", _todayString);
                _queryParams.Add("cbtime", "10:00 - 10:30");
                _model.DisplayMessage(_queryParams)
                    .ShouldBe($"Thanks Joe, we'll call you back at 10:00 - 10:30 on {_todayFormatted} on {Telephone}");
            }

            [Fact]
            public void Callback_today_no_time_available()
            {
                _queryParams.Add("cbdate", _todayString);
                _model.DisplayMessage(_queryParams)
                    .ShouldBe($"Thanks Joe, we'll call you back next working day on {Telephone}");
            }

            [Fact]
            public void Callback_no_date_no_time_available()
            {
                _model.DisplayMessage(_queryParams)
                    .ShouldBe($"Thanks Joe, we'll call you back in the next half an hour on {Telephone}");
            }
        }
    }
}
