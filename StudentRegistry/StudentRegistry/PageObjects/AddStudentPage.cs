using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistry.PageObjects
{
    public class AddStudentPage : BasePage
    {
        public AddStudentPage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl =>
            "https://mvc-app-node-express.nakov.repl.co/add-student";

        public IWebElement FieldName =>
            driver.FindElement(By.CssSelector("#name"));

        public IWebElement FieldEmail =>
            driver.FindElement(By.CssSelector("#email"));

        public IWebElement ButtonAdd =>
            driver.FindElement(By.CssSelector("body > form > button"));

        public IWebElement ElementErrorMsg =>
            driver.FindElement(By.CssSelector("body > div"));

        public string GetErrorMsg()
        {
            return ElementErrorMsg.Text;
        }

        public void AddStudent(string name, string email)
        {
            this.FieldName.SendKeys(name);
            this.FieldEmail.SendKeys(email);
            this.ButtonAdd.Click();
        }
    }
}
