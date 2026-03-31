using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using BUSINESS_LOGIC_LAYER.Pages;

namespace TEST_AUTOMATION_LAYER
{
    public class Testscs
    {
        private IWebDriver driver;
        [SetUp] public void SetUp() {

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
            driver.Manage().Window.Maximize();
        }
        [TearDown] public void TearDown() {
        if (driver != null)
            {
                driver.Quit();
            }
        }
         [Test] public void Test1() { 
        
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login("student", "Password123");
            loginPage.CaptureLoginScreenshot();
            //if (driver is ITakesScreenshot ts)
            //{
            //    Directory.CreateDirectory("screenshots");
            //    var timestamp = DateTime.UtcNow.ToString("yyyyMMdd_HHmmss_fff");
            //    var safeName = string.IsNullOrWhiteSpace("loginpage") ? $"screenshot_{timestamp}.png" : $"{"loginpage"}_{timestamp}.png";
            //    var path = Path.Combine("screenshots", safeName);
            //    var screenshot = ts.GetScreenshot();
            //    screenshot.SaveAsFile(path);

            //}


        }
    }
}
