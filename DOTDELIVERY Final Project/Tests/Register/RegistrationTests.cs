using DOTDELIVERY_Final_Project.PageModels.POM;
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
            regPage.RegisterUser(Utils.Utils.GenerateRandomStringAlphaCount(3) + "@test.test", Utils.Utils.GenerateRandomStringAlphaCount(3),
                Utils.Utils.GenerateRandomStringAlphaCount(3), "test", "test", true, true);
        }

        [Category("Registration")]
        [TestCase("s@s.ss", "sss", "sss", "sss", "sss", "true", "false", "", "", "", "", "", "Va rugam sa completati toate campurile obligatorii.")]
        [Test]
        public void RegistrationErrorTests(string email, string lastName, string firstName, string pass, string confirmPass, bool newsletter, bool gdpr,
            string emailErr, string lastNameErr, string firstNameErr, string passErr, string confirmPassErr, string gdprErr)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url + loginRegUrlPath);
            RegistrationPage regPage = new RegistrationPage(_driver);
            regPage.AcceptCookies();
            regPage.MoveToRegForm();
            regPage.RegisterUser(email, lastName, firstName, pass, confirmPass, newsletter, newsletter);

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
    }
}
