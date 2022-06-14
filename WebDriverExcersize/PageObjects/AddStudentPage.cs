using OpenQA.Selenium;


namespace WebDriverExcersize.PageObjects
{
    internal class AddStudentPage : BasePage
    {
        public AddStudentPage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl => "http://localhost:8080/add-student";

        public IWebElement FieldStudentName => driver.FindElement(By.XPath("//input[@id='name']"));
        public IWebElement FieldStudentEmail => driver.FindElement(By.XPath("//input[@id='email']"));
        public IWebElement ButtonAdd => driver.FindElement(By.XPath("//button[@type='submit']"));

        public IWebElement ElementErrorMessage => driver.FindElement(By.CssSelector("body > div"));

        public void AddStudent(string name, string email)
        {
            FieldStudentName.SendKeys(name);
            FieldStudentEmail.SendKeys(email);
            ButtonAdd.Click();
        }

        public string GetErrorMessage()
        {
            return ElementErrorMessage.Text;
        }
    }
}
