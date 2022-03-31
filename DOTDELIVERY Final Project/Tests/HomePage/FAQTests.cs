using DOTDELIVERY_Final_Project.PageModels.POM;
using DOTDELIVERY_Final_Project.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTDELIVERY_Final_Project.Tests.HomePage
{
    class FAQTests : BaseTest
    {
        string url = FrameworkConstants.GetUrl();


        [Test]
        public void FAQLabelCheck()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url + faqRegUrlPath);
            FAQPage fp = new FAQPage(_driver);
            fp.CheckAjutor();
            Assert.IsTrue(fp.TitleChecker("Ajutor"));
            fp.CheckCumCumpar();
            Assert.IsTrue(fp.TitleChecker("Cum Cumpar"));
            fp.CheckInfoLivrare();
            Assert.IsTrue(fp.TitleChecker("Informatii Livrare"));
            fp.CheckTermeniConditii();
            Assert.IsTrue(fp.TitleChecker("Termeni si Conditii"));
            fp.CheckDespreNoi();
            Assert.IsTrue(fp.TitleChecker("Despre noi"));
            fp.CheckFAQ();
            Assert.IsTrue(fp.TitleChecker("FAQ"));
            fp.CheckMetodePlata();
            Assert.IsTrue(fp.TitleChecker("Metode de Plata"));
            fp.CheckGarantiaProduselor();
            Assert.IsTrue(fp.TitleChecker("Garantia Produselor"));
            fp.CheckConfidentialitate();
            Assert.IsTrue(fp.TitleChecker("Confidentialitate"));
        }
    }
}
