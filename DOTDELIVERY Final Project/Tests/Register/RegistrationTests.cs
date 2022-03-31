using DOTDELIVERY_Final_Project.PageModels.POM;
using DOTDELIVERY_Final_Project.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DOTDELIVERY_Final_Project.Tests.Register
{
    class RegistrationTests : BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        [Category("Registration")]
        [Test]
        public void RandomisedRegistration() {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url + loginRegUrlPath);
            RegistrationPage regPage = new RegistrationPage(_driver);
            regPage.AcceptCookies();
            regPage.MoveToRegForm();
            Assert.IsTrue(regPage.CheckRegistrationLabel("CLIENT NOU: INREGISTRARE"));
            regPage.RegisterUser(Utils.Utils.GenerateRandomStringAlphaCount(5) + "@test.test", Utils.Utils.GenerateRandomStringAlphaCount(3),
                Utils.Utils.GenerateRandomStringAlphaCount(3), "test", "test", true, true);
        }

        [Category("Registration")]
       // [TestCase("s@ss.ss", "sss", "sss", "sss", "sss", "true", "false", "", "", "", "", "", "Va rugam sa completati toate campurile obligatorii.")]
        [Test, TestCaseSource("GetCredentialsDataCsv5")]
        public void RegistrationErrorTests(string email, string lastName, string firstName, string pass, string confirmPass, bool newsletter, bool gdpr,
            string emailErr, string lastNameErr, string firstNameErr, string passErr, string confirmPassErr, string gdprErr)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url + loginRegUrlPath);
            RegistrationPage regPage = new RegistrationPage(_driver);
            regPage.AcceptCookies();
            regPage.MoveToRegForm();
            regPage.RegisterUser(email, lastName, firstName, pass, confirmPass, newsletter, gdpr);

            if (emailErr != "")
            {
                Assert.AreEqual("Adresa de email este obligatorie.", regPage.CheckEmailError());
            }
            if (lastNameErr != "")
            {
                Assert.AreEqual("Numele este obligatoriu.", regPage.CheckLastNameError());
            }
            if (firstNameErr != "")
            {
                Assert.AreEqual("Prenumele este obligatoriu.", regPage.CheckFirstNameError());
            }
            if (passErr != "")
            {
                Assert.AreEqual("Parola este obligatorie.", regPage.CheckPasswordError());
            }
            if (confirmPassErr != "")
            {
                Assert.AreEqual("Parolele nu corespund.", regPage.CheckRepeatPassError());
            }
            if (gdprErr != "")
            {
                Assert.AreEqual("Va rugam sa completati toate campurile obligatorii.", regPage.CheckMainError());
            }
        }
        
        private static IEnumerable<TestCaseData> GetRegTestDataCsv()
        {
            foreach (var values in Utils.Utils.GetGenericData("TestData\\registrationTestData.csv"))
            {
                yield return new TestCaseData(values);
            }
        }
        private static IEnumerable<TestCaseData> GetCredentialsDataCsv5()
        {
            string path = "TestData\\registrationTestData.csv";
            var index = 0;
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (index > 0)
                    {
                        yield return new TestCaseData(values[0].Trim(), values[1].Trim(), values[2].Trim(), values[3].Trim(), values[4].Trim(), bool.Parse(values[5].Trim()), bool.Parse(values[6].Trim()), values[7].Trim(), values[8].Trim(), values[9].Trim(), values[10].Trim(), values[11].Trim(), values[12].Trim());
                    }
                    index++;
                }
            }
        }
    }
}
