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
            ContactData newDataContact = new ContactData("Kate");
            newDataContact.Middlename = "kits";
            newDataContact.Lastname = "Pambukyan";
            app.Contacts.ContactModify(1, newDataContact);
        }

    }
}
