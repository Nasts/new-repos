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
            ContactData newDataContact = new ContactData("Nast", "Pambukyan");
            newDataContact.Middlename = "pum";
           

            if (!app.Contacts.ContactExistCheck())
            {
                app.Contacts.CreateContact(newDataContact);
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.ContactModify(0, newDataContact);

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts[0].Lastname = newDataContact.Lastname;
            oldContacts[1].Firstname = newDataContact.Firstname;

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

        }

    }
}
