using NUnit.Framework;
using System;
using WebDriverExcersize.PageObjects;

namespace WebDriverExcersize.Tests
{
    internal class AddStudentPageTests : BaseTest
    {

        [Test]
        public void Test_TestAddStudentPage_Content()
        {
            var page = new AddStudentPage(driver);
            page.Open();

            Assert.That(page.GetTitlePage, Is.EqualTo("Add Student"));
            Assert.That(page.GetPageHeadingText, Is.EqualTo("Register New Student"));

            Assert.IsEmpty(page.FieldStudentName.Text);
            Assert.IsEmpty(page.FieldStudentEmail.Text);
            Assert.That(page.ButtonAdd.Text, Is.EqualTo("Add"));
        }

        [Test]
        public void Test_TestAddStudentPage_Links()
        {
            var page = new AddStudentPage(driver);
            page.Open();
            Assert.IsTrue(new AddStudentPage(driver).IsOpen());

            page.Open();
            page.LinkHomePage.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());

            page.Open();
            page.LinkViewStudent.Click();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());
        }

        [Test]
        public void Test_TestAddStudentPage_AddValidStudent()
        {
            var page = new AddStudentPage(driver);
            page.Open();

            var name = "New Student " + DateTime.Now.Ticks;
            var email = "email" + DateTime.Now.Ticks + "@email.com";

            page.AddStudent(name, email);

            var studentsPage = new ViewStudentsPage(driver);
            studentsPage.Open();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());
            var studentsList = studentsPage.GetRegisteredStudents();
            var lastAddedStudent = studentsList[studentsList.Length - 1];

            Assert.That(lastAddedStudent, Is.EqualTo($"{name} ({email})"));
        }

        [Test]
        public void Test_TestAddStudentPage_AddInvalidStudent()
        {
            var page = new AddStudentPage(driver);
            page.Open();

            var name = "";
            var email = "";

            page.AddStudent(name, email);
            Assert.IsTrue(new AddStudentPage(driver).IsOpen());

            var erroCodeDisplayed = page.GetErrorMessage();
            StringAssert.Contains("Cannot add student", erroCodeDisplayed);

        }
    }
}
