using automatinis_testavimas.Drivers;
using automatinis_testavimas.page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatinis_testavimas.test
{
    public class SelectDropDownDemoTest
    {
        private static SelectDropDownDemoPage _page;

        [OneTimeSetUp]
        public static void SetUp()
        {
            //IWebDriver driver = new ChromeDriver();
            IWebDriver driver = CustomDriver.GetChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _page = new SelectDropDownDemoPage(driver);
        }

        [OneTimeTearDown]

        public static void TearDown()
        {
            _page.CloseBrowser();
        }

        [Test]
        public void TestDropDown()
        {
            _page.SelectFromDropdownByText("Friday")
                .VerifyResult("Friday");
        }

        [Test]
        public void TestMultiDropDown()
        {
            _page.SelectFromMultiDropDownByValue("Ohio", "Florida")
                .ClickFirstSelectedButton();
        }
    }
}
