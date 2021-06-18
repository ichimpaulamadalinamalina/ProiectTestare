/**************************************************************************
 *                                                                        *
 *  File:        GiveOffertTest.cs                                        *
 *  Copyright:   (c) 2021, Ichim Paula-Mădălina                           *
 *  Description:  Automation Test used to test if in the Candy Bar        *
 *     section exists a "Cere oferta" button for each type of Candy Bar   *
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
using UnitTestProject1.PageObjects.CandyPage;
using UnitTestProject1.PageObjects.HomePage;
using UnitTestProject1.PageObjects.ShopPage;

namespace UnitTestProject1
{
    [TestClass]
    public class GiveOfferTest
    {
        private IWebDriver driver;
        private HomePage homePage;
        private CandyBarPage candybarPage;

        [TestInitialize]
        public void TestInit()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://cuptorulmoldovencei.ro/");
            homePage = new HomePage(driver);
            var menuItemControl = homePage.homeItemControl;
            candybarPage = menuItemControl.NavigateToOffertPage();
        }


        [TestMethod]
        public void ExistButtonOffer_For_CandyBarPoveste()
        {
            // Check if the "Cere oferta" button exists for "Candy Bar de Poveste"
            Assert.IsNotNull(candybarPage.BtnPovesteOffer);
        }
        [TestMethod]
        public void ExistButtonOffer_For_CandyBarMic()
        {
            // Check if the "Cere oferta" button exists for "Candy Bar Mic"
            Assert.IsNotNull(candybarPage.BtnMicOffer);
        }

        [TestMethod]
        public void ExistButtonOffer_For_CandyBarTraditional()
        {
            // Check if the "Cere oferta" button exists for "Candy Bar Traditional"
            Assert.IsNotNull(candybarPage.BtnTraditionalOffer); 
        }

        

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
