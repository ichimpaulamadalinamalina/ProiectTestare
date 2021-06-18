/**************************************************************************
 *                                                                        *
 *  File:        ChangeQuantityProductTest.cs                             *
 *  Copyright:   (c) 2021, Ichim Paula-Mădălina                           *
 *  Description:  Automation Test used to test if in the Cart             *
 *     section we can change the quantity of a product                    *                    *
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.PageObjects.CartPage;
using UnitTestProject1.PageObjects.HomePage;
using UnitTestProject1.PageObjects.ShopPage;
using UnitTestProject1.Utils;

namespace UnitTestProject1
{
    [TestClass]
    public class ChangeQuantityProductTest
    {
        private IWebDriver driver;
        private HomePage homePage;
        private ShopPage shopPage;
        private CartPage cartPage;
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
        public void Product_Should_Have_Quantity_Update()
        {
            // Check if the cart is empty
            Assert.AreEqual("0", shopPage.BasketCounter().GetAttribute("data-counter"));
            //Add a product(in this case Smetanic cookie)
            shopPage.AddProductSmetanic();
            //Press button for Cart
            shopPage.PressCart();
            var menuItemControl = homePage.homeItemControl;
            //Go to "Vezi cos" to see the cart page
            cartPage = menuItemControl.NavigateToCartPage();
            //Change the quantity to 4
            cartPage.BasketCounterChange();
            //Check if the quantity has changed to 4
            Assert.AreEqual("4", cartPage.TextQuantity.GetAttribute("value"));
            cartPage.WaitForPriceCartToChangeTo("36,00 lei");
            //Check if the price of cart has changed because quantity has changed
            Assert.AreEqual("36,00 lei", cartPage.TextPrice.GetAttribute("innerText"));


        }
        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
