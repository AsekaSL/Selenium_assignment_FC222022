using Assigment_02.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assigment_02.Tests
{
    [TestFixture]
    internal class TC003__ClientSideDelayTests : BaseSetup
    {

        [TestCase(TestName = "TC003_1 - Client Side Delay - Verificaiton of the page")]
        public void VerificaitonThePage()
        {
            // landing to Client Side Delay page
            clientSideDelayPage = landingPage.ClickOnClientSdDly();
            Thread.Sleep(5000);

            // Verification of the page
            var elementVisibility = clientSideDelayPage.GetElementVisibilityStatus();
            var IsAllElementsVisible = elementVisibility.All(kv => kv.Value == true);
            var isNotVisibleElements = elementVisibility.FirstOrDefault(kv => kv.Value == false).Key;

            Assert.That(IsAllElementsVisible, Is.True, $"The element '{isNotVisibleElements}' is not visible on the page.");

            // Click the trigger button to initiate sprinner
            clientSideDelayPage.ClickTriggerButton();

            var elementVisibilityAfterClick = clientSideDelayPage.GetDelayedElementVisibilityStatus();
            var IsAllElementsVisibleAfterClick = elementVisibilityAfterClick.All(kv => kv.Value == true);
            var isNotVisibleElementsAfterClick = elementVisibilityAfterClick.FirstOrDefault(kv => kv.Value == false).Key;

            Assert.That(IsAllElementsVisibleAfterClick, Is.True, $"The element '{isNotVisibleElementsAfterClick}' is not visible on the page after clicking the trigger button.");


            // Additional wait to observe the delayed element if necessary
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            string message = clientSideDelayPage.GetParagraphText();

            Assert.That(message, Is.EqualTo("Data calculated on the client side."), "The delayed message is not as expected.");

        }

    }
}
