using Assigment_02.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assigment_02.Tests
{
    [TestFixture]
    internal class TC002_SampleAppTests : BaseSetup
    {
        [SetUp]
        public void TestSetup()
        {
            // landing to Sample App page
            sampleAppPage = landingPage.ClickOnSampleApp();
            Thread.Sleep(5000);
        }

        [TestCase(TestName = "TC002_1 - Sample App - Verification of the sample app page")]
        public void VerificationSampleAppPage()
        {
            
            // Verification of the page
            var elementVisibility = sampleAppPage.GetElementVisibilityStatus();
            var IsAllElementsVisible = elementVisibility.All(kv => kv.Value == true);
            var isNotVisibleElements = elementVisibility.FirstOrDefault(kv => kv.Value == false).Key;

            Assert.That(IsAllElementsVisible, Is.True, $"The element '{isNotVisibleElements}' is not visible on the page.");

        }

        [TestCase("username","pwd","Welcome, username!" ,TestName = "TC002_2 - Sample App - Verification of a successful login")]
        [TestCase("username", "wrongpwd", "Invalid username/password", TestName = "TC002_3 - Sample App - Verification of an unsuccessful login")]
        public void VerificationSuccessfulLogin(string username, string password,string expectedMessage)
        {
            // Enter valid credentials and login
            sampleAppPage.EnterCredentialsAndLogin(username, password);
            Thread.Sleep(3000);

            // Verify successful login by checking for a welcome message or user-specific element
            string loginStatus = sampleAppPage.getLoginStatus();

            Assert.That(loginStatus, Is.EqualTo(expectedMessage));

        }

    }
}
