using Assigment_02.Util;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assigment_02.Pages
{
    public class SampleAppPage
    {
        private ChromeDriver _driver;

        private IWebElement txtInputUserName => _driver.FindElement(By.CssSelector("input[name='UserName']"));

        private IWebElement TxtPassword => _driver.FindElement(By.CssSelector("input[name='Password']"));

        private IWebElement BtnLogin => _driver.FindElement(By.Id("login"));

        private IWebElement txtLoginStatus => _driver.FindElement(By.Id("loginstatus"));

        public SampleAppPage(ChromeDriver _driver)
        {
            this._driver = _driver;
        }

        public string getUserName()
        {
            return txtInputUserName.Text;
        }

        public void EnterUserName(string userName)
        {
            txtInputUserName.Clear();
            txtInputUserName.SendKeys(userName);
        }

        public void EnterPassword(string password)
        {
            TxtPassword.Clear();
            TxtPassword.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            BtnLogin.Click();
        }

        public void EnterCredentialsAndLogin(string userName, string password)
        {
            EnterUserName(userName);
            EnterPassword(password);
            ClickLoginButton();
        }

        public string getLoginStatus()
        {
            return txtLoginStatus.Text;
        }

        public Dictionary<string, bool> GetElementVisibilityStatus()
        {
            var status = new Dictionary<string, bool>();

            status["TextInputUserName"] = ElementUtil.IsElementPresent(txtInputUserName);
            status["TextPassword"] = ElementUtil.IsElementPresent(TxtPassword);
            status["LogninButton"] = ElementUtil.IsElementPresent(BtnLogin);

            return status;
        }

    }
}
