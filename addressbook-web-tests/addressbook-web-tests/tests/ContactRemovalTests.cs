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
            ContactData dataContact = app.Contacts.DataContact();
          
            if (app.Contacts.ContactExistCheck())
            {
                app.Contacts.RemoveContact(1, dataContact);
            }
            else
            {
                app.Contacts.CreateContact(dataContact);
                app.Contacts.RemoveContact(1, dataContact);

            }

        }

        
    }
}
