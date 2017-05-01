using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class WebAddressBookTests : TestBase
    {

        [Test]
        public void AddNewContactTest()
        {
            ContactData contact = new ContactData("Nast", "Pambukyan");
            contact.Middlename = "pum";
            //contact.Lastname = ;

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.CreateContact(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);


        }

    }
}
