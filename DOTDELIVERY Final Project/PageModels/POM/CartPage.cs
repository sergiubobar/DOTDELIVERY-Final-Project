using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTDELIVERY_Final_Project.PageModels.POM
{
    class CartPage : BasePage
    {
        const string cartIconSelector = "fa-shopping-bag"; //class
        const string cartEmptySelector = "//*[@id=\"cartEmpty\"]/p/a"; //class
        const string addedProductPopSelector = "addedProduct"; //id
        const string padurataImageSelector = "_productMainImage_78";
        const string padurataLabelSelector = "_productUrl_78"; //class  _productMainImage_78 
        const string addPadurataToCartSelector = "_addToCartListProduct_78"; //class
        const string addPadurataToCartSelectorr= "add2cart"; //class
        const string addPadurataToCartSelectorrr= "/html/body/div[2]/div[2]/div[3]/div[1]/div[1]/div[3]/div[4]/a"; //xpath
        const string closePopUpSelector = "//*[@id=\" - g - addtocart - popup - default\"]/div[3]/a[1]"; //css
        const string pageLabelSelector = "catTitle"; //class
        const string checkCartLabelSelector = "//*[@id=\"shoppingcart\"]/div[1]/h2"; //xpath

        // iframe = _hjRemoteVarsFrame  name  _hjRemoteVarsFrame
        public CartPage(IWebDriver driver) : base(driver) { }

        public void CheckCartPage()
        {
            driver.FindElement(By.ClassName(cartIconSelector)).Click();
        }
        public string GetSiteURL()
        {
            return Utils.Utils.ExecuteJsScript(driver, "return document.URL");
        }

        public void AddPadurataToCart()
        {
            driver.FindElement(By.ClassName(addPadurataToCartSelector)).Click();
        }

        public string ReadPadurataLabel()
        {
            return driver.FindElement(By.ClassName(padurataLabelSelector)).Text;
        }

        public string CheckCartPopUp()
        {
            driver.SwitchTo().Frame(0);
            var popUpMsg = Utils.Utils.WaitForFluentElement(driver, 2, By.XPath(addedProductPopSelector)).Text;
            driver.SwitchTo().DefaultContent();
            return popUpMsg;
          //  return driver.FindElement(By.ClassName(addedProductPopSelector)).Text;
        }

        public void CheckCartPageWait()
        {
            Utils.Utils.WaitForFluentElement(driver, 2, By.ClassName(cartIconSelector)).Click();
            
        }
        public void PadurataSelect()
        {
            driver.FindElement(By.ClassName(padurataImageSelector)).Click();
        }

        public void PadurataToCart()
        {
            var addToCartButtonElement = Utils.Utils.WaitForElementClickable(driver, 2, By.ClassName(addPadurataToCartSelectorr));
            //driver.FindElement(By.XPath(addPadurataToCartSelectorr)).Click();
            addToCartButtonElement.Click();
        }

        public void AddToCartPadurata()
        {
            driver.FindElement(By.XPath(addPadurataToCartSelectorrr)).Click();
        }

        public void checkLabel()
        {
            Utils.Utils.WaitForFluentElement(driver, 3, By.XPath(checkCartLabelSelector)).Click();
        }


    }
}
