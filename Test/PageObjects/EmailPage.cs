using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.PageObjects
{
    class EmailPage
    {
        public IWebDriver driver;
        public EmailPage(IWebDriver driver)
            {
                this.driver = driver;
            }     
        //Email elements
        public IWebElement MailName() => driver.FindElement(By.XPath("//ul[@class='sn_menu']//span[text()='protskiv26@i.ua']"));
        public IWebElement CreateLetterBtn() => driver.FindElement(By.XPath("//div[@class='Body']//a[text()= 'Створити листа']"));      
        public IWebElement ReceiverField() => driver.FindElement(By.Id("to"));
        public IWebElement SubjectField() => driver.FindElement(By.Name("subject"));
        public IWebElement DescriptionField() => driver.FindElement(By.Id("text"));
        public IWebElement SentMailButton() => driver.FindElement(By.Name("send"));
        public IWebElement IncomingMailsTab() => driver.FindElement(By.LinkText("Відправлені"));
        public IWebElement FirstMail() => driver.FindElement(By.XPath("//*[@id='mesgList']/form/div[1]/a"));
        public IWebElement Subject() => driver.FindElement(By.XPath("//div[2]/h3"));
        public IWebElement Description() => driver.FindElement(By.XPath("//div[@class='message_body']"));
        public IWebElement Receiver() => driver.FindElement(By.XPath("//div[@class='to']/div[@class='field_value']"));
        public IWebElement SubjectOfIncomingMail() => driver.FindElement(By.XPath("//*[@id='mesgList']/form/div[1]/a/span[3]/span"));

        //Received emails
        public IWebElement FirstLetter() => driver.FindElement(By.XPath("//span[text()='Невелика довідка про можливості пошти']"));
        public IWebElement SecondLetter() => driver.FindElement(By.XPath("//span[text()='Рекомендації по безпеці Вашого акаунту']"));
        public IWebElement ThirdLetter() => driver.FindElement(By.XPath("//span[text()='Обережно шахраї!']"));
        public IWebElement FourthLetter() => driver.FindElement(By.XPath("//span[text()='Ласкаво просимо на I.UA!']"));

        public void CreateNewLetter()
        {
            CreateLetterBtn().Click();
            ReceiverField().SendKeys("protskiv26@i.ua");
            SubjectField().SendKeys("Letter for test");
            DescriptionField().SendKeys("Description Test");
            //SentMailButton().Click();
        }

        public IWebElement MainPage() => driver.FindElement(By.XPath("//li[@class='ho_menu_item']/a[text()='Головна']"));
        public IWebElement LogoutButton() => driver.FindElement(By.XPath("//li[@class='right']"));
        public IWebElement LoginForm() => driver.FindElement(By.XPath("//ul[@class='user_menu']"));
        public IWebElement Login_on_FirstWindow() => driver.FindElement(By.XPath("//div[@class='block_gamma_gradient mail_login']"));
    }
}
