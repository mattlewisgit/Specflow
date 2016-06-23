namespace Vitality.Website.IntegrationTests.Steps
{
    using Shouldly;
    using TechTalk.SpecFlow;
    using PageObjects;
    using Utilities;
    using System.Collections.Specialized;

    [Binding]
    public class MetaTagsSteps : BaseSteps
    {
        private readonly PresalesPage presalesPage;
        private string source;

        public MetaTagsSteps(PresalesPage presalesPage)
        {
            this.presalesPage = presalesPage;
        }

        [When(@"I check the source")]
        public void WhenICheckTheSource()
        {
            source = Browser.PageSource;
        }

        [Then(@"I expect the (.*) to be in the source")]
        public void ThenIExpectTheToBeInTheSource(string p0)
        {
            StringCollection myTags = new StringCollection();

            switch (p0)
            {
                case "commonTags":
                    {
                        var myArr = new [] {
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

                        myTags.AddRange(myArr);

                        break;
                    }

                case "otherTags":
                    {
                        break;
                    }

            }

            foreach (var element in myTags)
            {
                Browser.PageSource.ShouldContain(element);
            }
        }
    }
}
