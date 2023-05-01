using OpenQA.Selenium;
using SeleniumWebDriverBasics.WebObjects.Base;

namespace SeleniumWebDriverBasics.WebObjects.Pages
{
    public class HomePage : BasePage
    {
        private static readonly By mailLinkXpath = By.XPath("(//a[@href='https://mail.yandex.com/']/a)[2]");

        public HomePage() : base(mailLinkXpath, "Home Page") { }

        private readonly BaseElement loginButton = new BaseElement(By.XPath("//a[@class='Button2 Button2_type_link Button2_view_default Button2_size_m']"));
        private readonly BaseElement composeLink = new BaseElement(By.XPath("//a[@href='#compose']"));

        public void ClickOnLoginButton()
        {
            loginButton.Click();
        }

        public void WaitForComposeLinkIsVisible()
        {
            composeLink.WaitForIsVisible();
            composeLink.HighlightElement();
        }

        public string GetTextFromComposeLink() => composeLink.GetText();

        public void ClickOnComposeLink()
        {
            composeLink.Click();
        }
    }
}