using DOTDELIVERY_Final_Project.PageModels;
using DOTDELIVERY_Final_Project.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTDELIVERY_Final_Project.Tests.Register
{
    class RegistrationTests : BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        [Test]
        public void RegistrationTest() {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.AcceptCookies();
            mp.MoveToLoginPage();

            RegistrationPage regPage = new RegistrationPage(_driver);
            regPage.MoveToRegForm();
            Assert.IsTrue(regPage.CheckRegistrationLabel("CLIENT NOU: INREGISTRARE"));
            regPage.RegisterSuccessfully(Utils.Utils.GenerateRandomStringAlphaCount(5) + "@test.test", 
                Utils.Utils.GenerateRandomStringAlphaCount(5),
                Utils.Utils.GenerateRandomStringAlphaCount(5), 
                "test", "test", true, true);

        } 
    }
}
