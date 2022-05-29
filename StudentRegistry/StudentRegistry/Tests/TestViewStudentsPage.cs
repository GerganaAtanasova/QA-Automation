using NUnit.Framework;
using OpenQA.Selenium;
using StudentRegistry.PageObjects;
using System.Threading;

namespace StudentRegistry.Tests
{
    public class TestViewStudentsPage : BaseTest
    {

        [Test]
        public void Test_ViewStudents_Content()
        {
            var page = new ViewStudentsPage(driver);
            page.Open();
      
            Assert.AreEqual("Registered Students", page.GetPageHeadingText());
            Assert.AreEqual("Students", page.GetPageTitle());

           var students =  page.GetRegisteredStudents();

            foreach(var student in students)
            {
                Assert.IsTrue(student.IndexOf("(") > 0);
                Assert.IsTrue(student.LastIndexOf(")") == student.Length-1);
            }
        }


        [Test]
        public void Test_ViewStudentsPageLink()
        {
            var page = new ViewStudentsPage(driver);

            page.Open();
            page.LinkHomePage.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());

            page.Open();
            page.LinkViewStudentsPage.Click();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());

            page.Open();
            page.LinkAddStudentsPage.Click();
            Assert.IsTrue(new AddStudentPage(driver).IsOpen());
        }
    }
}
