using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressBookTests.test
{
    [TestFixture]
    public class AddContactToGroupTests : TestBase
    {
        [Test]
        public void AddContactToGroupTest()
        {
            app.Contacts.AddContactToGroup(1);
        }

    }
}
