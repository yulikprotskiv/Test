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
    [Category("TranslateFunctionality")]
    class TranslateTests:TestBase
    {
        TranslatePage translatePage;
        public override void BaseOneTimeSetUp()
        {
            translatePage = Navigator.NavigateToTranslatePage(driver);
        }
        [Test]
        public void TranslateFromUkrToEnglish()
        {
            translatePage.TranslateToLang("Ukr", "Eng", "Синій", "Blue");
            //Assert.AreEqual(translatePage.SecondTextArea.GetAttribute("value"), expectedText);
        }
        [Test]
        public void TranslateFromUkrToFrench()
        {
            translatePage.TranslateToLang("Ukr", "Fre", "Жовтий", "Jaune");
        }
        [Test]
        public void TranslateFromUkrToGerman()
        {
            translatePage.TranslateToLang("Ukr", "Ger", "Червоний", "Roter");
        }
        [Test]
        public void TranslateFromUkrToPolish()
        {
            translatePage.TranslateToLang("Ukr", "Pol", "Помаранчевий", "Pomarańczowy");
        }
    }
}
