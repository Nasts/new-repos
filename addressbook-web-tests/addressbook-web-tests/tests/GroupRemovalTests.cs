using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            GroupData data = app.Groups.DataGroup();
            
            if (!app.Groups.GroupExistCheck())
            {
                app.Groups.Create(data);
            }
          
                app.Groups.Remove(1, data);
     

        }

        
    }

}
    
