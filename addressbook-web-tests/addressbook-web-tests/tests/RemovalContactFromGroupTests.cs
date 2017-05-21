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
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
          

            ContactData contact =
                 oldList.First();

            app.Contacts.DeleteContactFromGroup(contact, group);

           List<ContactData> newList = group.GetContacts();
          // oldList.Add(contact);
           //newList.Sort();
           //oldList.Sort();

            Assert.AreEqual(oldList.Count - 1, newList.Count);
        }
    }
}
