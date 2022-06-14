using NUnit.Framework;
using WebDriverExcersize.PageObjects;

namespace WebDriverExcersize.Tests
{
    internal class HomePageTests : BaseTest
    {
        [Test]
        public void Test_HomePage_Content()
        {
            var page = new HomePage(driver);
            page.Open();

            Assert.That(page.GetTitlePage, Is.EqualTo("MVC Example"));
            Assert.That(page.GetPageHeadingText, Is.EqualTo("Students Registry"));

            page.GetStudentsCount();
        }

        [Test]
        public void Test_Home_Page_Links()
        {
            var page = new HomePage(driver);
            page.Open();
            page.LinkHomePage.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());

            page.Open();
            page.LinkAddStudents.Click();
            Assert.IsTrue(new AddStudentPage(driver).IsOpen());

            page.Open();
            page.LinkViewStudent.Click();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());
        }
    }
}
