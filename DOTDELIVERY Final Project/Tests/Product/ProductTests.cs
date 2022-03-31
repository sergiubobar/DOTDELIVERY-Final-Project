using DOTDELIVERY_Final_Project.PageModels.POM;
using DOTDELIVERY_Final_Project.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTDELIVERY_Final_Project.Tests.Product
{
    class ProductTests : BaseTest
    {
        string url = FrameworkConstants.GetUrl();


        [Test]
        public void LabelCheck()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            ProductPage pp = new ProductPage(_driver);
            pp.CheckBorcanUrbanLabel();
            Assert.IsTrue(pp.TitleChecker("Borcan Urban"));
            pp.CheckDulceLaBorcanLabel();
            Assert.IsTrue(pp.TitleChecker("Dulce la borcan"));
            pp.CheckLichideFaraAlcoolLabel();
            Assert.IsTrue(pp.TitleChecker("Lichide fără alcool"));
            pp.CheckCocktailsLabel();
            Assert.IsTrue(pp.TitleChecker("Cocktails"));
            pp.CheckTariiLabel();
            Assert.IsTrue(pp.TitleChecker("Tării"));
            pp.CheckInToataTaraLabel();
            Assert.IsTrue(pp.TitleChecker("În Toată Țara"));
            pp.CheckFAQ();
            Assert.IsTrue(pp.TitleChecker2("FAQ"));
        }

        [Test]
        public void ProductDescriptionTest()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            ProductPage pp = new ProductPage(_driver);
            pp.CheckBorcanUrbanLabel();
            pp.SelectProduct();
            Assert.IsTrue(pp.TitleChecker2("Pate de linte"));
        }
    }
}
