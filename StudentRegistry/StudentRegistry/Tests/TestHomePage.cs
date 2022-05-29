
using NUnit.Framework;
using StudentRegistry.PageObjects;

namespace StudentRegistry.Tests
{
    public class TestHomePage : BaseTest
    {

        [Test]
        public void Test_HomePage_Content()
        {
            var page = new HomePage(driver);
            page.Open();

            Assert.AreEqual("MVC Example",page.GetPageTitle());

            Assert.AreEqual("Students Registry", page.GetPageHeadingText());

            page.GetStudentsCount();
        }

        [Test]
        public void Test_HomePageLink()
        {
            var home_page = new HomePage(driver);

            home_page.Open();
            home_page.LinkHomePage.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());

            home_page.Open();
            home_page.LinkAddStudentsPage.Click();
            Assert.IsTrue(new AddStudentPage(driver).IsOpen());

            home_page.Open();
            home_page.LinkViewStudentsPage.Click();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());
        
        }

        [Test]
        public void Test_StrudentsCount()
        {
            var homePage = new HomePage(driver);

            homePage.Open();
            Assert.IsTrue(homePage.GetStudentsCount() > 0);
        }
    }
}
