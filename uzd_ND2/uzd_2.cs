using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uzd_ND2
{
    class uzd_2
    {
        public static IWebDriver _driver;

        //1. uzd
        [Test]
        public static void TestSeleniumSingleCheckboxDemo()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://demo.seleniumeasy.com/basic-checkbox-demo.html";
            IWebElement checkBox = _driver.FindElement(By.Id("isAgeSelected"));
            if (true != checkBox.Selected)
            {
                checkBox.Click();
            }
            string result = "Success - Check box is checked";
            IWebElement resultFromPage = _driver.FindElement(By.Id("txtAge"));
            Assert.AreEqual(result, resultFromPage.Text, "The text \"Sucess - Check box is checked\" is not displayed when the checkbox is checked.");
        }

        //2. uzd
        [Test]
        public static void TestSeleniumMultipleCheckboxDemoSelectAllCheckboxes()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://demo.seleniumeasy.com/basic-checkbox-demo.html";
            IWebElement checkBox = _driver.FindElement(By.Id("isAgeSelected"));
            if (checkBox.Selected)
            {
                checkBox.Click();
            }
            IReadOnlyCollection<IWebElement> multipleCheckBox = _driver.FindElements(By.ClassName("cb1-element"));
            foreach (IWebElement element in multipleCheckBox)
            {
                element.Click();
            }
            string result = "Uncheck All";
            IWebElement button = _driver.FindElement(By.Id("check1"));
            button.GetProperty("value");
            Assert.AreEqual(result, button.GetProperty("value"), "Button does not display \"Uncheck All\"");
        }

        //3. uzd
        [Test]
        public static void TestSeleniumMultipleCheckboxDemoUncheckAllButton()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://demo.seleniumeasy.com/basic-checkbox-demo.html";
            IWebElement checkBox = _driver.FindElement(By.Id("isAgeSelected"));
            if (checkBox.Selected)
            {
                checkBox.Click();
            }
            IReadOnlyCollection<IWebElement> multipleCheckBox = _driver.FindElements(By.ClassName("cb1-element"));
            foreach (IWebElement element in multipleCheckBox)
            {
                if (true != element.Selected)
                element.Click(); //selects all
            }
            IWebElement button = _driver.FindElement(By.Id("check1"));
            button.GetProperty("value");
            if (button.GetProperty("value") == "Uncheck All")
            {
                button.Click();
            }
            int checkBoxesSelected = 0;
            foreach (IWebElement element in multipleCheckBox)
            {
                if (element.Selected)
                {
                    checkBoxesSelected++; //kiek checkboxes parinkta 
                }
            }
            Assert.AreEqual(0, checkBoxesSelected, $"There are still {checkBoxesSelected} checkboxes selected");
        }
    }
}
