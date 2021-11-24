using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatinis_testavimas.page
{
    public class ND3SeleniumCheckBoxPage
    {
        private static IWebDriver _driver;

        private IWebElement _checkBox => _driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement _resultFromPageFirstCheckbox => _driver.FindElement(By.Id("txtAge"));
        private IReadOnlyCollection<IWebElement> _multipleCheckBox => _driver.FindElements(By.ClassName("cb1-element"));
        private IWebElement _button => _driver.FindElement(By.Id("check1"));

        public ND3SeleniumCheckBoxPage(IWebDriver webdriver)
        {
            _driver = webdriver;
        }
        public void SelectFirstCheckBox()
        {
            if (true != _checkBox.Selected)
            _checkBox.Click();
        }
        public void FirstCheckBoxResult(string expectedResult)
        {
            Assert.AreEqual(expectedResult, _resultFromPageFirstCheckbox.Text, $"Result is not {expectedResult}.");
        }
        private void UncheckFirstCheckbox()
        {
            if (_checkBox.Selected)
                _checkBox.Click();
        }

        public void SelectMultipleCheckBox()
        {
            UncheckFirstCheckbox();
            foreach (IWebElement element in _multipleCheckBox)
            {
                if (true != element.Selected)
                {
                    element.Click();
                }
            }
        }
        public void CheckMultipleCheckBoxButtonValue(string expectedResult)
        {
            _button.GetProperty("value");
            Assert.AreEqual(expectedResult, _button.GetProperty("value"), $"Result is not {expectedResult}");
        }
        public void ClickUncheckAllButton()
        {
            if (_button.GetProperty("value") == "Uncheck All")
            {
                _button.Click();
            }
        }
        public void VerifyThatAllMultipleCheckBoxesAreUnchecked()
        {
            int checkBoxesSelected = 0;
            foreach (IWebElement element in _multipleCheckBox)
            {
                if (element.Selected)
                {
                    checkBoxesSelected++;
                }
            }
            Assert.AreEqual(0, checkBoxesSelected, $"There are still {checkBoxesSelected} checkboxes selected");
        }

    }
}
