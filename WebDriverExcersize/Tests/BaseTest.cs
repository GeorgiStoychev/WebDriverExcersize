using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebDriverExcersize.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;


        [OneTimeSetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
        }

        [OneTimeTearDown]
        public void CloseDriver()
        {
            driver.Quit();
        }
    }
}