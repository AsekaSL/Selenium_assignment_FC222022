using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assigment_02.Util
{
    internal class AlertUtil
    {

        public static bool IsAlertPresent(IAlert alert)
        {
            try
            {
                return alert != null && !string.IsNullOrEmpty(alert.Text);
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
