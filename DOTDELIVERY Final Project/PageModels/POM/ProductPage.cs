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
        const string linteLabelSelector = "//*[@id=\"product-page\"]/div[1]/div[1]/div[1]/h1/span";
        const string faqTitleSelector = "title"; //class

        const string pateLinteSelector = "_productMainImage_10"; //class
        const string searchBarSelector = "_autocompleteSearchMainHeader"; //id
        const string linteLabelCheckSelector = "_productUrl_10"; //class
        const string cheesecakeLabelCheckSelector = "_productUrl_142"; //class
        const string invalidProductLabelSelector = "//*[@id=\"result-page\"]/h1"; //xpath

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

        public Boolean LinteLabelChecker(string title)
        {
            return String.Equals(title, driver.FindElement(By.XPath(linteLabelSelector)).Text);
        }

        public Boolean TitleChecker2(string title)
        {
            return String.Equals(title, driver.FindElement(By.ClassName(faqTitleSelector)).Text);
        }

        public void SelectLinteProduct()
        {
            driver.FindElement(By.ClassName(pateLinteSelector)).Click();
        }

        public void SearchProduct(string product)
        {
            var searchProd = driver.FindElement(By.Id(searchBarSelector));
            searchProd.Clear();
            searchProd.SendKeys(product);
            searchProd.SendKeys(Keys.Return);
        }

        public string LinteLabelChecker()
        {
            return driver.FindElement(By.ClassName(linteLabelCheckSelector)).Text;
        }

        public string CheesecakeLabelChecker()
        {
            return driver.FindElement(By.ClassName(cheesecakeLabelCheckSelector)).Text;
        }

        public Boolean InvalidProductChecker(string labelText)
        {
            return String.Equals(labelText, driver.FindElement(By.XPath(invalidProductLabelSelector)).Text);
        }
    }
}
