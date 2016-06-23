namespace Vitality.Website.IntegrationTests.Steps
{
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
            this.pageSource.ShouldContainAll(this.CommonTags);
        }

        [Then(@"I expect the home meta tags to be in the source")]
        public void ThenIExpectTheHomeMetaTagsToBeInTheSource()
        {
            this.pageSource.ShouldContainAll(this.HomeTags);
        }

        [Then(@"I do not expect the home meta tags to be in the source")]
        public void ThenIDoNotExpectTheCommonTagsToBeInTheSource()
        {
            this.pageSource.ShouldNotContainAll(this.HomeTags);
        }

        private string[] HomeTags
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

        private string[] CommonTags
        {
            get
            {
                return new [] 
                    {
                        "<meta name=\"description",
                        "<meta property=\"og:title",
                        "<meta property=\"og:type",
                        "<meta property=\"og:image",
                        "<meta property=\"og:site_name",
                        "<meta property=\"og:description",
                        "<meta property=\"og:locale",
                        "<meta property=\"article:publisher",
                        "<meta property=\"al:ios:app_store_id",
                        "<meta property=\"al:ios:app_name",
                        "<meta name=\"twitter:card",
                        "<meta name=\"twitter:site",
                        "<meta name=\"twitter:title",
                        "<meta name=\"twitter:description",
                        "<meta name=\"twitter:image",
                        "<meta name=\"twitter:app:id:iphone",
                        "<meta name=\"twitter:app:name:iphone",
                        "<meta http-equiv=\"X-UA-Compatible",
                        "<meta name=\"HandheldFriendly",
                        "<meta name=\"viewport",
                        "<meta charset=\"utf-8",
                        "<meta name=\"msapplication-navbutton-color",
                        "<meta name=\"application-name",
                        "<link rel=\"publisher",
                        "<meta name=\"apple-itunes-app"
                    };
            }
        }
    }
}
