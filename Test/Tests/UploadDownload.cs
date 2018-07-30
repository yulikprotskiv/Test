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
    public class UploadDownload:TestBase
    {
        EmailPage emailPage;
        //string File = "UploadTEST.txt";
        //string FilePath = @"C:\Users\Lenovo Y500\Desktop\" + File;
        public override void BaseOneTimeSetUp()
        {
            emailPage = Navigator.NavigateToEmailPage(driver);
        }

        [Test]
        public void UploadFile()
        {
            string File = "UploadTEST.txt";
            string FilePath = @"C:\Users\Lenovo Y500\Desktop\" + File;
            EmailPage emailPage = new EmailPage(driver);
            emailPage.CreateNewLetter();
            driver.FindElement(By.XPath("//*[@id='att']/div[2]/span[1]/i")).Click();
            driver.FindElement(By.XPath("//input[@type='file']")).SendKeys(FilePath);
            Thread.Sleep(10000);
            emailPage.IncomingMailsTab().Click();
            Assert.AreEqual("Letter for test", emailPage.SubjectOfIncomingMail().Text);
        }
        public void DownloadFile()
        {

        }
    }
}
