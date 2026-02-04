using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.WebRequestMethods;

namespace Assigment_02.Pages
{
    internal class ChromeWebPage
    {

        private ChromeDriver _driver;

        private IWebElement btnAdvanced => _driver.FindElement(By.Id("details-button"));

        private IWebElement linkProceed => _driver.FindElement(By.Id("proceed-link"));

        public ChromeWebPage(ChromeDriver _driver)
        {
            this._driver = _driver;
        }

        public void ClickAdvancedButton()
        {
            
            btnAdvanced.Click();
            
        }

        public void ClickLinkProceed()
        {
            linkProceed.Click();
        }

        public Boolean CheckPageSecure()
        {
            return btnAdvanced != null;
        }


    }
}
