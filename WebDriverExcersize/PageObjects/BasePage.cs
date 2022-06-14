using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverExcersize.PageObjects
{
    internal class BasePage
    {
        protected readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public virtual string PageUrl { get; }

        public IWebElement LinkHomePage => driver.FindElement(By.XPath("//a[contains(. , 'Home')]"));
        public IWebElement LinkViewStudent => driver.FindElement(By.XPath("//a[contains(. , 'View Students')]"));
        public IWebElement LinkAddStudents => driver.FindElement(By.XPath("//a[contains(. , 'Add Student')]"));
        public IWebElement ElementTextHeading => driver.FindElement(By.CssSelector("body h1"));

        public void Open()
        {
            driver.Navigate().GoToUrl(PageUrl);
        }

        public bool IsOpen()
        {
            return driver.Url == this.PageUrl;
        }

        public string GetTitlePage()
        {
            return driver.Title;
        }

        public string GetPageHeadingText()
        {
            return ElementTextHeading.Text;
        }
    }
}
