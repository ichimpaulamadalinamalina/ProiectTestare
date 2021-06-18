/**************************************************************************
 *                                                                        *
 *  File:        TotalPriceMatchTest.cs                                   *
 *  Copyright:   (c) 2021, Sescu Raluca                                   *
 *  Description: Automation Test used to check if the Total price on the  *
 *               cart matches with the Total price on the Checkout page   *
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
using UnitTestProject1.PageObjects.CartPage;
using UnitTestProject1.PageObjects.CheckoutPage;
using UnitTestProject1.PageObjects.HomePage;
using UnitTestProject1.PageObjects.ShopPage;

namespace UnitTestProject1
{
    [TestClass]
    public class TotalPriceMatchTest
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
        public void Total_Price_On_Cart_Page_Should_Match_With_The_One_On_The_Checkout()
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

            // Get The total Price
            string totalPrice = cartPage.TotalPriceCart();

            // Go to Checkout Page
            checkoutPage = cartItemControl.NavigateToCheckoutPage();

            // Test if the form has changed
            Assert.AreEqual(totalPrice, checkoutPage.TotalPriceCheckout());

        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
