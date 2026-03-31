using System;
using System.Collections.Generic;
using System.Text;
using CORE_SELENIUM_UTILITY_LAYER;
using OpenQA.Selenium;

namespace BUSINESS_LOGIC_LAYER.Pages
{
    public class LoginPage
    {
        private const string LoginSuccessMessageXPath = "*//h1[contains(text(),'Logged In Successfully')]";
        private const string LoginErrorMessageXPath = "*//div[contains(@class,'error-message')]";
        private const string UsernameFieldXPath = "*//input[@id='username']";
        private const string PasswordFieldXPath = "*//input[@id='password']";
        private const string LoginButtonXPath = "*//button[@id='submit']";
        private  IWebDriver Driver;
        //private  string URL = "https://www.saucedemo.com/";
        public   IWebElement UsernameField => Driver.CreateRetryPolicy().Execute(()=>Driver.FindElement( By.XPath(UsernameFieldXPath)));
        public   IWebElement PasswordField => Driver.CreateRetryPolicy().Execute(()=>Driver.FindElement(By.XPath(PasswordFieldXPath)));
        public IWebElement LoginButton => Driver.CreateRetryPolicy().Execute(()=>Driver.FindElement(By.XPath(LoginButtonXPath)));

        public IWebElement LoginSuccessMessage => Driver.CreateRetryPolicy().Execute(()=>Driver.FindElement(By.XPath(LoginSuccessMessageXPath)));
        public LoginPage(IWebDriver driver)
        {
            Driver = driver;
        }
        public void launchLoginPage(string url)
        {
            Driver.OpenUrl(url);
        }
        public void EnterUsername(string username)
        {
            UsernameField.EnterText(username);
        }
        public void EnterPassword(string password)
        {
            PasswordField.EnterText(password);
        }
        public void ClickLoginButton()
        {
            LoginButton.ClickElement();
        }
        public void Login(string username, string password)
        {
            UsernameField.EnterText(username);
            PasswordField.EnterText(password);
            LoginButton.ClickElement();
        }
        public void CaptureLoginScreenshot(string folder = "screenshots") => Driver.CaptureScreenshot(folder, "loginpage");
           
        public bool IsLoginSuccessfulMessageExists(string message)
        {
           return Driver.IsElementContainsText(LoginSuccessMessage, TimeSpan.FromSeconds(10),message);
        }

    }
}
