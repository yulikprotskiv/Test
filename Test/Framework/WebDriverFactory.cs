using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;

namespace Test.Framework
{
    class WebDriverFactory
    {
        private const string Chrome = "Ch";
        private const string Firefox = "FF";
        private const string InternetExplorer = "IE";

        private static IWebDriver driver = null;

        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                TestConfigurations configs = TestConfigurations.GetInstance();

                if (TestConfigurations.Browser == Chrome)
                {
                    return new ChromeDriver();
                }
                else if (TestConfigurations.Browser == Firefox)
                {
                    return new FirefoxDriver();
                }
                else if (TestConfigurations.Browser == InternetExplorer)
                {
                    return new InternetExplorerDriver();
                }
                else
                {
                    throw new Exception("Invalid browser");
                }
            }
            return driver;
        }
    }
}
