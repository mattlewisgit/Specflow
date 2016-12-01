namespace Vitality.Website.IntegrationTests.Steps
{
    using System.Collections.Generic;

    using TechTalk.SpecFlow;
    using Utilities;

    using Vitality.Website.IntegrationTests.Extensions;

    [Binding]
    public class MetaTagsSteps : BaseSteps
    {
        private string pageSource;

        [When(@"I check the source")]
        public void WhenICheckTheSource()
        {
            this.pageSource = Browser.PageSource;
        }

        [Then(@"I expect the common meta tags to be in the source")]
        public void ThenIExpectTheToBeInTheSource()
        {
            this.pageSource.ShouldContainAll(CommonTags);
        }

        [Then(@"I expect the home meta tags to be in the source")]
        public void ThenIExpectTheHomeMetaTagsToBeInTheSource()
        {
            this.pageSource.ShouldContainAll(HomeTags);
        }

        [Then(@"I do not expect the home meta tags to be in the source")]
        public void ThenIDoNotExpectTheCommonTagsToBeInTheSource()
        {
            this.pageSource.ShouldNotContainAll(HomeTags);
        }

        private static IEnumerable<string> HomeTags
        {
            get
            {
                return new []
                    {
                        "<meta name=\"google-site-verification",
                        "<meta name=\"msvalidate.01"
                    };
            }
        }

        private static IEnumerable<string> CommonTags
        {
            get
            {
                return new []
                {
                    "<meta property=\"og:locale\" content=\"en_GB\"",
                    "<meta name=\"description",
                    "<meta property=\"og:title",
                    "<meta property=\"og:type",
                    "<meta property=\"og:image",
                    "<meta property=\"og:site_name",
                    "<meta property=\"og:description",
                    "<meta property=\"og:locale",
                    "<meta property=\"article:publisher",
                    "<meta property=\"al:ios:app_store_id\" content=\"794024908\"",
                    "<meta property=\"al:ios:app_name\" content=\"Vitality UK Member\"",
                    "<meta name=\"twitter:card\" content=\"summary_large_image\"",
                    "<meta name=\"twitter:site",
                    "<meta name=\"twitter:title",
                    "<meta name=\"twitter:description",
                    "<meta name=\"twitter:image",
                    "<meta name=\"twitter:app:id:iphone\" content=\"794024908\"",
                    "<meta name=\"twitter:app:name:iphone\" content=\"Vitality UK Member\"",
                    "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=Edge\"",
                    "<meta name=\"HandheldFriendly\" content=\"True\"",
                    "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\"",
                    "<meta charset=\"utf-8",
                    "<meta name=\"msapplication-navbutton-color\" content=\"#f41c5e\"",
                    "<meta name=\"application-name\" content=\"Vitality UK Member\"",
                    "<link rel=\"publisher\" href=\"https://plus.google.com/111924979311472229172\"",
                    "<meta name=\"apple-itunes-app\" content=\"app-id=794024908\"",
                    "<link rel=\"dns-prefetch\" href=\"https://join.vitality.co.uk/\"",
                    "<link rel=\"dns-prefetch\" href=\"https://quote.vitality.co.uk\"",
                    "<link rel=\"dns-prefetch\" href=\"https://member.vitality.co.uk\"",
                    "<meta name=\"referrer\" content=\"unsafe-url\"",
                    "<link rel=\"canonical",
                    "<meta name=\"referrer",
                    "<meta name=\"robots",
                    "<html xmlns:og=\"http://ogp.me/ns#\" xmlns:fb=\"http://www.facebook.com/2008/fbml\"",
                    "<meta property=\"article:publisher\" content=\"https://www.facebook.com/VitalityUK/\""
                };
            }
        }
    }
}
