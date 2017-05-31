using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    public class RemovalContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemovalContactFromGroup()
        {
            ContactData dataContact = app.Contacts.NewDataContact();
            GroupData group = GroupData.GetAll()[0];

            if (group.GetContacts().Count == 0)
            {
                app.Contacts.CreateContact(dataContact);
                ContactData newcontact = ContactData.GetAll().First();
                app.Contacts.AddContactToGroup(newcontact, group);
            }
            List<ContactData> oldList = group.GetContacts();

                ContactData contact = oldList.First();
                app.Contacts.DeleteContactFromGroup(contact, group);

            //   List<ContactData> oldList = group.GetContacts();

             List<ContactData> newList = group.GetContacts();
            Assert.AreEqual(oldList.Count - 1, newList.Count);
        }
     }
}
    