using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Polly;
using Polly.Retry;
namespace CORE_SELENIUM_UTILITY_LAYER
{
    public static class DriverUtility
    {
        public static void CaptureScreenshot(this IWebDriver driver, string folder = "screenshots", string? fileName = null)
        {
            if (driver is ITakesScreenshot ts)
            {
                Directory.CreateDirectory(folder);
                var timestamp = DateTime.UtcNow.ToString("yyyyMMdd_HHmmss_fff");
                var safeName = string.IsNullOrWhiteSpace(fileName) ? $"screenshot_{timestamp}.png" : $"{fileName}_{timestamp}.png";
                var path = Path.Combine(folder, safeName);
                var screenshot = ts.GetScreenshot();
                screenshot.SaveAsFile(path);
               
            }
            else throw new NotSupportedException("Driver does not support screenshots");
        }

        public static void WaitForElement(this IWebDriver driver, IWebElement locator, TimeSpan timeout)
        {
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, timeout);
            wait.Until(drv => locator.Displayed);
        }
        public static bool IsElementContainsText(this IWebDriver driver, IWebElement locator, TimeSpan timeout,string message)
        {
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, timeout);
           return wait.Until(drv => locator.Displayed && locator.Text.Equals(message));
        }
        public static void OpenUrl(this IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }


        public static RetryPolicy CreateRetryPolicy(this IWebDriver driver)
        {
            // Placeholder for retry policy implementation
         var retryPolicy=   Policy.Handle<NoSuchElementException>()
                         .Or<StaleElementReferenceException>()
                          .WaitAndRetry(retryCount:4, retryAttempt => TimeSpan.FromSeconds(5),
                           onRetry:(exception,timespan,retryCount,context)=>
                            {
                                Console.WriteLine($"Retry {retryCount} after {timespan.TotalSeconds} seconds due to: {exception.Message}");
                             });
            return retryPolicy;

        }
    }
}
