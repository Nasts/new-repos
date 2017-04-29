using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests.tests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {

            GroupData data = app.Groups.DataGroup();
            GroupData newData = app.Groups.NewDataGroup();

          
            if (!app.Groups.GroupExistCheck())
            {
                app.Groups.Create(data);
            }
              app.Groups.Modify(1, newData);
        }
    }
}