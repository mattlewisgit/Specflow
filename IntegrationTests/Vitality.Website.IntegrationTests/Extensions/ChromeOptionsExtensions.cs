namespace Kingfisher.Website.IntegrationTests.Extensions
{
    using OpenQA.Selenium.Chrome;
    using System;
    using System.Runtime.CompilerServices;

    public static class ChromeOptionsExtensions
    {

        public static ChromeOptions EnableAutomation(this ChromeOptions source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            string[] textArray1 = new string[] { "--enable-automation" };
            source.AddArguments(textArray1);
            return source;
        }

        public static ChromeOptions StartMaximised(this ChromeOptions source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            string[] textArray1 = new string[] { "--start-maximized" };
            source.AddArguments(textArray1);
            return source;
        }

    }
}
