using Assigment_02.Util;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assigment_02.Pages
{
    public class AlertsPage
    {
        private ChromeDriver _driver;

        private IWebElement BtnAlert => _driver.FindElement(By.CssSelector("button[id='alertButton']"));

        private IWebElement BtnConfirm => _driver.FindElement(By.Id("confirmButton"));

        private IWebElement BtnPrompt => _driver.FindElement(By.Id("promptButton"));

        private IAlert alert => _driver.SwitchTo().Alert();

        public AlertsPage(ChromeDriver _driver)
        {
            this._driver = _driver;
        }

        public void ClickAlertButton()
        {
            BtnAlert.Click();
        }

        public void ClickAlertAccept()
        {
            alert.Accept();

        }

        public void ClickConfirmButton()
        {
            BtnConfirm.Click();
        }

        public void DeclineAlert()
        {
            alert.Dismiss();
        }

        public void ClickPromptButton()
        {
            BtnPrompt.Click();
        }

        public void EnterTextInPromptAlert(string text)
        {
            alert.SendKeys(text);
        }


        public string getAlertText()
        {
            return alert.Text;
        }

        public bool IsAlertPresent()
        {
            try
            {
                _driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        public Dictionary<string, bool> GetElementVisibilityStatus()
        {
            var status = new Dictionary<string, bool>();

            status["ButtonAlert"] = ElementUtil.IsElementPresent(BtnAlert);
            status["ButtonConfirm"] = ElementUtil.IsElementPresent(BtnConfirm);
            status["ButtonPromote"] = ElementUtil.IsElementPresent(BtnPrompt);

            return status;
        }

        public Dictionary<string, bool> GetAlertVisibleStatus()
        {
            var status = new Dictionary<string, bool>();

            status["Alert"] = AlertUtil.IsAlertPresent(alert);
            
            return status;
        }

    }
}
