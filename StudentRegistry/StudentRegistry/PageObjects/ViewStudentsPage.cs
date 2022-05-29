using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;


namespace StudentRegistry.PageObjects
{
    public class ViewStudentsPage : BasePage
    {
        public ViewStudentsPage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl =>
            "https://mvc-app-node-express.nakov.repl.co/students";

        public IReadOnlyCollection<IWebElement> ListItemsStudents =>
            driver.FindElements(By.CssSelector("body > ul > li"));

        public string[] GetRegisteredStudents()
        {
            var elementsStudents = this.ListItemsStudents.Select(s => s.Text).ToArray();
            return elementsStudents;
        }

    }
}
