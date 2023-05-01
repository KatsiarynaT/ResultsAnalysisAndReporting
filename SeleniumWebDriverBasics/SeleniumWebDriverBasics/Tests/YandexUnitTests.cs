using NUnit.Framework.Internal;
using SeleniumWebDriverBasics.Tests.Base;
using SeleniumWebDriverBasics.Utilities;
using SeleniumWebDriverBasics.WebObjects.Pages;

namespace SeleniumWebDriverBasics.Tests
{
    [TestFixture]
    public class YandexUnitTests : BaseTest
    {
        private readonly LoginPage loginPage = new LoginPage();
        private readonly EmailPage emailPage = new EmailPage();

        [Test]
        public void GetLoggedInToYandex()
        {
            //Act
            this.Log.Info("Getting actual user name after login");
            var actualAccountName = loginPage.GetAccountName();

            //Assert
            Assert.AreEqual(ExpectedResults.expectedAccountName, actualAccountName);
        }

        [Test]
        public void DraftEmailIsPresentInDraftFolder()
        {
            //Act
            this.Log.Info("Creating email with populated Subject and Body");
            emailPage.CreateEmail("Test Selenium", "Test Selenium from Kate");

            this.Log.Info("Saving email to draft folder");
            emailPage.SaveEmailToDraftFolder();

            this.Log.Info("Getting actual email's subject");
            var actualSubject = emailPage.GetActualSubject();

            //Assert
            Assert.AreEqual(ExpectedResults.expectedSubject, actualSubject);
        }

        [Test]
        public void GetSubjectAddresseeBodyFromDraftEmail()
        {
            //Act
            this.Log.Info("Creating email with populated Subject and Body");
            emailPage.CreateEmail("Test Selenium", "Test Selenium from Kate");

            this.Log.Info("Saving email to draft folder");
            emailPage.SaveEmailToDraftFolder();

            this.Log.Info("Getting actual email's addressee");
            var actualAddressee = emailPage.GetActualAddressee();

            this.Log.Info("Getting actual email's subject");
            var actualSubject = emailPage.GetActualSubject();

            this.Log.Info("Getting actual email's body");
            var actualMessageBody = emailPage.GetActualMessageBody();

            //Assert
            Assert.AreEqual(ExpectedResults.expectedSubject, actualSubject);
            Assert.AreEqual(ExpectedResults.expectedAddressee, actualAddressee);
            Assert.AreEqual(ExpectedResults.expectedMessageBody, actualMessageBody);
        }

        [Test]
        public void SentDraftEmailIsPresentInSentFolder()
        {
            //Act
            this.Log.Info("Creating email with populated Subject and Body");
            emailPage.CreateEmail("Test Selenium", "Test Selenium from Kate");

            this.Log.Info("Saving email to draft folder");
            emailPage.SaveEmailToDraftFolder();

            this.Log.Info("Going to draft folder");
            emailPage.GoToDraftEmails();

            this.Log.Info("Sending draft email");
            emailPage.SendDraftEmail();

            this.Log.Info("Getting actual email's subject");
            var actualSubject = emailPage.GetActualSubject();

            //Assert
            Assert.AreEqual(ExpectedResults.expectedSubject, actualSubject);
        }

        [Test]
        public void SentNewEmailIsPresentInSentFolder()
        {
            //Act
            this.Log.Info("Creating email with populated Subject and Body");
            emailPage.CreateEmail("Test Selenium", "Test Selenium from Kate");

            this.Log.Info("Sending email");
            emailPage.SendCreatedEmail();

            this.Log.Info("Getting actual email's subject");
            var actualSubject = emailPage.GetActualSubject();

            //Assert
            Assert.AreEqual(ExpectedResults.expectedSubject, actualSubject);
        }

