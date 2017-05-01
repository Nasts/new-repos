using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            ContactData dataContact = app.Contacts.NewDataContact();
          
            if (!app.Contacts.ContactExistCheck())
            {
                app.Contacts.CreateContact(dataContact);
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.RemoveContact(0, dataContact);

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newContacts);
        }

        
    }
}
