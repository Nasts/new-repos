using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests.test
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
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

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData contactToBeDiffer = oldContacts[0];

            app.Contacts.ContactModify(contactToBeDiffer, newDataContact);

            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts[0].Lastname = newDataContact.Lastname;
            oldContacts[1].Firstname = newDataContact.Firstname;

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

        }

    }
}