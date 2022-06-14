using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Linq;

namespace WebDriverExcersize.PageObjects
{
    internal class ViewStudentsPage : BasePage
    {
        public ViewStudentsPage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl => "http://localhost:8080/students";

        public ReadOnlyCollection<IWebElement> ListItemsStudents => driver.FindElements(By.CssSelector("body ul li"));

        public string[] GetRegisteredStudents()
        {
            var elementsStudents = ListItemsStudents.Select(s => s.Text).ToArray();
            return elementsStudents;
        }
    }
}
