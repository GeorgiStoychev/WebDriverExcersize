using NUnit.Framework;
using WebDriverExcersize.PageObjects;

namespace WebDriverExcersize.Tests
{
    internal class ViewStudentsTests : BaseTest
    {

        [Test]
        public void Test_ViewStudentsPage_Content()
        {
            var page = new ViewStudentsPage(driver);
            page.Open();

            Assert.That(page.GetTitlePage, Is.EqualTo("Students"));
            Assert.That(page.GetPageHeadingText, Is.EqualTo("Registered Students"));

            var students = page.GetRegisteredStudents();

            foreach (var student in students)
            {
                Assert.IsTrue(student.IndexOf("(") > 0);
                Assert.IsTrue(student.IndexOf(")") == student.Length-1);
            }
        }

        [Test]
        public void Test_ViewStudentPage_Links()
        {
            var page = new ViewStudentsPage(driver);
            page.Open();
            page.LinkViewStudent.Click();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());

            page.Open();
            page.LinkHomePage.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());

            page.Open();
            page.LinkAddStudents.Click();
            Assert.IsTrue(new AddStudentPage(driver).IsOpen());
        }
    
    }
}
