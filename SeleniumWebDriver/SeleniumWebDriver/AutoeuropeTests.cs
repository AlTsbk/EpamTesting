using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumWebDriver
{
    [TestFixture]
    class AutoeuropeTests
    {
        private IWebDriver webDriver;

        [SetUp]
        public void StartBrowserChrome()
        {
            webDriver = new ChromeDriver
            {
               Url = "https://www.autoeurope.ru/"
            };
        }

        [Test]
        public void CheckAge()
        {
            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='40-11']"));
            var country = webDriver.FindElement(By.XPath("//*[@id='40-11']"));
            country.Click();

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='1475-PARISPU']"));
            var city = webDriver.FindElement(By.XPath("//*[@id='1475-PARISPU']"));
            city.Click();

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='2091']"));
            var airport = webDriver.FindElement(By.XPath("//*[@id='2091']"));
            airport.Click();

            WaitForElementToAppear(webDriver, 30, By.XPath("//*[@for='chk-age']"));
            var checkBox = webDriver.FindElement(By.XPath("//*[@for='chk-age']"));
            checkBox.Click();

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@name='btn-submit']"));
            var sumbitBtn = webDriver.FindElement(By.XPath("//*[@name='btn-submit']"));
            sumbitBtn.Click();

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@role='contentinfo']/section"));
            var errorMessage = webDriver.FindElement(By.XPath("//*[@role='contentinfo']/section"));
            var isErrorMessageCorrect = errorMessage.Text.Equals("Пожалуйста, укажите возраст водителя.");
            Assert.IsTrue(isErrorMessageCorrect);
        }

        [Test]
        public void rentWithoutPlace()
        {
            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='40-11']"));
            var country = webDriver.FindElement(By.XPath("//*[@id='40-11']"));
            country.Click();

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='1475-PARISPU']"));
            var city = webDriver.FindElement(By.XPath("//*[@id='1475-PARISPU']"));
            city.Click();

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@name='btn-submit']"));
            var sumbitBtn = webDriver.FindElement(By.XPath("//*[@name='btn-submit']"));
            sumbitBtn.Click();

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='ui-id-97']/article/div/header/h5"));
            var errorMessage = webDriver.FindElement(By.XPath("//*[@id='ui-id-97']/article/div/header/h5"));
            var isErrorMessageCorrect = errorMessage.Text.Equals("НЕ ОСТАВЛЯЙТЕ ПОЛЯ ДЛЯ ЗАПОЛНЕНИЯ ПУСТЫМИ");
            Assert.IsTrue(isErrorMessageCorrect);
        }

            public static IWebElement WaitForElementToAppear(IWebDriver driver, int waitTime, By waitingElement)
        {
            IWebElement wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime)).Until(ExpectedConditions.ElementExists(waitingElement));
            return wait;
        }

        [TearDown]
        public void QuitDriver()
        {
            webDriver.Quit();
        }
    }
}