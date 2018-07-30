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

namespace Test.Framework
{
    public class TestBase
    {
        public IWebDriver driver;
        //string testname = TestContext.CurrentContext.Test.Name;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = WebDriverFactory.GetInstance();
            BaseOneTimeSetUp();
        }
        public virtual void BaseOneTimeSetUp()
        {

        }

        [SetUp]
        public void BaseSetUp()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine(TestContext.CurrentContext.Test.Name);
        }
        [TearDown]
        public void BaseTearDown()
        {
            Console.WriteLine(TestContext.CurrentContext.Result.Outcome.Status);
            Console.WriteLine("----------------------------------------------");

            //TearDown();
        }

        //public virtual void TearDown()
        //{

        //}

        [OneTimeTearDown]
        public void BaseOneTimeTearDown()
        {
            driver.Quit();
            OneTimeTearDown();
        }
        public virtual void OneTimeTearDown()
        {

        }

    }
}
