using DOTDELIVERY_Final_Project.PageModels.POM;
using DOTDELIVERY_Final_Project.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTDELIVERY_Final_Project.Tests.Cart
{
    class CartTests : BaseTest
    {
        string url = FrameworkConstants.GetUrl();
        [Category("Cart")]
        [Test]
        public void CartButtonTest()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            CartPage cp = new CartPage(_driver);
            cp.CheckCartPage();
            Assert.AreEqual("https://www.dotdelivery.ro/cos-de-cumparaturi", cp.GetSiteURL());
        }

        [Category("Cart")]
        [Test]
        public void AddTarieToChart()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url + "/tării");
            CartPage cp = new CartPage(_driver);
            cp.PadurataSelect();
            cp.PadurataToCart();
    //      var paturaLabel = cp.ReadPadurataLabel();
            //Assert.AreEqual(cp.ReadPadurataLabel(), cp.CheckCartPopUp());
            cp.CheckCartPage();

        }
    }
}
