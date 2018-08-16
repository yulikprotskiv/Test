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
using OpenQA.Selenium.Support.PageObjects;

namespace Test.PageObjects
{
    class HomePage
    {
        public IWebDriver driver;
        public HomePage(IWebDriver driver)
            {
                this.driver = driver;
            }
        //Login form
        public IWebElement LoginInput => driver.FindElement(By.Name("login"));
        public IWebElement LoginPasswordInput => driver.FindElement(By.Name("pass"));
        public IWebElement LoginCheckbox => driver.FindElement(By.Name("auth_type"));
        public IWebElement MailDomainDropdown => driver.FindElement(By.Name("domn"));

        public IWebElement MailDomainDropdown2(string domain) => driver.FindElement(By.XPath($"//select[@name='domn']/option[@value = '{domain}']"));
        public IWebElement Form => driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div[3]/div[2]/div[1]/div[3]"));
        public IWebElement LoginButton => driver.FindElement(By.XPath("//input[@value='Увійти']"));

       
        public void Login(string Username, string Password)
        {
            LoginInput.SendKeys(Username + Keys.Tab);
            LoginPasswordInput.SendKeys(Password + Keys.Tab);
            SelectElement SelectName = new SelectElement(MailDomainDropdown);
            SelectName.SelectByText("email.ua");
                      
            LoginCheckbox.Click();
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual("test261998@i.ua", LoginInput.GetAttribute("value"));
                Assert.AreEqual("Password1", LoginPasswordInput.GetAttribute("value"));
                Assert.AreEqual("email.ua", MailDomainDropdown.GetAttribute("value"));
                Assert.IsTrue(LoginCheckbox.Selected);
            });

        }
        public void SelectDomain(string domain)
        {
            var element = MailDomainDropdown2(domain);
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            wait.Until(p => element.Displayed);
            element.Click();
        }
        public void LoginB()
        {
            LoginButton.Click();
        }

    }  
}
