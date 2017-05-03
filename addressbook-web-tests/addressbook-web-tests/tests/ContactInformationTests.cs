using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]

    public class ContactInformationTests : AuthTestBase
    {
        [Test]

        public void TestContactInformation()
        {
            //получить информацию об отдельном контакте
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            //получить данные из формы редактирования
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            //проверки
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Adress, fromForm.Adress);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);

        }

    }
}
