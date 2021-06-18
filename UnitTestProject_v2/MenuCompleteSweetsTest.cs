/**************************************************************************
 *                                                                        *
 *  File:        MenuCompleteSweetsTest.cs                                *
 *  Copyright:   (c) 2021, Ichim Paula-Mădălina                           *
 *  Description:  Automation Test used to test if in the Shop             *
 *     section exists 6 category of sweets (verify that the menu is       *
 *                      complete )                                        *
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
using UnitTestProject1.PageObjects.HomePage;
using UnitTestProject1.PageObjects.ShopPage;

namespace UnitTestProject1
{
    [TestClass]
    public class MenuCompleteSweetsTest
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
        public void Menu_Complete()
        {
            // Check if the number of the item from menu sweets is 6
            Assert.AreEqual(6, shopPage.MenuCounter());
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
