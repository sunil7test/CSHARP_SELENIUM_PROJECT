
using System;
using OpenQA.Selenium;

namespace BUSINESS_LOGIC_LAYER.Drivers
{
    // Lazy, per-scenario provider. Does not create the IWebDriver until .Driver is accessed.
    public sealed class PerScenarioWebDriverProvider : IDisposable
    {
        private readonly Lazy<IWebDriver> _lazyDriver;
        private bool _disposed;

        public PerScenarioWebDriverProvider(IDriverFactory factory, BrowserType browser)
        {
            if (factory == null) throw new ArgumentNullException(nameof(factory));
            _lazyDriver = new Lazy<IWebDriver>(() => factory.CreateDriver(browser));
        }

        public IWebDriver Driver => _lazyDriver.Value;

        public bool IsValueCreated => _lazyDriver.IsValueCreated;

        public void Dispose()
        {
            if (_disposed) return;
            if (_lazyDriver.IsValueCreated)
            {
                try
                {
                    _lazyDriver.Value.Quit();
                }
                catch { /* best-effort cleanup */ }

                try
                {
                    _lazyDriver.Value.Dispose();
                }
                catch { /* best-effort cleanup */ }
            }
            _disposed = true;
        }
    }
}