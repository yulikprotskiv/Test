using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Test.Framework;
using Test.PageObjects;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;

namespace Test.Tests
{
    [TestFixture]
    class MyTest : TestBase
    {
        public override void SetUp()
        {
            Navigator.NavigateToEmailPage(driver);
        }

        [TestCase("ua.fm")]
        [TestCase("email.ua")]
        [TestCase("3g.ua")]
        [TestCase("football.ua")]
        public void VerifyLogin(string domain)
        {
            HomePage hPage = new HomePage(driver);
            hPage.SelectDomain(domain);
            hPage.LoginB();
            EmailPage ePage = new EmailPage(driver);
            Assert.IsFalse(ePage.SettingsButton.Displayed);
        }

        public override void TearDown()
        {
            EmailPage ePage = new EmailPage(driver);
            ePage.Logout();
        }
    }
}
