using BUSINESS_LOGIC_LAYER.Pages;
using log4net;
using log4net.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using Reqnroll.BoDi;

namespace TEST_AUTOMATION_LAYER.Hooks
{
    [Binding]
    public sealed class WebDriverHook
    {
        // For additional details on Reqnroll hooks see https://go.reqnroll.net/doc-hooks
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;
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
            // Example of filtering hooks using tags. (in this case, this 'before scenario' hook will execute if the feature/scenario contains the tag '@tag1')
            // See https://go.reqnroll.net/doc-hooks#tag-scoping

            //TODO: implement logic that has to run before executing each scenario

           
                _driver = new ChromeDriver();
                _driver.Manage().Window.Maximize();
                _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
          


        }

        //[BeforeScenario(Order = 1)]
        //public void FirstBeforeScenario()
        //{
        //    // Example of ordering the execution of hooks
        //    // See https://go.reqnroll.net/doc-hooks#hook-execution-order

        //    //TODO: implement logic that has to run before executing each scenario
        //}

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext,LoginPage loginPage)
        {
            //TODO: implement logic that has to run after executing each scenario
            if (scenarioContext.TestError != null)
            {
             loginPage.CaptureLoginScreenshot();               
            }
                _objectContainer.Resolve<IWebDriver>().Quit();
            _objectContainer.Resolve<IWebDriver>().Dispose();
        }
    }
}