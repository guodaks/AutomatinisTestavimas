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
                .ClickPrisijungti();
            string email = "ghdkslshj@gmail.com";
            string password = "djskafjdjs";
            _pegasasLogInPage.NavigateToDefaultPage()
                .LogInInfoInput(email, password)
                .LogInButtonClick()
                .VerifyIncorrectLoginErrorMessageDisplayed();
        }
        [Test]
        public void TestFindSpecificBookUsingSearchBar()
        {
            string author = "Šekspyras";
            string bookName = "Sonetai";
            _pegasasHomePage.NavigateToDefaultPage()
                .WriteInSearchBox(author, bookName)
                .ClickEnterInSearchBox()
                .VerifyThatSearchedItemIsDisplayed(author, bookName);
        }
        [Test]
        public void TestFindBookInPegasoKolekcijosSection()
        {
            string bookName = "Sofi pasirinkimas";

            _pegasasPegasoKolekcijosKnygosPage.NavigateToDefaultPage()
                .VerifyBookIsDisplayed(bookName);
        }
    }
}
