using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    public class ContactTestBase : AuthTestBase
    {

        [TearDown] //после каждого тестового метода
        public void CompareGroupUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                
                List<ContactData> fromUI = app.Contacts.GetContactList();
                List<ContactData> fromDB = ContactData.GetAll();
                fromUI.Sort();
                fromDB.Sort();
                Assert.AreEqual(fromUI, fromDB);


            }

        }

    }
}
