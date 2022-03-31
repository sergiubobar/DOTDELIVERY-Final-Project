using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTDELIVERY_Final_Project.PageModels.POM
{
    class FAQPage : BasePage
    {
        const string faqLabelSelector = "#main-menu > div > ul > li.menu-drop.__GomagSM > a"; //css

        const string ajutorSelector = "//*[@id=\"wrapper\"]/div[4]/div/div[2]/div/ul/li[1]/a"; //xpath
        const string cumCUmparSelector = "//*[@id=\"wrapper\"]/div[4]/div/div[2]/div/ul/li[2]/a"; //xpath
        const string infoLivrareSelector = "//*[@id=\"wrapper\"]/div[4]/div/div[2]/div/ul/li[3]/a"; //xpath
        const string termeniConditiiSelector = "//*[@id=\"wrapper\"]/div[4]/div/div[2]/div/ul/li[4]/a"; //xpath
        const string despreNoiSelector = "//*[@id=\"wrapper\"]/div[4]/div/div[2]/div/ul/li[5]/a"; //xpath
        const string faqSelector = "//*[@id=\"wrapper\"]/div[4]/div/div[2]/div/ul/li[6]/a"; //xpath
        const string metodePlataSelector = "//*[@id=\"wrapper\"]/div[4]/div/div[2]/div/ul/li[7]/a"; //xpath
        const string garantiaSelector = "//*[@id=\"wrapper\"]/div[4]/div/div[2]/div/ul/li[8]/a"; //xpath
        const string confidentialitateSelector = "//*[@id=\"wrapper\"]/div[4]/div/div[2]/div/ul/li[9]/a"; //xpath

        const string titleSelector = "title"; //class

        public FAQPage(IWebDriver driver) : base(driver) { }

        public void CheckAjutor()
        {
            driver.FindElement(By.XPath(ajutorSelector)).Click();
        }
        public void CheckCumCumpar()
        {
            driver.FindElement(By.XPath(cumCUmparSelector)).Click();
        }
        public void CheckInfoLivrare()
        {
            driver.FindElement(By.XPath(infoLivrareSelector)).Click();
        }
        public void CheckTermeniConditii()
        {
            driver.FindElement(By.XPath(termeniConditiiSelector)).Click();
        }
        public void CheckDespreNoi()
        {
            driver.FindElement(By.XPath(despreNoiSelector)).Click();
        }
        public void CheckMetodePlata()
        {
            driver.FindElement(By.XPath(metodePlataSelector)).Click();
        }
        public void CheckFAQ()
        {
            driver.FindElement(By.XPath(faqSelector)).Click();
        }
        public void CheckGarantiaProduselor()
        {
            driver.FindElement(By.XPath(garantiaSelector)).Click();
        }
        public void CheckConfidentialitate()
        {
            driver.FindElement(By.XPath(confidentialitateSelector)).Click();
        }
        public Boolean TitleChecker(string title)
        {
            return String.Equals(title, driver.FindElement(By.ClassName(titleSelector)).Text);
        }

    }
}
