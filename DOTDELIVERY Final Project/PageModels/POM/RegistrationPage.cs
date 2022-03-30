using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTDELIVERY_Final_Project.PageModels.POM
{
    class RegistrationPage : BasePage
    {

        const string registrationLabelSelector = "//*[@id=\"register-page\"]/div/div[2]/div[1]/h1"; //xpath
        const string registerationButtonSelector = "doRegister"; //id
        const string acceptCookiesSelector = "__gomagCookiePolicy"; // id

        const string emailInputSelector = "__emailRegister"; // id
        const string lastNamedInputSelector = "__lastnameRegister";// id
        const string firstNamedInputSelector = "__firstnameRegister";// id
        const string passwordInputSelector = "__passwordRegister"; //id
        const string repeatPassInputSelector = "__confirmPasswordRegister"; //id
        const string newsletterCheckBoxoxSelector = "//*[@id=\"_submitRegistration\"]/div/div/label/div/input"; //xpath
        const string gdprCheckBoxoxSelector = "//*[@id=\"_submitRegistration\"]/div/div/p/label/div/input"; //xpath


        const string mainErrorSelector = "//*[@id=\"_submitRegistration\"]/div/p"; // xpath
        const string emailErrorSelector = "//*[@id=\"_submitRegistration\"]/div/div/div[1]/span"; // xpath
        const string emailErrorSelectar = "#_submitRegistration > div > div > div:nth-child(1) > span"; // css
        const string lastNameErrorSelector = "//*[@id=\"_submitRegistration\"]/div/div/div[2]/span";// xpath
        const string firstNameErrorSelector = "//*[@id=\"_submitRegistration\"]/div/div/div[3]/span";// xpath
        const string passwordErrorSelector = "//*[@id=\"_submitRegistration\"]/div/div/div[4]/span"; //xpath
        const string repeatPassErrorSelector = "//*[@id=\"_submitRegistration\"]/div/div/div[5]/span"; //xpath
        const string gdprErrorSelector = "errorMsg"; //class

        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }
        //This method checks if the user is on the registration page or not by checking the label of the page.
        public Boolean CheckRegistrationLabel(string label)
        {
            return String.Equals(label.ToUpper(), driver.FindElement(By.XPath(registrationLabelSelector)).Text.ToUpper());
        }

        // This method clicks the "INREGISTREAZA-TE" button to acces the registragion form.
        public void MoveToRegForm()
        {
            driver.FindElement(By.Id(registerationButtonSelector)).Click();
        }
        public void AcceptCookies()
        {
            driver.FindElement(By.Id(acceptCookiesSelector)).Click();
        }

        public void RegisterUser(string email, string lastName, string firstName, string pass, string confirmPass, bool newsletter, bool gdpr)
        {
            var emailInput = driver.FindElement(By.Id(emailInputSelector));
            emailInput.Clear();
            emailInput.SendKeys(email);
            var lastNameInput = driver.FindElement(By.Id(lastNamedInputSelector));
            lastNameInput.Clear();
            lastNameInput.SendKeys(lastName);
            var firstNameInput = driver.FindElement(By.Id(firstNamedInputSelector));
            firstNameInput.Clear();
            firstNameInput.SendKeys(firstName);
            var passwordInput = driver.FindElement(By.Id(passwordInputSelector));
            passwordInput.Clear();
            passwordInput.SendKeys(pass);
            var confirmPasswordInput = driver.FindElement(By.Id(repeatPassInputSelector));
            confirmPasswordInput.Clear();
            confirmPasswordInput.SendKeys(confirmPass);
            if (newsletter)
            {
                var newsletterCheckBox = driver.FindElement(By.XPath(newsletterCheckBoxoxSelector));
                newsletterCheckBox.Click();
            }
            if (gdpr)
            {
                var gdprCheckBox = driver.FindElement(By.XPath(gdprCheckBoxoxSelector));
                gdprCheckBox.Click();
            }
            var submitButton = driver.FindElement(By.Id(registerationButtonSelector));
            submitButton.Click();
        }
        public string CheckMainError()
        {
            return driver.FindElement(By.XPath(mainErrorSelector)).Text;
        }
        public string CheckEmailError()
        {
            return driver.FindElement(By.XPath(emailErrorSelector)).Text;
        }
        public string CheckLastNameError()
        {
            return driver.FindElement(By.XPath(lastNameErrorSelector)).Text;
        }
        public string CheckFirstNameError()
        {
            return driver.FindElement(By.XPath(firstNameErrorSelector)).Text;
        }
        public string CheckPasswordError()
        {
            return driver.FindElement(By.XPath(passwordErrorSelector)).Text;
        }
        public string CheckRepeatPassError()
        {
            return driver.FindElement(By.XPath(repeatPassErrorSelector)).Text;
        }
        public string CheckGdprError()
        {
            return driver.FindElement(By.ClassName(gdprErrorSelector)).Text;
        }
    }
}
