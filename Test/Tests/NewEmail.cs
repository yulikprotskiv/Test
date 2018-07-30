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
    public class NewEmail : TestBase
    {
        EmailPage emailPage;
        public override void BaseOneTimeSetUp()
        {
            emailPage = Navigator.NavigateToEmailPage(driver);
        }
        [Test]
        public void Create_New_Mail()
        {
            EmailPage emailPage = new EmailPage(driver);
            emailPage.CreateNewLetter();
            emailPage.IncomingMailsTab().Click();
            Assert.AreEqual("Letter for test", emailPage.SubjectOfIncomingMail().Text);
        }
        [Test]
        public void Verify_Subject_Field()
        {
            EmailPage emailPage = new EmailPage(driver);
            emailPage.IncomingMailsTab().Click();
            emailPage.FirstMail().Click();
            Assert.AreEqual("Letter for test", emailPage.Subject().Text);
        }
        [Test]
        public void Verify_Description_Field()
        {
            EmailPage emailPage = new EmailPage(driver);
            emailPage.IncomingMailsTab().Click();
            emailPage.FirstMail().Click();
            Assert.IsTrue(emailPage.Description().Text.Contains("Description Test"));
        }
        [Test]
        public void Verify_Receiver_Field()
        {
            EmailPage emailPage = new EmailPage(driver);
            emailPage.IncomingMailsTab().Click();
            emailPage.FirstMail().Click();
            Assert.AreEqual("protskiv26@i.ua", emailPage.Receiver().Text);
        }
    }
}
