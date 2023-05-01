using SeleniumWebDriverBasics.Entities;
using SeleniumWebDriverBasics.WebDriver;
using SeleniumWebDriverBasics.WebObjects.Pages;
using SeleniumWebDriverBasics.Utilities;
using NUnit.Framework.Interfaces;


[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace SeleniumWebDriverBasics.Tests.Base
{
    public abstract class BaseTest
    {
        private readonly HomePage homePage = new HomePage();
        private readonly LoginPage loginPage = new LoginPage();
        private readonly EmailPage emailPage = new EmailPage();

        protected Utilities.Logs.Logger Log;
        private readonly string directory;

        public BaseTest()
        {
            this.Log = Utilities.Logs.LoggerManager.GetLogger(this.GetType());
            this.directory = Path.Combine(Environment.CurrentDirectory, "TestReport");
        }

        [SetUp]
        public void TestSetup()
        {
            Browser.GetInstance();
            Browser.NavigateTo();
            Browser.MaximizeWindow();

            var login = Convert.ToString(Configuration.Login);
            var password = Convert.ToString(Configuration.Password);
            var user = new User(login, password);

            this.Log.Info("Open login page");
            homePage.ClickOnLoginButton();

            this.Log.Info("Login to Yandex");
            loginPage.Login(user);

            this.Log.Info("Wait for successful login");
            homePage.WaitForComposeLinkIsVisible();
        }

        [TearDown]
        public virtual void CleanUp()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                this.Log.Error(
                    "Test failed. Screenshot saved at: "
                    + ScreenshotTaker.TakeScreenshot(this.directory, TestContext.CurrentContext.Test.Name));
            }

            Browser.Driver.Close();
            Browser.Driver.Quit();
            Browser.Quit();
        }
    }
}