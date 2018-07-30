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
    class TranslatePage
    {
        public IWebDriver driver;
        public TranslatePage(IWebDriver driver)
            {
                this.driver = driver;
            }
        public IWebElement FirstTextArea => driver.FindElement(By.Id("first_textarea"));
        public IWebElement SecondTextArea => driver.FindElement(By.Id("second_textarea"));
        public IWebElement TranslateButton => driver.FindElement(By.Name("commit"));
        public IWebElement FirstLanguageDropdown => driver.FindElement(By.Id("first_lang_selector"));
        public IWebElement SecondLanguageDropdown => driver.FindElement(By.Id("second_lang_selector"));

        public void TranslateFrom(string from)
        {
            FirstLanguageDropdown.Click();
            IWebElement Language = driver.FindElement(By.XPath($"//*[@id='popup_language_menu_1']/ul/li[@data-lang='{from}']"));
            Thread.Sleep(300);
            Language.Click();
        }
        public void TranslateTo(string to)
        {
            SecondLanguageDropdown.Click();
            IWebElement Language = driver.FindElement(By.XPath($"//*[@id='popup_language_menu_2']/ul/li[@data-lang='{to}']"));
            Thread.Sleep(300);
            Language.Click();
        }
        public void TranslateToLang(string from, string to, string enteredText, string expectedText)
        {
            TranslateFrom(from);
            TranslateTo(to);
            FirstTextArea.Clear();
            FirstTextArea.SendKeys(enteredText);
            TranslateButton.Click();
            Assert.AreEqual(SecondTextArea.GetAttribute("value"), expectedText);
        }
    }
}

