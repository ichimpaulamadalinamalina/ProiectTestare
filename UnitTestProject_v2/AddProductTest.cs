/**************************************************************************
 *                                                                        *
 *  File:        AddProductTest.cs                                        *
 *  Copyright:   (c) 2021, Iftime Adrian-Dumitru                          *
 *  Description: Automation Test used to test if the user is able         *
 *               to insert a product into the cart                        *
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
using UnitTestProject1.Controls;
using UnitTestProject1.PageObjects.HomePage;
using UnitTestProject1.PageObjects.ShopPage;
using UnitTestProject1.Utils;

namespace UnitTestProject1
{
    [TestClass]
    public class AddProductTest
    {
        private IWebDriver driver;
        private HomePage homePage;
        private ShopPage shopPage;
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
        public void Product_Should_Be_Removed()
        {
            Assert.AreEqual("0", shopPage.BasketCounter().GetAttribute("data-counter"));
            shopPage.AddProduct();
            Assert.AreEqual("1", shopPage.BasketCounter().GetAttribute("data-counter"));
        }
        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
