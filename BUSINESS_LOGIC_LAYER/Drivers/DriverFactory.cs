
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace BUSINESS_LOGIC_LAYER.Drivers
{
    public class DriverFactory : IDriverFactory
    {
        public IWebDriver CreateDriver(BrowserType browser)
        {
            switch (browser)
            {
                case BrowserType.Chrome:
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--start-maximized");
                    return new ChromeDriver(chromeOptions);

                case BrowserType.Firefox:
                    var firefoxOptions = new FirefoxOptions();
                    return new FirefoxDriver(firefoxOptions);

                case BrowserType.Edge:
                    var edgeOptions = new EdgeOptions();
                    return new EdgeDriver(edgeOptions);

                default:
                    throw new System.ArgumentOutOfRangeException(nameof(browser), browser, null);
            }
        }
    }
}