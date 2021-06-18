/**************************************************************************
 *                                                                        *
 *  File:        ShowMoreTest.cs                                          *
 *  Copyright:   (c) 2021, Stefan Constantin Mihai Cristian               *
 *  Description: Automation Test used to check if the Show Button can be  *
 *                  pressed 4 times before dissapearing.                  *
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
    public class ShowMoreTest
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
        public void Show_More_Button_Is_Clickable_Only_3_Times()
        {
            int counter = 0;
            while (blogPage.ShowMoreButtonExists())
            {
                blogPage.PressShowMore();
                System.Threading.Thread.Sleep(2000);
                counter++;
            }
            // The show more button is clickable only 3 times
            Assert.AreEqual(3, counter);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}

