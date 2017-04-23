using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests.test
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData NewDataContact = new ContactData("Kate");
            NewDataContact.Middlename = "kits";
            NewDataContact.Lastname = "Pambukyan";
            app.Contacts.ContactModify(1, NewDataContact);
        }

    }
}
