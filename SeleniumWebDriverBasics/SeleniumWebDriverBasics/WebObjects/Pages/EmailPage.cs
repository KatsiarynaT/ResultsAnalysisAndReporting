﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumWebDriverBasics.WebDriver;
using SeleniumWebDriverBasics.WebObjects.Base;

namespace SeleniumWebDriverBasics.WebObjects.Pages
{
    public class EmailPage : BasePage
    {
        private static readonly By loggedInUser = By.ClassName("user-account__name");

        public EmailPage() : base(loggedInUser, "Email Page") { }

        private readonly BaseElement createEmailButton = new BaseElement(By.XPath("//a[@class='mail-ComposeButton js-main-action-compose']"));
        private readonly BaseElement recepientField = new BaseElement(By.ClassName("composeYabbles"));
        private readonly BaseElement recepientOption = new BaseElement(By.ClassName("ContactsSuggestItemDesktop-Email"));
        private readonly BaseElement subjectField = new BaseElement(By.XPath("//input[@class='composeTextField ComposeSubject-TextField']"));
        private readonly BaseElement bodyField = new BaseElement(By.XPath("//div[contains(@class, 'cke_enable_context_menu')]"));
        private readonly BaseElement draftsOption = new BaseElement(By.XPath("//a[@data-title='Drafts']"));
        private readonly BaseElement draftEmail = new BaseElement(By.XPath("//span[@class='mail-MessageSnippet-FromText']"));
        private readonly BaseElement sentOption = new BaseElement(By.XPath("//a[@data-title='Sent']"));
        private readonly BaseElement sendButton = new BaseElement(By.XPath("(//button[contains(@class, 'ComposeControlPanelButton-Button')])[1]"));
        private readonly BaseElement popupWindow = new BaseElement(By.XPath("//a[@class='control link link_theme_normal ComposeDoneScreen-Link']"));
        private readonly BaseElement userLogo = new BaseElement(By.XPath("(//div/img[@class='user-pic__image'])[1]"));
        private readonly BaseElement logOutOption = new BaseElement(By.XPath("//span[text()='Log out']"));
        private readonly BaseElement deleteButton = new BaseElement(By.XPath("//span[text()='Delete']"));
        private readonly BaseElement deletedOption = new BaseElement(By.XPath("//a[@data-title='Deleted']"));
        private readonly BaseElement allEmailsCheckbox = new BaseElement(By.XPath("(//span[@class='checkbox_view'])[1]"));
        private readonly BaseElement actualUserName = new BaseElement(By.XPath("//a[contains(@class, 'user-account_left-name')]/span[1]"));
        private readonly BaseElement actualAdressee = new BaseElement(By.XPath("(//span[contains(@class, 'mail-MessageSnippet-Item_sender')]/span)[1]"));
        private readonly BaseElement actualSubject = new BaseElement(By.XPath("(//span[contains(@class, 'mail-MessageSnippet-Item_subject')]/span)[1]"));
        private readonly BaseElement actualMessageBody = new BaseElement(By.XPath("(//span[contains(@class, 'mail-MessageSnippet-Item_firstline')]/span)[1]"));
        private readonly BaseElement actualDraftInfoMessage = new BaseElement(By.XPath("//span[text()='No messages in Drafts']"));
        private readonly BaseElement actualTrashInfoMessage = new BaseElement(By.XPath("//span[text()='No messages in Trash']"));

        private By draftEmailForDeletion = By.XPath("//span[@class='mail-MessageSnippet-FromText']");
        private By trashFolder = By.XPath("//a[@data-title='Deleted']");

        public void SwitchToEmailPage()
        {
            var currentTab = Browser.Driver.WindowHandles.Last();
            Browser.Driver.SwitchTo().Window(currentTab);
        }

        public void CreateEmail(string subjectText, string bodyText)
        {
            createEmailButton.Click();
            recepientField.Click();
            recepientOption.Click();
            subjectField.SendKeys(subjectText);
            bodyField.SendKeys(bodyText);
        }

        public void SaveEmailToDraftFolder()
        {
            draftsOption.Click();
        }

        public void SendCreatedEmail()
        {
            sendButton.Click();
            popupWindow.Click();
        }

        public void SendDraftEmail()
        {
            draftEmail.Click();
            sendButton.Click();
            popupWindow.Click();
        }

        public void GoToSentFolder()
        {
            sentOption.Click();
        }

        public void GoToDraftEmails()
        {
            draftsOption.Click();
        }

        public void GoToSignOutForm()
        {
            userLogo.HighlightElement();
            userLogo.Click();
            logOutOption.Click();
        }

        public void GoToTrashEmails()
        {
            deletedOption.Click();
        }

        public void DeleteAllEmails()
        {
            allEmailsCheckbox.Click();
            deleteButton.Click();
        }

        public void MoveDraftEmailToTrashFolder()
        {
            IWebElement draftEmailForMovingToTrashBin = Browser.Driver.FindElement(draftEmailForDeletion);
            IWebElement deletedFolder = Browser.Driver.FindElement(trashFolder);
            new Actions(Browser.Driver).DragAndDrop(draftEmailForMovingToTrashBin, deletedFolder).Build().Perform();
        }

        public void GoToTrashFolder()
        {
            IWebElement deletedFolder = Browser.Driver.FindElement(trashFolder);
            new Actions(Browser.Driver).DoubleClick(deletedFolder).Build().Perform();
        }

        public string GetActualUserName() => actualUserName.GetText();

        public string GetActualAddressee() => actualAdressee.GetText();

        public string GetActualSubject() => actualSubject.GetText();

        public string GetActualMessageBody() => actualMessageBody.GetText();

        public string GetActualDraftInfoMessage() => actualDraftInfoMessage.GetText();

        public string GetActualTrashInfoMessage() => actualTrashInfoMessage.GetText();
    }
}