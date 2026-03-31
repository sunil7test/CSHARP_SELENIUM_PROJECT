
using System;
using OpenQA.Selenium;

namespace BUSINESS_LOGIC_LAYER.Drivers
{
    public sealed class WebDriverSingleton
    {
        private static readonly Lazy<WebDriverSingleton> _instance = new(() => new WebDriverSingleton());
        private IWebDriver? _driver;
        private readonly object _lock = new();

        private WebDriverSingleton() { }

        public static WebDriverSingleton Instance => _instance.Value;

        public bool IsInitialized => _driver != null;

        public IWebDriver Driver
        {
            get
            {
                if (_driver == null) throw new InvalidOperationException("WebDriver not initialized. Call Initialize(...) first.");
                return _driver;
            }
        }

        public void Initialize(IDriverFactory factory, BrowserType browser)
        {
            if (factory == null) throw new ArgumentNullException(nameof(factory));
            lock (_lock)
            {
                if (_driver == null)
                {
                    _driver = factory.CreateDriver(browser);
                }
            }
        }

        public void QuitAndDispose()
        {
            lock (_lock)
            {
                if (_driver == null) return;
                try
                {
                    _driver.Quit();
                }
                catch { /* best effort */ }
                try
                {
                    _driver.Dispose();
                }
                catch { /* best effort */ }
                _driver = null;
            }
        }
    }
}