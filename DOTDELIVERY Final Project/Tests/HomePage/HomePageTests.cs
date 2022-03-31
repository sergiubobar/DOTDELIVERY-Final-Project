using DOTDELIVERY_Final_Project.PageModels.POM;
using DOTDELIVERY_Final_Project.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTDELIVERY_Final_Project.Tests.HomePage
{
    class HomePageTests : BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        [Category("HomePage")]
        [Test, Order(1)]
        public void HomePageChecker()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mainp = new MainPage(_driver);
            Assert.AreEqual("PROMOTII", mainp.ShowPromoTitle());
        }

        [Category("HomePage")]
        [Test(Description ="Checks if the user will land on the Home Page by clicking on the Logo"), Order(2)]
        public void LogoFunctionalityChecker()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mainp = new MainPage(_driver);
            mainp.CheckLogo();
            Assert.AreEqual("PROMOTII", mainp.ShowPromoTitle());
        }

        [Category("HomePage")]
        [Test, Order(3)]
        public void CookieChecker()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            var cookies = _driver.Manage().Cookies;
            Console.WriteLine("The site contains {0} cookies", cookies.AllCookies.Count);
            foreach (Cookie ck in cookies.AllCookies)
            {
                Console.WriteLine("Cookie name {0} and value {1}", ck.Name, ck.Value);
            }
        }

        [Test]
        public void CheckSiteInfo()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mainp = new MainPage(_driver);
            Assert.AreEqual("DOT Cluj | Preparate la borcan, livrare la domiciliu.", mainp.GetSiteTitle());
            Assert.AreEqual("https://www.dotdelivery.ro/", mainp.GetSiteURL());
        }
    }
}
