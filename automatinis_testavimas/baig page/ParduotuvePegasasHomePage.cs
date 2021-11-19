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
   public class ParduotuvePegasasHomePage : BasePage
    {
        private const string PageAddress = "https://www.pegasas.lt/";
        //private const string ResultText = "";
        private IWebElement _prisijungtiToggleButton => Driver.FindElement(By.CssSelector(".guest-text"));
        private IWebElement _prisijungtiButton => Driver.FindElement(By.Id("sign-in"));
        private IWebElement _paskyraToggleButton => Driver.FindElement(By.CssSelector(".customer-name"));
        private IWebElement _jusuPaskyraButton => Driver.FindElement(By.CssSelector(".item-content"));
        private IWebElement _userInfo => Driver.FindElement(By.CssSelector(".box-content"));
        private IWebElement _searchBar => Driver.FindElement(By.Id("search"));
        private IWebElement _authorDisplayed => Driver.FindElement(By.CssSelector(".product-item-author.ellipsis"));
        private IWebElement _itemNameDisplayed => Driver.FindElement(By.CssSelector(".product-item-link"));
        private IWebElement _pegasoKolekcijosKnygosButton => Driver.FindElement(By.CssSelector(".lazyloaded"));

        public ParduotuvePegasasHomePage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }
        public ParduotuvePegasasHomePage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }
            return this;
        }
        public ParduotuvePegasasHomePage ClickPrisijungti()
        {
            _prisijungtiToggleButton.Click();            
            _prisijungtiButton.Click();
            return this;
        }
        public ParduotuvePegasasHomePage ClickPaskyra()
        {
            _paskyraToggleButton.Click();
            _jusuPaskyraButton.Click();
            return this;
        }
        public ParduotuvePegasasHomePage WriteInSearchBox(string itemAuthor, string itemName)
        {
            _searchBar.Click();
            _searchBar.SendKeys(itemAuthor + " " + itemName);
            return this;
        }
        public ParduotuvePegasasHomePage ClickEnterInSearchBox()
        {
            _searchBar.SendKeys(Keys.Enter);
            return this;
        }
        public ParduotuvePegasasHomePage VerifyThatSearchedItemIsDisplayed(string itemAuthor, string itemName)
        {
            Assert.IsTrue(_authorDisplayed.Text.ToUpper().Contains(itemAuthor.ToUpper()), $"Book doesn't show up or the author is {_authorDisplayed.Text} instead of {itemAuthor}");
            Assert.IsTrue(_itemNameDisplayed.Text.ToUpper().Contains(itemName.ToUpper()), $"Book doesn't show up or the item name is {_itemNameDisplayed.Text} instead of {itemName}");
            return this;
        }
        public ParduotuvePegasasHomePage ClickPegasoKolekcijosKnygosButton()
        {
            _pegasoKolekcijosKnygosButton.Click();
            return this;
        }
    }
}
