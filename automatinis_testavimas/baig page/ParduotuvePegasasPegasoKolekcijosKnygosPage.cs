using automatinis_testavimas.page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatinis_testavimas.baig_page
{
    public class ParduotuvePegasasPegasoKolekcijosKnygosPage : BasePage
    {
        private const string PageAddress = "https://www.pegasas.lt/pegaso-kolekcijos-knygos.html";
        private IReadOnlyCollection<IWebElement> _bookName => Driver.FindElements(By.CssSelector(".product-item-link"));
        private IWebElement _bookTitle => Driver.FindElement(By.CssSelector(".page-title-wrapper.product"));
        private IWebElement _popUp2 => Driver.FindElement(By.CssSelector(".soundest-form-simple-close"));
        public ParduotuvePegasasPegasoKolekcijosKnygosPage(IWebDriver webdriver) : base(webdriver)
        {       }
        public ParduotuvePegasasPegasoKolekcijosKnygosPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }
            return this;
        }
        public ParduotuvePegasasPegasoKolekcijosKnygosPage PopUp2Close()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            if (_popUp2.Displayed)
            _popUp2.Click();           
            return this;
        }
        public ParduotuvePegasasPegasoKolekcijosKnygosPage FindBook(string bookName)
        {
            {
                foreach (IWebElement bookTitle in _bookName)
                {
                    Actions action = new Actions(Driver);
                    action.MoveToElement(bookTitle);
                    action.Perform();
                    bookName = bookName.Replace(" ", "-"); //jei pavadinimas su tarpu, pakeicia bruksneliu (nes links neturi tarpu)
                    if (bookTitle.GetAttribute("href").Contains(bookName.ToLower()))
                    {
                        bookTitle.Click();
                        break;
                    }
                }
                return this;
            }
        }
        public ParduotuvePegasasPegasoKolekcijosKnygosPage VerifyBookIsDisplayed(string bookName)
        {
            Assert.IsTrue(_bookTitle.Text.Contains(bookName), $"Book is not displayed or the book title is {_bookTitle.Text}");
            return this;
        }
    
    }
}
