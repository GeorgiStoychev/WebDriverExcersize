using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverExcersize.PageObjects
{
    internal class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl => "http://localhost:8080/";

        public IWebElement ElementStudentsCount => driver.FindElement(By.CssSelector("body p b"));

        public string GetStudentsCount()
        {
            return ElementStudentsCount.ToString();
        }
    }
}
