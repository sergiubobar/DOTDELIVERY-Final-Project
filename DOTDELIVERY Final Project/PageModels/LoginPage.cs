using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTDELIVERY_Final_Project.PageModels
{
    class LoginPage : BasePage
    {

        const string emailSelector = "_loginEmail"; // id
        const string errorMessageSelector = "error"; // class
        const string passwordSelector = "_loginPassword"; //id
        const string loginButtonSelector = "doLogin"; //id
        const string loginLabelSelector = "//*[@id=\"register-page\"]/div/div[1]/div/div[1]/h1"; //xpath

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }
        public Boolean CheckLoginLabel(string label)
        {
            return String.Equals(label.ToUpper(), driver.FindElement(By.XPath(loginLabelSelector)).Text.ToUpper());
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
    }
}
