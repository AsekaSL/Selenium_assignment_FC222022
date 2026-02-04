using Assigment_02.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assigment_02.Tests
{
    [TestFixture]
    internal class TC004___AlertsTests : BaseSetup
    {
        [SetUp]
        public void TestSetup()
        {
            // landing to Alerts page
            alertsPage = landingPage.ClickTxtAleart();
        }

        [TestCase(TestName = "TC004_1 - Alerts - Verification of the Alerts page")]
        public void VerificationAlertsPage()
        {
            // Verification of the page
            var elementVisibility = alertsPage.GetElementVisibilityStatus();
            var IsAllElementsVisible = elementVisibility.All(kv => kv.Value == true);
            var isNotVisibleElements = elementVisibility.FirstOrDefault(kv => kv.Value == false).Key;

            Assert.That(IsAllElementsVisible, Is.True, $"The element '{isNotVisibleElements}' is not visible on the page.");
        }

        [TestCase(TestName = "TC004_2 - Alerts - Verification of the Alert text")]
        public void VerificationAlertText()
        {
            // Trigger the alert 
            alertsPage.ClickAlertButton();

            // Verification of the alert
            var alertVisibility = alertsPage.GetAlertVisibleStatus();
            var IsAlertVisible = alertVisibility.All(kv => kv.Value == true);
            var isNotVisibleAlert = alertVisibility.FirstOrDefault(kv => kv.Value == false).Key;

            Assert.That(IsAlertVisible, Is.True, $"The alert '{isNotVisibleAlert}' is not visible on the page.");

            // Verify the alert text
            string alertText = alertsPage.getAlertText();

            Assert.That(alertText, Is.EqualTo("Today is a working day.\r\nOr less likely a holiday."), "The alert text is not as expected.");

            Thread.Sleep(1000);
            // Accept the alert
            alertsPage.ClickAlertAccept();

            // Verify that the alert is no longer present
            Assert.That(alertsPage.IsAlertPresent(), Is.False, "The alert is still present after accepting it.");

        }

        [TestCase(TestName = "TC004_3 - Alerts - Verification of the Alert text depneding on the first alert")]
        public void VerificationAlertTextDepnedingOnFirstAlert()
        {
            // Trigger the confirm alert
            alertsPage.ClickConfirmButton();

            // Verification of the alert
            checkAlertPresent();

            // Trigger the confirm alert with Accept option
            HandleAlertIfPresent("Yes");
            
            alertsPage.ClickConfirmButton();
            // Trigger the confirm alert again with decline option
            HandleAlertIfPresent("No");
        }

        public void checkAlertPresent()
        {
            // Verification of the alert
            var alertVisibility = alertsPage.GetAlertVisibleStatus();
            var IsAlertVisible = alertVisibility.All(kv => kv.Value == true);
            var isNotVisibleAlert = alertVisibility.FirstOrDefault(kv => kv.Value == false).Key;

            Assert.That(IsAlertVisible, Is.True, $"The alert '{isNotVisibleAlert}' is not visible on the page.");
        }

        public void HandleAlertIfPresent(string accepted)
        {
            // Verify the alert text
            string alertText = alertsPage.getAlertText();

            Assert.That(alertText, Is.EqualTo("Today is Friday.\r\nDo you agree?"), "The alert text is not as expected.");

            Thread.Sleep(1000);
            if (accepted == "Yes")
            {
                // Accept the alert
                alertsPage.ClickAlertAccept();
            }else if (accepted == "No")
            {
                // Dismiss the alert
                alertsPage.DeclineAlert();
            }


            // Verify that the alert is no longer present
            Assert.That(alertsPage.IsAlertPresent(), Is.False, "The alert is still present after accepting it.");

            Thread.Sleep(5000);
            // Verification of another the alert
            checkAlertPresent();

            // Verify the alert text
            alertText = alertsPage.getAlertText();

            Assert.That(alertText, Is.EqualTo(accepted), "The alert text is not as expected.");

            Thread.Sleep(1000);
            // Accept the alert
            alertsPage.ClickAlertAccept();

        }

        [TestCase(TestName = "TC004_4 - Alerts - Verification of the Alert prompt")]
        public void VerificationAlertPrompt()
        {
            // Trigger the prompt alert
            alertsPage.ClickPromptButton();
            Thread.Sleep(1000);

            // Verification of the alert
            checkAlertPresent();

            // User add random input in the prompt alert
            string randomInput = Guid.NewGuid().ToString();
            alertsPage.EnterTextInPromptAlert(randomInput);

            // Accept the prompt alert
            alertsPage.ClickAlertAccept();

            Thread.Sleep(5000);

            // Verification of another the alert
            checkAlertPresent();

            // Verify the alert text
            string alertText = alertsPage.getAlertText();

            Assert.That(alertText, Is.EqualTo($"User value: {randomInput}"), "The alert text is not as expected.");
            alertsPage.ClickAlertAccept();

            alertsPage.ClickPromptButton();

            Thread.Sleep(1000);
            // User add random input in the prompt alert
            alertsPage.EnterTextInPromptAlert(randomInput);

            // Dismiss the prompt alert
            alertsPage.DeclineAlert();
            Thread.Sleep(5000);

            // Verification of another the alert
            checkAlertPresent();

            alertText = alertsPage.getAlertText();

            Assert.That(alertText, Is.EqualTo("User value: no answer"), "The alert text is not as expected.");
        }

    }
}
