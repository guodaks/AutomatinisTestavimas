using automatinis_testavimas.page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatinis_testavimas.test
{
    public class ND3SeleniumCheckBoxTest
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://demo.seleniumeasy.com/basic-checkbox-demo.html";
            _driver.Manage().Window.Maximize();
        }
        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public static void TestSelectFirstCheckbox()
        {
            ND3SeleniumCheckBoxPage page = new ND3SeleniumCheckBoxPage(_driver);
            page.SelectFirstCheckBox();
            string result = "Success - Check box is checked";
            page.FirstCheckBoxResult(result); //checks if the displayed text is correct ("Success - Check box is checked")          
        }

        [Test]
        public static void TestSelectMultipleCheckBoxes()
        {
            ND3SeleniumCheckBoxPage page = new ND3SeleniumCheckBoxPage(_driver);
            page.SelectMultipleCheckBox();
            string buttonResult = "Uncheck All";
            page.CheckMultipleCheckBoxButtonValue(buttonResult); //checks if the button contains "Uncheck All"
        }
        [Test]
        public static void TestMultipleCheckBoxesUncheckAll()
        {
            ND3SeleniumCheckBoxPage page = new ND3SeleniumCheckBoxPage(_driver);
            page.SelectMultipleCheckBox();
            page.ClickUncheckAllButton();
            page.VerifyThatAllMultipleCheckBoxesAreUnchecked(); 
        }
    }
}
