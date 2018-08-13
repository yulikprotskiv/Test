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

namespace SecondLesson
{
    [TestFixture]
    public class EmailTests:TestBase
    {
        EmailPage emailPage;
        public override void BaseOneTimeSetUp()
        {
            emailPage = Navigator.NavigateToEmailPage(driver);
            HomePage hPage = new HomePage(driver);
            hPage.LoginB();
        }
        [Test]
        public void Ckeck_Title_After_Login()
        {
            Assert.AreEqual("Вхідні - I.UA ", driver.Title);
        }

        [Test]
        public void Check_Mail_After_Login()
        {
            EmailPage emailPage = new EmailPage(driver);
            emailPage.MailName().Equals("test261998@i.ua");
        }

        [Test]
        public void Check_Received_Mails()
        {
            EmailPage emailPage = new EmailPage(driver);
            Assert.AreEqual("Невелика довідка про можливості пошти", emailPage.FirstLetter().Text);
            Assert.AreEqual("Рекомендації по безпеці Вашого акаунту", emailPage.SecondLetter().Text);
            Assert.AreEqual("Обережно шахраї!", emailPage.ThirdLetter().Text);
            Assert.AreEqual("Ласкаво просимо на I.UA!", emailPage.FourthLetter().Text);
        }

        [Test]
        public void Check_Mail_PopUp()
        {
            IWebElement FourthLetter = driver.FindElement(By.XPath("//span[text()='Ласкаво просимо на I.UA!']"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(FourthLetter).Build().Perform();
            IWebElement Popup = driver.FindElement(By.Id("prflpudvmbox_userInfoPopUp"));
            IWebElement PopupText = Popup.FindElement(By.XPath("//li[2]"));

            IWebElement MailCheckBox = driver.FindElement(By.XPath("//input[@value='5b026e6ede88']"));
            MailCheckBox.Click();
            Assert.IsTrue(MailCheckBox.Selected);

            IWebElement DeleteButton = driver.FindElement(By.XPath("//div[@id='fieldset1']/fieldset[3]"));
            DeleteButton.Click();

            IAlert RemoveMailAlert = driver.SwitchTo().Alert();
            RemoveMailAlert.Dismiss();
        }

        [Test]
        public void Remove_Mail()
        {
            IWebElement CheckMail = driver.FindElement(By.XPath("//input[@value='5b026e6fde8c']"));
            CheckMail.Click();
            Assert.IsTrue(CheckMail.Selected);

            IWebElement DeleteButton = driver.FindElement(By.XPath("//div[@id='fieldset1']/fieldset[3]"));
            DeleteButton.Click();
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();

            try
            {
                if (driver.FindElement(By.XPath("//input[@value='5b026e6fde8c']")).Displayed)
                {
                    Console.WriteLine("Element still displayed on page");
                }
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("No Such Element on page");
            }
        }

        [Test]
        public void Work_With_Windows()
        {
            EmailPage emailPage = new EmailPage(driver);
            // Click on 'Головна' by using Shift+'Click' combination to opened link in new window
            Actions OpenNewWindow = new Actions(driver);
            OpenNewWindow.KeyDown(Keys.Shift).Click(emailPage.MainPage()).KeyUp(Keys.Shift).Build().Perform();

            // Checking that amount of opened windows are equal to 2
            Assert.AreEqual(2, driver.WindowHandles.Count);

            //Get all opened windows and switching to second
            var Windows = driver.WindowHandles;
            driver.SwitchTo().Window(Windows.Last());

            emailPage.LogoutButton().Click();
            Assert.IsTrue(emailPage.LoginForm().Displayed);

            driver.SwitchTo().Window(Windows.First());
            driver.Navigate().Refresh();

            Assert.IsTrue(emailPage.Login_on_FirstWindow().Displayed);
        }
        [Test]

        public void Verify_Fields_Of_Sent_Letter()
        {
            EmailPage emailPage = new EmailPage(driver);
            emailPage.CreateNewLetter();
            emailPage.IncomingMailsTab().Click();
            emailPage.FirstMail().Click();
            
            Assert.AreEqual("Letter for test", emailPage.Subject().Text);
            Assert.IsTrue(emailPage.Description().Text.Contains("Description Test"));
            Assert.AreEqual("test261998@i.ua", emailPage.Receiver().Text);
        }
    }
}

