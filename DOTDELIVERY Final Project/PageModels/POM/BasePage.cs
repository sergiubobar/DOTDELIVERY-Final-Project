using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTDELIVERY_Final_Project.PageModels.POM
{
    public class BasePage
    {

        public IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
