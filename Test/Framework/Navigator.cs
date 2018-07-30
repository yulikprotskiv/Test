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

namespace Test.Framework
{
    class Navigator
    {
        public static EmailPage NavigateToEmailPage(IWebDriver driver)
        {
          driver.Navigate().GoToUrl("http://www.i.ua/");
          HomePage homePage = new HomePage(driver);
          homePage.Login(TestConfigurations.Username, TestConfigurations.Password);
          return new EmailPage(driver);
        }
        //public static EmailPage navigatetoemailpage(IWebDriver driver)
        //{
        //    HomePage homepage = OneTimeSetup(driver);
        //    homepage.Login(TestConfigurations.Username, TestConfigurations.Password);
        //    return new EmailPage(driver);
        //}
        public static TranslatePage NavigateToTranslatePage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://perevod.i.ua/");
            return new TranslatePage(driver);
        }
    }
}