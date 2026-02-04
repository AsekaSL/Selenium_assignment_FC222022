using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assigment_02.Pages
{
    public class LandingPage
    {
        private ChromeDriver _driver;
        private IWebElement txtInput => _driver.FindElement(By.CssSelector("a[href='/textinput']"));

        private IWebElement txtSampleApp => _driver.FindElement(By.CssSelector("a[href='/sampleapp']"));

        private IWebElement txtClientSdDly => _driver.FindElement(By.CssSelector("a[href='/clientdelay']"));

        private IWebElement txtAlerts => _driver.FindElement(By.CssSelector("a[href='/alerts']"));

        public LandingPage(ChromeDriver _driver)
        {
            this._driver = _driver;
        }

        public TextInputPage ClickOnTextInput()
        {
            txtInput.Click();
            return new TextInputPage(_driver);
        }

        public SampleAppPage ClickOnSampleApp()
        {
            txtSampleApp.Click();
            return new SampleAppPage(_driver);
        }

        public ClientSideDelayPage ClickOnClientSdDly()
        {
            txtClientSdDly.Click();
            return new ClientSideDelayPage(_driver);
        }

        public AlertsPage ClickTxtAleart()
        {
            txtAlerts.Click();
            return new AlertsPage(_driver);
        }

    }
}
