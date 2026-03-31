using System.IO;
using BUSINESS_LOGIC_LAYER.Pages;
using BUSINESS_LOGIC_LAYER.Drivers;
using log4net;
using log4net.Config;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;

namespace TEST_AUTOMATION_LAYER.Hooks
{
    [Binding]
    public sealed class WebDriverHook
    {
        private readonly IObjectContainer _objectContainer;
        private static readonly ILog log = LogManager.GetLogger(typeof(WebDriverHook));

        public WebDriverHook(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("Log4NetConfig.xml"));
            log.Info("Automated test execution started.");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            log.Info("Automated test execution finished.");
        }

        [BeforeScenario("@smoke")]
        public void BeforeScenarioWithTag()
        {
            // Create/register factory (can be registered into container if you want DI)
            var factory = new DriverFactory();

            // Initialize singleton once per process/test-run as needed
            WebDriverSingleton.Instance.Initialize(factory, BrowserType.Chrome);

            // Register the singleton's driver instance into the object container so other classes (e.g., pages) can resolve IWebDriver
            _objectContainer.RegisterInstanceAs<IWebDriver>(WebDriverSingleton.Instance.Driver);
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext, LoginPage loginPage)
        {
            if (scenarioContext.TestError != null)
            {
                try { loginPage.CaptureLoginScreenshot(); } catch { /* best effort */ }
            }

            // Best place to cleanup the singleton driver:
            WebDriverSingleton.Instance.QuitAndDispose();
        }
    }
}