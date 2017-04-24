using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class WebAddressBookTests : TestBase
    {

        [Test]
        public void AddNewContactTest()
        {
            ContactData contact = new ContactData("Nast");
            contact.Middlename = "pum";
            contact.Lastname = "Pambukyan";
            app.Contacts.CreateContact(contact);

        }



    }
}
