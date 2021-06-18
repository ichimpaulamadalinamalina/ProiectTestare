/**************************************************************************
 *                                                                        *
 *  File:        VisibleLinksTest.cs                                      *
 *  Copyright:   (c) 2021, BatalanVlad                                    *
 *  Description: Automation Test used to test if new links appear when    *
 *                    ShowMore button is pressed on the Blog page.        *
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
using UnitTestProject1.PageObjects.BlogPage;
using UnitTestProject1.PageObjects.HomePage;
using UnitTestProject1.Utils;

namespace UnitTestProject1
{
    [TestClass]
    public class VisibleLinksTest
    {
        private IWebDriver driver;
        private HomePage homePage;
        private BlogulMoldovenceiPage blogPage;

        [TestInitialize]
        public void TestInit()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://cuptorulmoldovencei.ro/");
            homePage = new HomePage(driver);
            var menuItemControl = homePage.homeItemControl;
            blogPage = menuItemControl.NavigateToBlogPage();
        }

        [TestMethod]
        public void Links_Should_Be_Visible_After_Button_Click()
        {
            // Initially there are only 3 items
            Assert.AreEqual(3, blogPage.GetNumberOfVisibleLinks());

            // Press show items
            blogPage.PressShowMore();

            // Now, there should be 6 items
            Assert.AreEqual(6, blogPage.GetNumberOfVisibleLinks());

            // Press show items
            blogPage.PressShowMore();

            // Now, there should be 8 items
            Assert.AreEqual(8, blogPage.GetNumberOfVisibleLinks());

        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
