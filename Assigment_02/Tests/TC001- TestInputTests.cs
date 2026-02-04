using Assigment_02.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Assigment_02.Tests
{
    [TestFixture]
    internal class TC001_TextInputTests : BaseSetup
    {

        [TestCase(TestName = "TC001_1 - Text Input - Verificaiton of the page")]
        public void Test1()
        {
            // landing to TextInput page
            textInputPage = landingPage.ClickOnTextInput();
            Thread.Sleep(5000);

            // Verification of the page
            var elementVisibility = textInputPage.GetElementVisibilityStatus();
            var IsAllElementsVisible = elementVisibility.All(kv => kv.Value == true);
            var isNotVisibleElements = elementVisibility.FirstOrDefault(kv => kv.Value == false).Key;

            Assert.That(IsAllElementsVisible, Is.True, $"The element '{isNotVisibleElements}' is not visible on the page.");


            // Generate a random string and input it into the text box
            string randomString = Guid.NewGuid().ToString();
            textInputPage.EnterTextAndClickUpdate(randomString);

            // Verify that the button text has been updated
            string buttonText = textInputPage.getUpdateButtonText();
            Assert.That(buttonText, Is.EqualTo(randomString), "The button text was not updated correctly.");


        }


    }
}
