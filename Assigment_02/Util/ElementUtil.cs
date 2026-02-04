using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assigment_02.Util
{
    internal class ElementUtil
    {
        public static bool IsElementPresent(IWebElement element)
        {
            try
            {
                return element != null && element.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
