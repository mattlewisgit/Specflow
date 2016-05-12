namespace Vitality.Website.IntegrationTests.Steps
{
    using BoDi;

    using TechTalk.SpecFlow;

    using Vitality.Website.IntegrationTests.PageObjects;
    using Vitality.Website.IntegrationTests.Utilities;

    [Binding]
    public class CommonSteps : BaseSteps
    {
        private readonly IObjectContainer container;

        public CommonSteps(IObjectContainer container)
        {
            this.container = container;
        }

        [Given(@"I am on the (.*)")]
        public void GivenIAmOnThe(string p0)
        {
            Browser.Maximise().GoTo(AppSettings.Links.VitalityBaseUrl + p0);
            this.container.RegisterInstanceAs(new PresalesPage(WebDriver));
        }
    }
}
