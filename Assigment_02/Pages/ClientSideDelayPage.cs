using Assigment_02.Util;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assigment_02.Pages
{
    public class ClientSideDelayPage
    {
        private ChromeDriver _driver;

        private IWebElement BtnTrigger => _driver.FindElement(By.Id("ajaxButton"));

        private IWebElement TxtDelayedElement => _driver.FindElement(By.Id("spinner"));

        private IWebElement paraElement => _driver.FindElement(By.CssSelector("p[class='bg-success']"));



        public ClientSideDelayPage(ChromeDriver _driver)
        {
            this._driver = _driver;
        }

        public void ClickTriggerButton()
        {
            BtnTrigger.Click();
        }

        public string GetParagraphText()
        {
            return paraElement.Text;
        }

        public Dictionary<string, bool> GetElementVisibilityStatus()
        {
            var status = new Dictionary<string, bool>();

            status["TriggerButton"] = ElementUtil.IsElementPresent(BtnTrigger);

            return status;
        }

        public Dictionary<string, bool> GetDelayedElementVisibilityStatus()
        {
            var status = new Dictionary<string, bool>();
            status["DelayedElement"] = ElementUtil.IsElementPresent(TxtDelayedElement);
            return status;
        }

    }
}
