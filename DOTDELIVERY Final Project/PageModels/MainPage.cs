using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTDELIVERY_Final_Project.PageModels
{
    class MainPage : BasePage
    {
        const string acceptCookiesSelector = "__gomagCookiePolicy"; // id
        const string accountButtonSelector = "//*[@id=\"wrapper\"]/header/div[2]/div/div/div[3]/ul/li[1]/a/span"; //xpath
        const string pageLogoSelector = "logo"; //id
        const string promotionsSelector = "//*[@id=\"-g-homepage-productsDiscounts\"]/div/div/div[1]/p"; //xpath

        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        // This method gets rid of the cookie pop-up by accepting them (clicks the "SUNT DE ACORD" button).
        public void AcceptCookies()
        {
            driver.FindElement(By.Id(acceptCookiesSelector)).Click();
        }

        // This method clicks on the "Intra in cont" button to Login or Register on the website.
        public void MoveToLoginPage()
        {
            driver.FindElement(By.XPath(accountButtonSelector)).Click();
        }

        // This method clicks on the logo button to check if it brings you to the Home Page.
        public void CheckLogo()
        {
            driver.FindElement(By.Id(pageLogoSelector)).Click();
        }

        // Using this method will check if we are on the Home Page by looking after the first title from the page (Promotii). 
        public string ShowPromoTitle()
        {
            //Console.WriteLine(driver.FindElement(By.XPath(promotionsSelector)).Text.ToUpper());
            return driver.FindElement(By.XPath(promotionsSelector)).Text.ToUpper();
        }
    }

}
