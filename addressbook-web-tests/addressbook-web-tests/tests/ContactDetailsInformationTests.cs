using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactDetailsInformationTests : AuthTestBase
    {
        [Test]
        public void TestDetailContactInformation()
        {
            // получить информацию об отдельном контакте
            ContactData fromDetailTable = app.Contacts.GetContactInformationFromDetailTable(0);
            //получить данные из формы редактирования
            ContactData fromEditForm = app.Contacts.GetContactInformationFromEditForm(0);

            //проверки
            Assert.AreEqual(fromDetailTable, fromEditForm);
            Assert.AreEqual(fromDetailTable.AllEmails, fromEditForm.AllEmails);
           // Assert.AreEqual(fromDetailTable.AllPhones, fromEditForm.AllPhones);
           
        }
    }
}
