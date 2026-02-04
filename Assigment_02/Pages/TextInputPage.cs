using Assigment_02.Util;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assigment_02.Pages
{
    public class TextInputPage
    {
        private ChromeDriver _driver;

        private IWebElement TxtBox => _driver.FindElement(By.Id("newButtonName"));

        private IWebElement UpdateButton => _driver.FindElement(By.Id("updatingButton"));

        public TextInputPage(ChromeDriver _driver)
        {
            this._driver = _driver;
        }

        public void EnterTextInTextBox(string text)
        {
            TxtBox.Clear();
            TxtBox.SendKeys(text);
        }

        public void ClickUpdateButton()
        {
            UpdateButton.Click();
        }

        public void EnterTextAndClickUpdate(string text)
        {
            EnterTextInTextBox(text);
            ClickUpdateButton();
        }

        public string getUpdateButtonText()
        {
            return UpdateButton.Text;
        }

        public Dictionary<string, bool> GetElementVisibilityStatus()
        {
            var status  = new Dictionary<string, bool>();

            status["TextBox"] = ElementUtil.IsElementPresent(TxtBox);
            status["UpdateButton"] = ElementUtil.IsElementPresent(UpdateButton);

            return status;
        }

    }
}
