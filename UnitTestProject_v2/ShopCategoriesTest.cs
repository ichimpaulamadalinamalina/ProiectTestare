/**************************************************************************
 *                                                                        *
 *  File:        ShopCategoriesTest.cs                                    *
 *  Copyright:   (c) 2021, Stefan Constantin Mihai Cristian               *
 *  Description: Automation Test used to check if all the categories      *
 *                     exist on the home page                             *
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
    public class ShopCategoriesTest
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
        public void ExistButtonCategory_Torturi()
        {
            Assert.IsNotNull(shopPage.BtnTorturi);
        }
        [TestMethod]
        public void ExistButtonCategory_Copturi()
        {
            Assert.IsNotNull(shopPage.BtnCopturi);
        }
        [TestMethod]
        public void ExistButtonCategory_Prajituri_La_Bucata()
        {
            Assert.IsNotNull(shopPage.BtnLaBucata);
        }
        [TestMethod]
        public void ExistButtonCategory_Miniprajituri()
        {
            Assert.IsNotNull(shopPage.BtnMini);
        }
        [TestMethod]
        public void ExistButtonCategory_Placinte()
        {
            Assert.IsNotNull(shopPage.BtnPlacinte);
        }
        [TestMethod]
        public void ExistButtonCategory_Produse_De_Sezon()
        {
            Assert.IsNotNull(shopPage.BtnSezon);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}


