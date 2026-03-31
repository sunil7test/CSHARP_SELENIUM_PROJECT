
using OpenQA.Selenium;

namespace BUSINESS_LOGIC_LAYER.Drivers
{
    public interface IDriverFactory
    {
        IWebDriver CreateDriver(BrowserType browser);
    }
}