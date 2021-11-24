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
    public class ParduotuvePegasasShoppingCartPage : BasePage
    {
        private const string PageAddress = "https://www.pegasas.lt/checkout/cart/";
        private const string ExpectedMessage = "Jūsų krepšelis dar tuščias";
        private IReadOnlyCollection<IWebElement> _itemName => Driver.FindElements(By.CssSelector(".cart-item"));
        private IReadOnlyCollection<IWebElement> _itemPrice=> Driver.FindElements(By.CssSelector(".cart-price"));
        private IWebElement _removeItemButton => Driver.FindElement(By.CssSelector(".action.action-delete"));
        private IWebElement _resultFromPage => Driver.FindElement(By.CssSelector(".cart-empty"));
        public ParduotuvePegasasShoppingCartPage(IWebDriver webdriver) : base(webdriver)
        {
        }
        public ParduotuvePegasasShoppingCartPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }
            return this;
        }
        public ParduotuvePegasasShoppingCartPage VerifyThatItemIsInTheShoppingCart(string itemName)
        {
            foreach (IWebElement item in _itemName)
            {
                Actions action = new Actions(Driver);
                action.MoveToElement(item);
                action.Perform();
                Assert.IsTrue(item.GetAttribute("title").Contains(itemName), $"Item does not exist or is {item.GetAttribute("title")} instead of {itemName}.");
            }
            return this;
        }
        public ParduotuvePegasasShoppingCartPage VerifyThatTheItemPriceIsCorrect(string itemPrice)
        {
            foreach (IWebElement price in _itemPrice)
            {
                Actions action = new Actions(Driver);
                action.MoveToElement(price);
                action.Perform();
                Assert.IsTrue(price.Text.Contains(itemPrice), $"Item price is {price.Text} instead of {itemPrice}.");
            }           
            return this;
        }
        public ParduotuvePegasasShoppingCartPage RemoveItemFromShoppingCart()
        {
            foreach (IWebElement item in _itemName)
            {
                Actions action = new Actions(Driver);
                action.MoveToElement(item);
                action.Perform();
                _removeItemButton.Click();
            }
            return this;
        }
        public ParduotuvePegasasShoppingCartPage VerifyThatItemIsRemovedFromShoppingCart()
        {
            Assert.IsTrue(_resultFromPage.Text.Contains(ExpectedMessage), $"Displayed text after removing item/s from shopping cart is {_resultFromPage.Text} instead of {ExpectedMessage}");
            return this;
        }

    }
}
