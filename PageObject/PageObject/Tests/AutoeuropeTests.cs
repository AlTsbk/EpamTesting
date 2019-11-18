using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObject.PageObject;

namespace PageObject.Tests
{
    [TestFixture]
    class AutoeuropeTests
    {
        private IWebDriver driver;

        [SetUp]
        public void StartBrowserChrome()
        {
            driver = new ChromeDriver
            {
                Url = "https://www.autoeurope.ru/"
            };
        }

        [Test]
        public void CheckAge()
        {
            var mainPage = new MainPage(driver);

            mainPage.countryInput.Click();
            mainPage.cityInput.Click();
            mainPage.placeInput.Click();
            mainPage.ageCheckBox.Click();
            mainPage.submitBtn.Click();
            Assert.AreEqual(mainPage.errorMessage, "Пожалуйста, укажите возраст водителя.");
        }

        [Test]
        public void rentWithoutPlace()
        {
            var mainPage = new MainPage(driver);

            mainPage.countryInput.Click();
            mainPage.cityInput.Click();
            mainPage.submitBtn.Click();
            Assert.AreEqual(mainPage.errorMessage, "НЕ ОСТАВЛЯЙТЕ ПОЛЯ ДЛЯ ЗАПОЛНЕНИЯ ПУСТЫМИ");
        }

        [TearDown]
        public void QuitDriver()
        {
            driver.Quit();
        }
    }
}
