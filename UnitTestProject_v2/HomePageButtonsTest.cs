/**************************************************************************
 *                                                                        *
 *  File:        HomePageButtonsTest.cs                                   *
 *  Copyright:   (c) 2021, Stefan Constantin Mihai Cristian               *
 *  Description: Automation Test used to check if all the buttons on the  *
 *                  menu exist                                            *
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
    public class HomePageButtonsTest
    {
        private IWebDriver driver;
        private HomePage homePage;
        [TestInitialize]
        public void TestInit()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://cuptorulmoldovencei.ro/");
            homePage = new HomePage(driver);
            var menuItemControl = homePage.homeItemControl;
        }
        [TestMethod]
        public void Discover_Button_Should_Link_To_Shop_Page()
        {
            homePage.PressDiscover();
            Assert.AreEqual(driver.Url, "https://cuptorulmoldovencei.ro/shop-online/");
        }
        [TestMethod]
        public void See_More_Button_Should_Link_To_Candy_Bar_Page()
        {
            homePage.PressSeeMore();
            Assert.AreEqual(driver.Url, "https://cuptorulmoldovencei.ro/candy-bar/");
        }
        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
