using automatinis_testavimas.page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
        //private const string ResultText = "";
        //private IWebElement _bookName => Driver.FindElement(By.CssSelector(".product-item-name"));
        private IReadOnlyCollection<IWebElement> _bookName => Driver.FindElements(By.CssSelector(".product-item-name"));
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
        public ParduotuvePegasasPegasoKolekcijosKnygosPage VerifyBookIsDisplayed(string bookName)
        {
            Actions action = new Actions(Driver);

            foreach (IWebElement book in _bookName)
            {
                IWebElement foundBook = null;
                while (book.Text.ToUpper().Contains(bookName.ToUpper()))
                {
                    foundBook = book;
                }
                Assert.IsTrue(foundBook.Text.ToUpper().Contains(bookName.ToUpper()), $"Book is not displayed or the book title is {foundBook.Text} instead of {bookName}");
            }
            return this;
        }
    }
}
