using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using GitHubAutomation.Driver;
using GitHubAutomation.Pages;
using GitHubAutomation.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.Extensions;

namespace GitHubAutomation.Tests
{
    [TestFixture]
    public class WebTests : GeneralConfig
    {
        [Test]
        public void CheckAge()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                MainPage mainPage = new MainPage(Driver)
                    .FillInPickUpFields(CreatingOrder.PickUpFields())
                    .clickOnAgeCheckBox()
                    .SubmitInformation();
                
                Assert.AreEqual("ВОЗРАСТ ВОДИТЕЛЯ", mainPage.errorMessage);
            });
        }

        [Test]
        public void RentCarWithEmptyReturnFields()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                MainPage mainPage = new MainPage(Driver)
                    .FillInPickUpFields(CreatingOrder.PickUpFields())
                    .clickOnReturnPlaceCheckBox()
                    .SubmitInformation();

                Assert.AreEqual("НЕ ОСТАВЛЯЙТЕ ПОЛЯ ДЛЯ ЗАПОЛНЕНИЯ ПУСТЫМИ", mainPage.errorMessage);
            });
        }
    }
}