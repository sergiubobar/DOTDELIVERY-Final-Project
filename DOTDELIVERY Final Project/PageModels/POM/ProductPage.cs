using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTDELIVERY_Final_Project.PageModels.POM
{
    class ProductPage : BasePage
    {
        const string borcanUrbanLabelSelector = "#main-menu > div > ul > li:nth-child(1) > a > span"; //css
        const string dulceLaBorcanLabelSelector = "#main-menu > div > ul > li:nth-child(2) > a > span"; //css
        const string lichideFaraAlcoolLabelSelector = "#main-menu > div > ul > li:nth-child(3) > a > span"; //css
        const string cocktailsLabelSelector = "#main-menu > div > ul > li:nth-child(4) > a > span"; //css
        const string tariiLabelSelector = "#main-menu > div > ul > li:nth-child(5) > a > span"; //css
        const string inToataTaraLabelSelector = "#main-menu > div > ul > li:nth-child(6) > a > span"; //css
        const string faqLabelSelector = "#main-menu > div > ul > li.menu-drop.__GomagSM > a"; //css
        const string titleSelector = "catTitle"; //class
        const string faqTitleSelector = "title"; //class

        const string pateLinteSelector = "_productMainImage_10"; //class

        public ProductPage(IWebDriver driver) : base(driver) { }

        public void CheckBorcanUrbanLabel()
        {
            driver.FindElement(By.CssSelector(borcanUrbanLabelSelector)).Click();
        }
        public void CheckDulceLaBorcanLabel()
        {
            driver.FindElement(By.CssSelector(dulceLaBorcanLabelSelector)).Click();
        }
        public void CheckLichideFaraAlcoolLabel()
        {
            driver.FindElement(By.CssSelector(lichideFaraAlcoolLabelSelector)).Click();
        }
        public void CheckCocktailsLabel()
        {
            driver.FindElement(By.CssSelector(cocktailsLabelSelector)).Click();
        }
        public void CheckTariiLabel()
        {
            driver.FindElement(By.CssSelector(tariiLabelSelector)).Click();
        }
        public void CheckInToataTaraLabel()
        {
            driver.FindElement(By.CssSelector(inToataTaraLabelSelector)).Click();
        }
        public void CheckFAQ()
        {
            driver.FindElement(By.CssSelector(faqLabelSelector)).Click();
        }

        public Boolean TitleChecker(string title)
        {
            return String.Equals(title, driver.FindElement(By.ClassName(titleSelector)).Text);
        }
        public Boolean TitleChecker2(string title)
        {
            return String.Equals(title, driver.FindElement(By.ClassName(faqTitleSelector)).Text);
        }

        public void SelectProduct()
        {
            driver.FindElement(By.ClassName(pateLinteSelector)).Click();
        }



    }
}
