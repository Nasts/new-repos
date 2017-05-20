using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            ContactData dataContact = app.Contacts.NewDataContact();

            if (!app.Contacts.ContactExistCheck())
            {
                app.Contacts.CreateContact(dataContact);
            }

            List<ContactData> oldContacts = ContactData.GetAll();
            //запоминаем объект
            ContactData contactToBeRemoved = oldContacts[0];

            app.Contacts.RemoveContact(contactToBeRemoved);

            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts.RemoveAt(0);
            //??
            Assert.AreEqual(oldContacts.Count+1, newContacts.Count);
        }


    }
}