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
    public class ParduotuvePegasasTest : BaseTest
    {
        [Test]
        public void TestLogInWithNonExistingAccount()
        {
            _pegasasHomePage.NavigateToDefaultPage()
                .ClickAtsijungti()
                .ClickPrisijungti();
            string email = "ghdkslshj@gmail.com";
            string password = "djskafjdjs";
            _pegasasLogInPage.NavigateToDefaultPage()
                .LogInInfoInput(email, password)
                .LogInButtonClick()
                .VerifyIncorrectLoginErrorMessageDisplayed();
        }

        [TestCase("Šekspyras", "Sonetai", TestName = "Search for Šekspyras \"Sonetai\" in searchbar")]
        [TestCase("Stephen King", "Svetimas", TestName = "Search for Stephen King \"Svetimas\" in searchbar")]
        [TestCase("Vincas Mykolaitis-Putinas", "Altorių šešėly", TestName = "Search for Vincas Mykolaitis-Putinas \"Altorių šešėly\" in searchbar")]
        public void TestFindSpecificBookUsingSearchBar(string author, string bookName)
        {
            _pegasasHomePage.NavigateToDefaultPage()
                .WriteInSearchBox(author, bookName)
                .ClickEnterInSearchBox()
                .VerifyThatSearchedItemIsDisplayed(author, bookName);
        }

        [TestCase("Sofi pasirinkimas", TestName = "Search for \"Sofi pasirinkimas\" in Pegaso kolekcijos knygos")]
        [TestCase("Kvepalai", TestName = "Search for \"Kvepalai\" in Pegaso kolekcijos knygos")]
        [TestCase("Martinas Idenas", TestName = "Search for \"Martinas Idenas\" in Pegaso kolekcijos knygos")]
        public void TestFindBookInPegasoKolekcijosSection(string bookName)
        {
            _pegasasHomePage.NavigateToDefaultPage()
                 .ClickPegasoKolekcijosKnygosButton();
            _pegasasPegasoKolekcijosKnygosPage.NavigateToDefaultPage()
                .PopUpClose()
                .FindBook(bookName)
                .VerifyBookIsDisplayed(bookName);
        }

        [TestCase("Kuprinė Pepe Jeans SCRATCH, 40 cm, Black", "49,99", TestName = "Item \"Kuprinė Pepe Jeans SCRATCH, 40 cm, Black\" and its price \"49,99e\" are displayed in shopping cart.")]
        public void TestPutItemInShoppingBasket(string itemName, string itemPrice)
        {
            _pegasasHomePage.NavigateToDefaultPage()
                 .NavigateToKuprinesSection();
            _pegasasPegasoKuprinesPage.NavigateToDefaultPage()
                .PopUpClose()
                .FindAndAddItemToBasket(itemName)
                .NavigateToShoppingCart();
            _pegasasPegasoShoppingCartPage.VerifyThatItemIsInTheShoppingCart(itemName)
                .VerifyThatTheItemPriceIsCorrect(itemPrice);
        }

        [Test]
        public void TestRemoveItemFromShoppingBasket()
        {
            _pegasasHomePage.NavigateToDefaultPage()
                .NavigateToShoppingCart();
            _pegasasPegasoShoppingCartPage.RemoveItemFromShoppingCart()
                .VerifyThatItemIsRemovedFromShoppingCart();
        }
    }
}
