using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace PageObject.PageObject
{
    class MainPage
    {
        private readonly IWebDriver driver;

        public IWebElement countryInput => GetElement("//*[@id='40-11']");
        public IWebElement cityInput => GetElement("//*[@id='1475-PARISPU']");
        public IWebElement placeInput => GetElement("//*[@id='2091']");
        public IWebElement ageCheckBox => GetElement("//*[@for='chk-age']");
        public IWebElement submitBtn => GetElement("//*[@name='btn-submit']");
        public string errorMessage => GetText("//*[@class='ui-warn-flag-title']");

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetText(string xPath)
        {
            WaitForElementToAppear(driver, 15, By.XPath(xPath));

            return driver.FindElement(By.XPath(xPath)).Text;
        }

        public static IWebElement WaitForElementToAppear(IWebDriver driver, int waitTime, By waitingElement)
        {
            IWebElement wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime)).Until(ExpectedConditions.ElementExists(waitingElement));
            return wait;
        }

        public IWebElement GetElement(string xPath)
        {
            WaitForElementToAppear(driver, 15, By.XPath(xPath));

            return driver.FindElement(By.XPath(xPath));
        }

    }
}
