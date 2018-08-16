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

        public override void BaseOneTimeSetUp()
        {
            emailPage = Navigator.NavigateToEmailPage(driver);
            HomePage hPage = new HomePage(driver);
            hPage.LoginB();
        }

        [Test]
        public void UploadFile()
        {
            string File = "UploadTEST.txt";
            string FilePath = @"C:\Users\Lenovo Y500\Desktop\" + File;

            EmailPage emailPage = new EmailPage(driver);
            emailPage.CreateLetterBtn().Click();
            emailPage.ReceiverField().SendKeys("test261998@i.ua");
            emailPage.SubjectField().SendKeys("Letter for test");
            emailPage.DescriptionField().SendKeys("Description Test");
            driver.FindElement(By.XPath("//*[@id='att']/div[2]/span[1]/i")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@type='file']")).SendKeys(FilePath);
            Thread.Sleep(2000);
            emailPage.SentMailButton().Click();
            emailPage.IncomingMailsTab().Click();
            emailPage.FirstMail().Click();
        }
        [Test]
        public void DownloadFile()
        {
            string FilePath = @"C:\Users\Lenovo Y500\Desktop\TestFiles\";

            EmailPage emailPage = new EmailPage(driver);
            emailPage.IncomingMailsTab().Click();
            emailPage.FirstMail().Click();

            driver.FindElement(By.LinkText("UploadTEST.txt")).Click();
            Thread.Sleep(2000);
        }
    }
}
