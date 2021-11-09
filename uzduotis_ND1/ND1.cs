using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uzduotis_ND1
{
    public class Class1
    {
        [Test]
        public static void TestSeleniumPage2InputFields_1()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://demo.seleniumeasy.com/basic-first-form-demo.html";
            IWebElement inputField1 = chrome.FindElement(By.Id("sum1"));
            string myValue1 = "2";
            inputField1.SendKeys(myValue1);
            IWebElement inputField2 = chrome.FindElement(By.Id("sum2"));
            string myValue2 = "2";
            inputField2.SendKeys(myValue2);
            Thread.Sleep(5000);
            IWebElement popUp = chrome.FindElement(By.Id("at-cv-lightbox-close"));
            popUp.Click();
            IWebElement button = chrome.FindElement(By.CssSelector("#gettotal > button"));
            button.Click();
            IWebElement result = chrome.FindElement(By.Id("displayvalue"));
            Assert.AreEqual("4", result.Text, "2 + 2 does not equal 4");
            chrome.Quit();
        }
    }
}
