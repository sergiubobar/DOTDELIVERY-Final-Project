using DOTDELIVERY_Final_Project.PageModels.POM;
using DOTDELIVERY_Final_Project.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DOTDELIVERY_Final_Project.Tests.Login
{
    
    class LoginTests : BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        // This test checks if by clicking the logo the user will land on the Home Page.
  

        [Category("Successfull Login")]
        [Test, Order(2), TestCaseSource("GetCredentialsDataCsv")]
        public void LoginPositiveTest(string email, string password)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.AcceptCookies();
            Assert.AreEqual("PROMOTII", mp.ShowPromoTitle());
            mp.MoveToLoginPage();

            LoginPage lp = new LoginPage(_driver);
            Assert.IsTrue(lp.CheckLoginLabel("CONTUL TAU"));
            lp.Login(email, password);
            Assert.IsTrue(lp.CheckIfLogged("BUNA, SERGIU"));
        }

        [Category("Logout")]
        [Test, Order(3), TestCaseSource("GetCredentialsDataCsv")]
        public void Logout(string email, string password)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.AcceptCookies();
            mp.MoveToLoginPage();

            LoginPage lp = new LoginPage(_driver);
            lp.Login(email, password);
            lp.Logout();
            Assert.AreEqual(lp.CheckAccBtnMsg(), "INTRA IN CONT");
        }
        
        [Category("Password Recovery")]
        [Test, Order(3)]
        public void RecoverPassword()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.AcceptCookies();
            mp.MoveToLoginPage();

            LoginPage lp = new LoginPage(_driver);
            lp.ForgotPassword();
            lp.RecoverPasword("sergiu@sergiu.ro");
        }

        [Test, TestCaseSource("GetCredentialsDataCsv2")]
        public void LoginErrorTest (string email, string password, string errorMsg)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.AcceptCookies();
            mp.MoveToLoginPage();
            LoginPage lp = new LoginPage(_driver);
            lp.LoginErrMsg(email, password, errorMsg);
            Assert.AreEqual(errorMsg, lp.ShowLoginErrorMessage());
        }


        private static IEnumerable<TestCaseData> GetCredentialsDataCsv()
        {
            var csvData = Utils.Utils.GetDataTableFromCsv("TestData\\validLoginData.csv");
            for (int i = 0; i < csvData.Rows.Count; i++)
            {
                yield return new TestCaseData(csvData.Rows[i].ItemArray);
            }
        }

        private static IEnumerable<TestCaseData> GetCredentialsDataCsv2()
        {
            string path = "TestData\\wrongLoginData.csv";
            var index = 0;
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (index > 0)
                    {
                        yield return new TestCaseData(values[0].Trim(), values[1].Trim(), values[2].Trim());
                    }
                    index++;
                }
            }
        }
    }
}
