using Assigment_02.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assigment_02.Interfaces
{
    public class BaseSetup
    {
        
        // Page Objects
        private ChromeWebPage chromeWebPage;
        protected LandingPage landingPage;
        protected TextInputPage textInputPage;
        protected SampleAppPage sampleAppPage;
        protected ClientSideDelayPage clientSideDelayPage;
        protected AlertsPage alertsPage;


        // Chrome driver
        protected ChromeDriver _driver;
        private static string BaseUrl = "https://uitestingplayground.com/";

        

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(BaseUrl);
            


            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            chromeWebPage = new ChromeWebPage(_driver);

            


            if (chromeWebPage.CheckPageSecure())
            {
                // Check the web page right direct
                chromeWebPage.ClickAdvancedButton();
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                chromeWebPage.ClickLinkProceed();
            }
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            landingPage = new LandingPage(_driver);

        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
            _driver.Quit();
        }
    }
}
