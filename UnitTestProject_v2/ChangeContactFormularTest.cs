/**************************************************************************
 *                                                                        *
 *  File:        ChangeContactFormularText.cs                             *
 *  Copyright:   (c) 2021, BatalanVlad                                    *
 *  Description: Automation Test used to test if the text from the        *
 *                Contact form is changed when Furnizor button is pressed *
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
using UnitTestProject1.PageObjects.ContactPage;
using UnitTestProject1.PageObjects.HomePage;
using UnitTestProject1.Utils;

namespace UnitTestProject1
{
    [TestClass]
    public class ChangeContactFormularTest
    {
        private IWebDriver driver;
        private HomePage homePage;
        private ContactPage contactPage;

        [TestInitialize]
        public void TestInit()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://cuptorulmoldovencei.ro/");
            homePage = new HomePage(driver);
            var menuItemControl = homePage.homeItemControl;
            contactPage = menuItemControl.NavigateToContactPage();
        }

        [TestMethod]
        public void Form_Text_Should_Change_On_Furnizor_Button_Click()
        {
            // Check if the Client text is visible
            Assert.AreEqual("Cu ce te putem ajuta?", contactPage.GetClientStringIfVisible());

            // Click on Furnizor button
            contactPage.FurnizorButtonClick();

            // Check if the Furnizor text is visible
            Assert.AreEqual("Cum putem colabora?", contactPage.GetColabStringIfVisible());
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
