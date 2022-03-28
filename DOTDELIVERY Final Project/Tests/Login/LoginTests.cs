using DOTDELIVERY_Final_Project.PageModels;
using DOTDELIVERY_Final_Project.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTDELIVERY_Final_Project.Tests.Login
{
    
    class LoginTests : BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        // This test checks if by clicking the logo the user will land on the Home Page.
        [Test]
        public void HomePageChecker()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mainp = new MainPage(_driver);
            mainp.CheckLogo();
            Assert.AreEqual("PROMOTII", mainp.ShowPromoTitle());
        }

        [Test, TestCaseSource("GetCredentialsDataCsv")]
        public void LoginPositiveTest(string email, string password)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.AcceptCookies();
            mp.MoveToLoginPage();

            LoginPage lp = new LoginPage(_driver);
            Assert.IsTrue(lp.CheckLoginLabel("CONTUL TAU"));
            lp.Login(email, password);
        }

        //public void LoginErrorMessagesTest() { }

        private static IEnumerable<TestCaseData> GetCredentialsDataCsv()
        {
            var csvData = Utils.Utils.GetDataTableFromCsv("TestData\\loginData.csv");
            for (int i = 0; i < csvData.Rows.Count; i++)
            {
                yield return new TestCaseData(csvData.Rows[i].ItemArray);
            }
        }
    }
}
