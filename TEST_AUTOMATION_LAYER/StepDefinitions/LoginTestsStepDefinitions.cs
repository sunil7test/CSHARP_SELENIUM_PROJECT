using System;
using BUSINESS_LOGIC_LAYER.Pages;
using Reqnroll;

namespace TEST_AUTOMATION_LAYER.StepDefinitions
{
    [Binding]
    public class LoginTestsStepDefinitions
    {
        private readonly LoginPage _loginPage;
       
        public LoginTestsStepDefinitions(LoginPage loginPage)
        {
            _loginPage = loginPage;
        }
        [Given("User opens the login page at {string}")]
        public void UserOpensTheLoginPageAt(string url)
        {
            Console.WriteLine("Opening login page at: " + url);
            _loginPage.launchLoginPage(url);
        }

        [When("User enters username {string} and password {string}")]
        public void UserEntersUsernameAndPassword(string username, string password)
        {
            Console.WriteLine($"Entering username: {username} and password: {password}");
            _loginPage.EnterUsername(username);
            _loginPage.EnterPassword(password);
        }

        [When("User click on the login button")]
        public void UserClickOnTheLoginButton()
        {
            Console.WriteLine("Clicking on the login button");
            _loginPage.ClickLoginButton();
        }

        [Then("User should be logged in successfully and see the message {string}")]
        public void UserShouldBeLoggedInSuccessfullyAndSeeTheMessage(string message)
        {
            var isLoginSuccessful = _loginPage.IsLoginSuccessfulMessageExists(message);
            Console.WriteLine("Verifying login success message: " + message+" is Displayed- ",isLoginSuccessful);
            if (!isLoginSuccessful)
            {
                _loginPage.CaptureLoginScreenshot();
                throw new Exception("Login was not successful or the expected message was not displayed.");
            }
           
        }

    }
}
