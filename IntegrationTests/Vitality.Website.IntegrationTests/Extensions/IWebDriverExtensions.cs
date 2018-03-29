namespace Kingfisher.Website.IntegrationTests.Extensions
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using Selenium.WebDriver.Extensions.Core;
    using System;
    using System.Runtime.CompilerServices;
    using By = OpenQA.Selenium.By;

    public static class IWebDriverExtensions
    {
        public static TimeSpan DefaultWaitTimeSpan = TimeSpan.FromSeconds(10.0);
        public static IWebDriver WaitForPageLoad(this IWebDriver driver)

        {
            if (driver == null)
            {
                throw new ArgumentNullException("driver");
            }
            new WebDriverWait(driver, DefaultWaitTimeSpan).Until<bool>(d => WebDriverExtensions.ExecuteScript<string>(d, "return document.readyState", new object[0]).Equals("complete"));
            return driver;
        }


        public static IWebElement WaitForElement(this IWebDriver driver, SelectorBase selector)
        {
            if (driver == null)
            {
                throw new ArgumentNullException("driver");
            }
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }
            new WebDriverWait(driver, DefaultWaitTimeSpan).Until<WebElement>(d => WebDriverExtensions.FindElement(d, selector));
            return WebDriverExtensions.FindElement(driver, selector);
        }

        public static IWebDriver ScrollToElement(this IWebDriver driver, string cssSelector)
        {
            if (driver == null)
            {
                throw new ArgumentNullException("driver");
            }
            if (string.IsNullOrWhiteSpace(cssSelector))
            {
                throw new ArgumentNullException("cssSelector");
            }
            WebDriverExtensions.ExecuteScript(driver, $"$('{cssSelector}')[0].scrollIntoView();", new object[0]);
            return driver;
        }

        public static IWebDriver WaitForAngular(this IWebDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException("driver");
            }
            new WebDriverWait(driver, DefaultWaitTimeSpan).Until<bool>(d => WebDriverExtensions.ExecuteScript<bool>(d, "return !!(window.jQuery && window.ng && $('*[ng-version]').length)", new object[0]));
            return driver;
        }

        public static IWebElement WaitForElement(this IWebDriver driver, By by)
        {
            if (driver == null)
            {
                throw new ArgumentNullException("driver");
            }
            if (by == null)
            {
                throw new ArgumentNullException("by");
            }
            new WebDriverWait(driver, DefaultWaitTimeSpan).Until<IWebElement>(d => d.FindElement(by));
            return driver.FindElement(by);
        }

        public static IWebDriver WaitToClear(this IWebDriver driver, SelectorBase selector)
        {
            if (driver == null)
            {
                throw new ArgumentNullException("driver");
            }
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }
            new WebDriverWait(driver, DefaultWaitTimeSpan).Until<bool>(d => WebDriverExtensions.FindElements(d, selector).Count < 1);
            return driver;
        }


    }
}
