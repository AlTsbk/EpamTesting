﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using GitHubAutomation.Models;

namespace GitHubAutomation.Pages
{
    public class MainPage
    {
        IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        public IWebElement ageCheckBox => GetElement("//*[@for='chk-age']");
        public IWebElement submitBtn => GetElement("//*[@name='btn-submit']");
        public IWebElement returnPlaceCheckBox => GetElement("//*[@id='locations-wrapper']/div[1]");
        public string errorMessage => GetText("//*[@class='ui-warn-flag-title']");

        public MainPage FillInPickUpFields(Location location)
        {
            selectItem("//*[@value='" + location.Country + "']");
            selectItem("//*[@id='" + location.City + "']");
            selectItem("//*[@id='" + location.Place + "']");
            return this;
        }

        public void selectItem(string path)
        {
            WaitForElementToAppear(driver, 15, By.XPath(path));
            var element = driver.FindElement(By.XPath(path));
            element.Click();
        }

        public MainPage clickOnAgeCheckBox()
        {
            ageCheckBox.Click();
            return this;
        }

        public MainPage clickOnReturnPlaceCheckBox()
        {
            returnPlaceCheckBox.Click();
            return this;
        }

        public MainPage SubmitInformation()
        {
            submitBtn.Click();
            return this;
        }

        public static IWebElement WaitForElementToAppear(IWebDriver driver, int waitTime, By waitingElement)
        {
            IWebElement wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime)).Until(ExpectedConditions.ElementExists(waitingElement));
            return wait;
        }

        public string GetText(string xPath)
        {
            WaitForElementToAppear(driver, 15, By.XPath(xPath));

            return driver.FindElement(By.XPath(xPath)).Text;
        }

        public IWebElement GetElement(string xPath)
        {
            WaitForElementToAppear(driver, 15, By.XPath(xPath));

            return driver.FindElement(By.XPath(xPath));
        }
    }
}