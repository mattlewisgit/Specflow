namespace Vitality.Website.IntegrationTests.Extensions
{
    using System;
    using System.Collections.Generic;
    using Kingfisher.Website.IntegrationTests.Steps;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using Shouldly;
    using Xunit;
    using By = OpenQA.Selenium.By;

    public class WaitExtensions : BaseSteps
    {

        public static void ClickAndWaitForPageToLoad(By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeout));
                var element = WebDriver.FindElement(elementLocator);
                element.Click();
                wait.Until(ExpectedConditions.StalenessOf(element));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }



        //this will search for the element until a timeout is reached
        public static IWebElement WaitUntilElementClickable(By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }
    }
}
