using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    public class GroupTestBase : AuthTestBase
    {

        [TearDown] //после каждого тестового метода
        public void CompareGroupUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                //получаем два списка групп
                List<GroupData> fromUI = app.Groups.GetGroupList();
                List<GroupData> fromDB = GroupData.GetAll();
                fromUI.Sort();
                fromDB.Sort();
                Assert.AreEqual(fromUI, fromDB);


            }

        }

    }
}
