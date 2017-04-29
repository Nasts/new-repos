using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests.test
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData dataContact = app.Contacts.DataContact();
            ContactData newDataContact = app.Contacts.NewDataContact();

            if (!app.Contacts.ContactExistCheck())
            {
                app.Contacts.CreateContact(dataContact);
            }

               app.Contacts.ContactModify(1, newDataContact);

        }

    }
}
