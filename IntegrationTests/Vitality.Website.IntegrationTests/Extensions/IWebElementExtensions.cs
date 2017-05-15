using OpenQA.Selenium;
using System;

namespace Vitality.Website.IntegrationTests.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="IWebElement">web elements</see>.
    /// </summary>
    public static class IWebElementExtensions
    {
        /// <summary>
        /// Clears the elements and returns it fluently.
        /// </summary>
        /// <param name="source">Web element</param>
        /// <returns>Web element</returns>
        /// <exception cref="ArgumentNullException">When the element is null</exception>
        public static IWebElement ClearAndContinue(this IWebElement source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            source.Clear();
            return source;
        }

        /// <summary>
        /// Clicks the elements and returns it fluently.
        /// </summary>
        /// <param name="source">Web element</param>
        /// <returns>Web element</returns>
        /// <exception cref="ArgumentNullException">When the element is null</exception>
        public static IWebElement ClickAndContinue(this IWebElement source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            source.Click();
            return source;
        }

        /// <summary>
        /// Gets the immediate parent element.
        /// </summary>
        /// <param name="source">To search</param>
        /// <returns>Parent element if it exists</returns>
        public static IWebElement GetParent(this IWebElement source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            return source.FindElement(By.XPath(".."));
        }
    }
}