        [Test]
        public void SentEmailIsNotPresentInDraftFolder()
        {
            //Act
            this.Log.Info("Creating email with populated Subject and Body");
            emailPage.CreateEmail("Test Selenium", "Test Selenium from Kate");

            this.Log.Info("Sending email");
            emailPage.SendCreatedEmail();

            this.Log.Info("Going to draft folder");
            emailPage.GoToDraftEmails();

            this.Log.Info("Getting info message from draft folder");
            var actualDraftInfoMessage = emailPage.GetActualDraftInfoMessage();

            //Assert
            Assert.AreEqual(ExpectedResults.expectedDraftInfoMessage, actualDraftInfoMessage);
        }

        [Test]
        public void SentEmailIsNotPresentInTrashFolder()
        {
            //Act
            this.Log.Info("Creating email with populated Subject and Body");
            emailPage.CreateEmail("Test Selenium", "Test Selenium from Kate");

            this.Log.Info("Sending email");
            emailPage.SendCreatedEmail();

            this.Log.Info("Going to trash folder");
            emailPage.GoToTrashEmails();

            this.Log.Info("Getting info message from trash folder");
            var actualTrashInfoMessage = emailPage.GetActualTrashInfoMessage();

            //Assert
            Assert.AreEqual(ExpectedResults.expectedTrashInfoMessage, actualTrashInfoMessage);
        }

        [Test]
        public void DeletedEmailIsNotPresentInDrafts()
        {
            //Act
            this.Log.Info("Creating email with populated Subject and Body");
            emailPage.CreateEmail("Test Selenium", "Test Selenium from Kate");

            this.Log.Info("Saving email to draft folder");
            emailPage.SaveEmailToDraftFolder();

            this.Log.Info("Going to draft folder");
            emailPage.GoToDraftEmails();

            this.Log.Info("Deleting emails");
            emailPage.DeleteAllEmails();

            this.Log.Info("Getting info message from draft folder");
            var actualDraftInfoMessage = emailPage.GetActualDraftInfoMessage();

            //Assert
            Assert.AreEqual(ExpectedResults.expectedDraftInfoMessage, actualDraftInfoMessage);
        }

        [Test]
        public void DeletedEmailIsNotPresentInTrash()
        {
            //Act
            this.Log.Info("Creating email with populated Subject and Body");
            emailPage.CreateEmail("Test Selenium", "Test Selenium from Kate");

            this.Log.Info("Saving email to draft folder");
            emailPage.SaveEmailToDraftFolder();

            this.Log.Info("Going to draft folder");
            emailPage.GoToDraftEmails();

            this.Log.Info("Deleting emails");
            emailPage.DeleteAllEmails();

            this.Log.Info("Going to trash folder");
            emailPage.GoToTrashEmails();

            this.Log.Info("Deleting emails");
            emailPage.DeleteAllEmails();

            this.Log.Info("Getting info message from trash folder");
            var actualTrashInfoMessage = emailPage.GetActualTrashInfoMessage();

            //Assert
            Assert.AreEqual(ExpectedResults.expectedTrashInfoMessage, actualTrashInfoMessage);
        }

        [Test]
        public void GetLoggedOutFromYandex()
        {
            //Act
            this.Log.Info("Singing out from Yandex mail");
            emailPage.GoToSignOutForm();

            this.Log.Info("Getting account name");
            var actualTitleAfterLogout = loginPage.GetActualLoginMessage(); ;

            //Assert
            Assert.AreEqual(ExpectedResults.expectedTitleAfterLogout, actualTitleAfterLogout);
        }

        [Test]
        public void GetDeletedEmail()
        {
            //Act
            this.Log.Info("Creating email with populated Subject and Body");
            emailPage.CreateEmail("Test Selenium", "Test Selenium from Kate");

            this.Log.Info("Saving email to draft folder");
            emailPage.SaveEmailToDraftFolder();

            this.Log.Info("Going to draft folder");
            emailPage.GoToDraftEmails();

            this.Log.Info("Moving emails to trash folder");
            emailPage.MoveDraftEmailToTrashFolder();

            this.Log.Info("Going to trash folder");
            emailPage.GoToTrashFolder();

            this.Log.Info("Getting actual email's subject");
            var actualSubject = emailPage.GetActualSubject();

            //Assert
            Assert.AreEqual(ExpectedResults.expectedSubject, actualSubject);
        }
    }
}