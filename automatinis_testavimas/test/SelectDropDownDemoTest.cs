<<<<<<< HEAD
﻿using automatinis_testavimas.Drivers;
using automatinis_testavimas.page;
=======
<<<<<<< HEAD
﻿using automatinis_testavimas.Drivers;
using automatinis_testavimas.page;
=======
﻿using automatinis_testavimas.page;
>>>>>>> 703b65eec8ca97e418745be9c5780a0c61854c67
>>>>>>> 2d143fe9a56137021fd918232f38eb466da6c2ef
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
<<<<<<< HEAD
            //IWebDriver driver = new ChromeDriver();
            IWebDriver driver = CustomDriver.GetChromeDriver();
=======
<<<<<<< HEAD
            //IWebDriver driver = new ChromeDriver();
            IWebDriver driver = CustomDriver.GetChromeDriver();
=======
            IWebDriver driver = new ChromeDriver();
>>>>>>> 703b65eec8ca97e418745be9c5780a0c61854c67
>>>>>>> 2d143fe9a56137021fd918232f38eb466da6c2ef
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
