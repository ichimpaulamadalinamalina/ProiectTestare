using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UnitTestProject1.Utils
{
    public class WaitHelpers
    {
        public static void WaitForElementToBeVisibleCustom(IWebDriver driver,By by,int timeSpan=20)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSpan));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }
        public static void WaitForElementToBeVisible(IWebDriver driver,By by)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(webDriver => webDriver.FindElement(by).Displayed && webDriver.FindElement(by).Enabled);
        }
        public static void WaitForElementToBeSelected(IWebDriver driver, By by)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }
    }
}
