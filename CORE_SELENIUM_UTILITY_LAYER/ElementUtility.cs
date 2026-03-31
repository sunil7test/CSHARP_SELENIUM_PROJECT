using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using OpenQA.Selenium;

namespace CORE_SELENIUM_UTILITY_LAYER
{
    public static class ElementUtility
    {
        private static TimeSpan DefaultTimeout => TimeSpan.FromSeconds(10);
        public static void ClickElement(this IWebElement locator)
        {
            locator.Click();
        }
        public static void SubmitElement(this IWebElement locator)
        {
            locator.Submit();
        }
        public static void EnterText(this IWebElement locator, string text)
        {
            locator.Clear();
            locator.SendKeys(text);
        }
    }
}
