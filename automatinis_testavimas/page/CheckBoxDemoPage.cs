using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatinis_testavimas.page
{
        public class CheckboxDemoPage : BasePage
        {
            private const string PageAddress = "https://demo.seleniumeasy.com/basic-checkbox-demo.html";
            private const string TextToCheck = "Success - Check box is checked";
            private IWebElement _singleCheckbox => Driver.FindElement(By.Id("isAgeSelected"));
            private IWebElement _Text => Driver.FindElement(By.Id("txtAge"));
            private IReadOnlyCollection<IWebElement> MultipleCheckboxList => Driver.FindElements(By.CssSelector(".cb1-element"));
            private IWebElement _Button => Driver.FindElement(By.Id("check1"));

            public CheckboxDemoPage(IWebDriver webdriver) : base(webdriver)
            {
                Driver.Url = PageAddress;
            }
            public CheckboxDemoPage CheckSingleCheckbox()
            {
                if (!_singleCheckbox.Selected)
                    _singleCheckbox.Click();
                return this;
            }

            public CheckboxDemoPage CheckResult()
            {
                Assert.IsTrue(_Text.Text.Equals(TextToCheck));
                return this;
            }


            private void UncheckFirstBlockCheckbox()
            {
                if (_singleCheckbox.Selected)
                    _singleCheckbox.Click();
            }

            public CheckboxDemoPage CheckAllCheckboxes()
            {
                UncheckFirstBlockCheckbox();
                foreach (IWebElement element in MultipleCheckboxList)
                {
                    if (!element.Selected)
                        element.Click();
                }
                return this;
            }

            public CheckboxDemoPage CheckButtonValue(string value)
            {
                // GetWait().Until(ExpectedConditions.TextToBePresentInElement(_Button, "Uncheck All"));
                // DefaultWait.Until(ExpectedConditions.TextToBePresentInElementValue(_Button, "Uncheck All"));
                //Assert.IsTrue(Button.GetAttribute("value").Equals(value), "Second is wrong");
                return this;
            }

            public CheckboxDemoPage ClickButton()
            {
                _Button.Click();
                return this;
            }

            public CheckboxDemoPage VerifyThatAllCheckboxesAreUnchecked()
            {
                foreach (IWebElement element in MultipleCheckboxList)
                {
                    Assert.False(element.Selected, "Checkbox is still checked");
                    //Assert.IsTrue(!element.Selected, "Checkbox is still checked");
                    //Assert.That(!element.Selected, "Checkbox is still checked");
                }
                return this;
            }
    }
}
