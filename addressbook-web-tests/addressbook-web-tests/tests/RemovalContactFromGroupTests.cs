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


            if (app.Groups.GroupExistCheck())
            {
                GroupData group = GroupData.GetAll()[0];

                List<ContactData> oldList = group.GetContacts();
                if (oldList.Count != 0)
                {

                    ContactData contact = oldList.First();
                    app.Contacts.DeleteContactFromGroup(contact, group);
                    List<ContactData> newList = group.GetContacts();
                    Assert.AreEqual(oldList.Count - 1, newList.Count);
                }
                else
                {
                    System.Console.Out.Write("The group is null");
                }
            }
            else
            {
                System.Console.Out.Write("No groups in addressbook");
            }
            
        }
    }
}
