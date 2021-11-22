using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatinis_testavimas.page
{
    public class ND4SelectDropDownDemoPage : BasePage
    {
        //countries
        public const string PageAddress = "https://demo.seleniumeasy.com/basic-select-dropdown-demo.html";
        private SelectElement _multiDropDown => new SelectElement(Driver.FindElement(By.Id("multi-select")));
        private IWebElement _firstSelectedButton => Driver.FindElement(By.Id("printMe"));
        private IWebElement _getAllSelectedButton => Driver.FindElement(By.Id("printAll"));
        private IWebElement _displayedResult => Driver.FindElement(By.CssSelector(".getall-selected"));

        public ND4SelectDropDownDemoPage(IWebDriver webdriver) : base(webdriver)
        {
        }
        public ND4SelectDropDownDemoPage ClickFirstSelectedButton()
        {
            _firstSelectedButton.Click();
            return this;
        }
        public ND4SelectDropDownDemoPage ClickGetAllSelectedButton()
        {
            _getAllSelectedButton.Click();
            return this;
        }
        public ND4SelectDropDownDemoPage SelectFromMultiDropdown(List<string> listOfStates)
        {
            _multiDropDown.DeselectAll();
            Actions action = new Actions(Driver);
            action.KeyDown(Keys.LeftControl);
            foreach (string state in listOfStates)
            {
                foreach (IWebElement option in _multiDropDown.Options)
                {
                    if (state.Equals(option.GetAttribute("value")))
                    {
                        action.Click(option);
                        break;
                    }
                }
            }
            action.KeyUp(Keys.LeftControl);
            action.Build().Perform();
            return this;
        }
        public ND4SelectDropDownDemoPage VerifyThatExpectedResultIsDisplayed(string result)
        {
            Assert.IsTrue(_displayedResult.Text.Contains(result), $"Result was not {result}, but {_displayedResult.Text}");
            return this;
        }
    }
}
