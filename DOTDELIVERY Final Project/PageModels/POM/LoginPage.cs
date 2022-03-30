using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTDELIVERY_Final_Project.PageModels.POM
{
    class LoginPage : BasePage
    {

        const string emailSelector = "_loginEmail"; // id
        const string errorMessageSelector = "error"; // class
        const string passwordSelector = "_loginPassword"; //id
        const string loginButtonSelector = "doLogin"; //id
        const string loginLabelSelector = "//*[@id=\"register-page\"]/div/div[1]/div/div[1]/h1"; //xpath
        const string accountButtonSelector = "//*[@id=\"wrapper\"]/header/div[2]/div/div/div[3]/ul/li[1]/a/span"; //xpath

        const string loginErrorMessageSelector = "error"; //class
        const string logoutButtonSelector = "//*[@id=\"wrapper\"]/div[3]/div/div[1]/div[2]/ul[5]/li/a"; //xpath
        const string forgotPassSelector = "client-pass-recov"; //class
        const string forgotPassLabelSelector = "head-pp"; //class
        const string emailInputSelector = "#passwordRecovery > div.login-holder > div:nth-child(2) > div > input"; //css
        const string emailErrorMsgSelector = "hint-order"; //class
        const string submitButtonSelector = "_doRecover"; //id

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }
        public Boolean CheckLoginLabel(string label)
        {
            return String.Equals(label.ToUpper(), driver.FindElement(By.XPath(loginLabelSelector)).Text.ToUpper());
        }

        public Boolean CheckIfLogged(string greetings)
        {
            return String.Equals(greetings.ToUpper(), driver.FindElement(By.XPath(accountButtonSelector)).Text.ToUpper());
        }

        public string CheckAccBtnMsg()
        {
            var accBtnText = Utils.Utils.WaitForFluentElement(driver, 1, By.XPath(accountButtonSelector)).Text.ToUpper();
           return accBtnText;
           // return driver.FindElement(By.XPath(accountButtonSelector)).Text.ToUpper();
        }


        public void Login(string email, string password)
        {
            var emailInput = driver.FindElement(By.Id(emailSelector));
            emailInput.Clear();
            emailInput.SendKeys(email);
            var passwordInput = driver.FindElement(By.Id(passwordSelector));
            passwordInput.Clear();
            passwordInput.SendKeys(password);
            var loginButton = driver.FindElement(By.Id(loginButtonSelector));
            loginButton.Click();
        }

        public string ErrorChecker()
        {
            return driver.FindElement(By.ClassName(errorMessageSelector)).Text;
        }

        public void Logout()
        {
            driver.FindElement(By.XPath(logoutButtonSelector)).Click();
        }

        public void ForgotPassword()
        {
            driver.FindElement(By.ClassName(forgotPassSelector)).Click();
        }

        public string ShowLoginErrorMessage()
        {
            return driver.FindElement(By.ClassName(loginErrorMessageSelector)).Text;
        }

        public void RecoverPasword(string email) /////////////////////////////////// de verificat
        {
            var emailInput = driver.FindElement(By.CssSelector(emailInputSelector));
            emailInput.Click();
            emailInput.Clear();
            emailInput.SendKeys(email);
            var submitButton = driver.FindElement(By.Id(submitButtonSelector));
            submitButton.Click();
        }


        public void LoginErrMsg(string email, string password, string errorMessage)
        {
            var emailInput = driver.FindElement(By.Id(emailSelector));
            emailInput.Clear();
            emailInput.SendKeys(email);
            var passwordInput = driver.FindElement(By.Id(passwordSelector));
            passwordInput.Clear();
            passwordInput.SendKeys(password);
            var loginButton = driver.FindElement(By.Id(loginButtonSelector));
            loginButton.Click();

            if (email == "" || password == "")
            {
                Console.WriteLine(ShowLoginErrorMessage());
            }
        }

    }
}
