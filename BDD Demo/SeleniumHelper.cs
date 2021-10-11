using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace BDD_Demo
{
    public static class SeleniumHelper
    {
        public static IWebDriver Browser { get; set; }
        //{
        //    get
        //    {
        //        return WebDriver.Value;
        //    }
        //}

        public static ThreadLocal<IWebDriver> WebDriver { get; set; }

        public static void Click(this By by, uint timeoutSeconds = 5)
        {
            WaitForElement(by, timeoutSeconds).Click();
        }

        public static void Clear(this By by, uint timeoutSeconds = 5)
        {
            WaitForElement(by, timeoutSeconds).Clear();
        }

        public static void SendKeys(this By by, string text, uint timeoutSeconds = 5)
        {
            WaitForElement(by, timeoutSeconds).SendKeys(text);
        }

        private static IWebElement WaitForElement(By by, uint timeoutSeconds)
        {
            var wait = new WebDriverWait(Browser, TimeSpan.FromSeconds(timeoutSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }
    }
}
