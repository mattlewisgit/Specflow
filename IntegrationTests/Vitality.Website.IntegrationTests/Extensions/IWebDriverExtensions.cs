namespace Vitality.Website.IntegrationTests.Extensions
{
    using System;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using Selenium.WebDriver.Extensions.Core;

    // ReSharper disable once InconsistentNaming
    /// <summary>
    /// Provides extension methods for <see cref="IWebDriver">IWebDriver</see>.
    /// </summary>
    public static class IWebDriverExtensions
    {
        /// <summary>
        /// Default wait time.
        /// </summary>
        public static readonly TimeSpan DefaultWaitTimeSpan
            = TimeSpan.FromSeconds(5);

        /// <summary>
        /// Executes JavaScript and casts to the generic type.
        /// </summary>
        /// <typeparam name="T">To which the return type will be cast</typeparam>
        /// <param name="driver">Web driver</param>
        /// <param name="script">To run</param>
        /// <returns>Return value from JavaScript</returns>
        public static T ExecuteScript<T>(this IWebDriver driver, string script)
        {
            if (driver == null)
            {
                throw new ArgumentNullException("driver");
            }

            return (T)((IJavaScriptExecutor)driver).ExecuteScript(script);
        }

        /// <summary>
        /// Waits for the entire page to load using document ready state.
        /// </summary>
        /// <param name="driver">Web driver</param>
        /// <returns>Web driver</returns>
        public static IWebDriver WaitForPageLoad(this IWebDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException("driver");
            }

            new WebDriverWait(driver, DefaultWaitTimeSpan)
                .Until(d => d
                    .ExecuteScript<string>("return document.readyState")
                    .Equals("complete"));

            return driver;
        }

        /// <summary>
        /// Scrolls to an element on-screen.
        /// Useful for recorded tests to prove an element actually exists!
        /// </summary>
        /// <param name="driver">Web driver</param>
        /// <param name="element">To scroll to</param>
        /// <returns>Web driver</returns>
        public static IWebDriver ScrollToElement
            (this IWebDriver driver, ISearchContext element)
        {
            if (driver == null)
            {
                throw new ArgumentNullException("driver");
            }

            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            driver.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            return driver;
        }

        /// <summary>
        /// Waits for an element to appear using the
        /// <see cref="DefaultWaitTimeSpan">DefaultWaitTimeSpan</see>.
        /// </summary>
        /// <param name="driver">Web driver</param>
        /// <param name="by">Element selector</param>
        /// <returns>Web driver</returns>
        public static IWebElement WaitForElement(this IWebDriver driver, OpenQA.Selenium.By by)
        {
            if (driver == null)
            {
                throw new ArgumentNullException("driver");
            }

            new WebDriverWait(driver, DefaultWaitTimeSpan)
                .Until(d => d.FindElement(by));

            return driver.FindElement(by);
        }

        /// <summary>
        /// Waits for an element to appear using the
        /// <see cref="DefaultWaitTimeSpan">DefaultWaitTimeSpan</see>.
        /// </summary>
        /// <param name="driver">Web driver</param>
        /// <param name="selector">Element selector</param>
        /// <returns>Web driver</returns>
        public static IWebElement WaitForElement(this IWebDriver driver, SelectorBase selector)
        {
            if (driver == null)
            {
                throw new ArgumentNullException("driver");
            }

            new WebDriverWait(driver, DefaultWaitTimeSpan)
                .Until(d => d.FindElement(selector));

            return driver.FindElement(selector);
        }

        /// <summary>
        /// Waits for an element to be removed using the
        /// <see cref="DefaultWaitTimeSpan">DefaultWaitTimeSpan</see>.
        /// </summary>
        /// <param name="driver">Web driver</param>
        /// <param name="selector">Element selector</param>
        /// <returns>Web driver.</returns>
        public static IWebElement WaitToClear(this IWebDriver driver, SelectorBase selector)
        {
            if (driver == null)
            {
                throw new ArgumentNullException("driver");
            }

            new WebDriverWait(driver, DefaultWaitTimeSpan)
                .Until(d => d.FindElements(selector).Count < 1);

            return driver.FindElement(selector);
        }
    }
}
