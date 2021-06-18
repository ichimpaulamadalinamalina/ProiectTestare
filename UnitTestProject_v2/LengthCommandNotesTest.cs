/**************************************************************************
 *                                                                        *
 *  File:        LengthCommandNotesTest.cs                                *
 *  Copyright:   (c) 2021, Sescu Raluca                                   *
 *  Description: Automation Test used to check if the Note Comanda        *
 *              textarea has a maximum length of 20 characters            *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using UnitTestProject1.PageObjects.CartPage;
using UnitTestProject1.PageObjects.CheckoutPage;
using UnitTestProject1.PageObjects.HomePage;
using UnitTestProject1.PageObjects.HomePage.input;
using UnitTestProject1.PageObjects.ShopPage;

namespace UnitTestProject1
{
    [TestClass]
    public class LengthCommandNotesTest
    {
        private IWebDriver driver;
        private HomePage homePage;
        private ShopPage shopPage;
        private CartPage cartPage;
        private CheckoutPage checkoutPage;

        [TestInitialize]
        public void TestInit()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://cuptorulmoldovencei.ro/");
            homePage = new HomePage(driver);
            var menuItemControl = homePage.homeItemControl;
            shopPage = menuItemControl.NavigateToShopPage();
        }

        [TestMethod]
        public void Note_Comanda_Textarea_Should_Accept_Maximum_Of_20_Characters()
        {
            var menuItemControl = homePage.homeItemControl;

            // Add product
            shopPage.AddProduct();

            // Open Cart Toggle Window
            menuItemControl.ToggleCartWindow();

            // Go to Cart Page
            cartPage = menuItemControl.NavigateToCartPage();

            // Take the item control of the cart
            var cartItemControl = cartPage.cartItemControl;

            // Go to Checkout Page
            checkoutPage = cartItemControl.NavigateToCheckoutPage();

            // Insert more than 20 characters into textarea 
            checkoutPage.SendNoteComandaInputs(new NoteComandaBo());

            // Test if the form has changed
            Assert.AreEqual("123456789abcdefghijk", checkoutPage.NoteComandaText());

        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
