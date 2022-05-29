using NUnit.Framework;
using StudentRegistry.PageObjects;
using System;

namespace StudentRegistry.Tests
{
    public class TestAddStudentsPage : BaseTest
    {

        [Test]
        public void Test_AddStudentsPage_Content()
        {
            var page = new AddStudentPage(driver);
            page.Open();

            Assert.AreEqual("Add Student", page.GetPageTitle());

            Assert.AreEqual("Register New Student", page.GetPageHeadingText());

            Assert.IsEmpty(page.FieldName.Text);
            Assert.IsEmpty(page.FieldEmail.Text);
            Assert.AreEqual("Add",page.ButtonAdd.Text);
        }

        [Test]
        public void Test_AddStudentPage_Links()
        {
            var page = new AddStudentPage(driver);

            page.Open();
            page.LinkAddStudentsPage.Click();
            Assert.IsTrue(new AddStudentPage(driver).IsOpen());

            page.Open();
            page.LinkHomePage.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());

            page.Open();
            page.LinkViewStudentsPage.Click();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());
        }

        [Test]
        public void Test_AddValidStudent()
        {
            var add_student_page = new AddStudentPage(driver);

            add_student_page.Open();
            string name = "New student" + DateTime.Now.Ticks;
            string email = "email" + DateTime.Now.Ticks + "@email.com";
            add_student_page.AddStudent(name, email);
            

            var view_student_page = new ViewStudentsPage(driver);
            view_student_page.Open();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());

            var students =  view_student_page.GetRegisteredStudents();

            var expected = name + " (" + email + ")";
            Assert.AreEqual(expected, students[students.Length - 1]);
        }

        [Test]
        [TestCase ("","")]
        [TestCase ("abcd","")]
        public void Test_AddInvalidStudent(string name,string email)
        {
            var addStudentPage = new AddStudentPage(driver);
            addStudentPage.Open();
            addStudentPage.AddStudent(name, email);

            Assert.IsTrue(new AddStudentPage(driver).IsOpen());
            Assert.AreEqual("Cannot add student. Name and email fields are required!",addStudentPage.GetErrorMsg());
            Assert.IsEmpty(addStudentPage.FieldEmail.Text);
            Assert.IsEmpty(addStudentPage.FieldName.Text);
        }
    }
}
