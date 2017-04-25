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
            ContactData newDataContact = app.Contacts.NewDataContact();

            if (app.Contacts.ContactExistCheck())
            {
                app.Contacts.RemoveContact(1, newDataContact);
            }
            else
            {
                app.Contacts.CreateContact(newDataContact);
            }

        }

        
    }
}
