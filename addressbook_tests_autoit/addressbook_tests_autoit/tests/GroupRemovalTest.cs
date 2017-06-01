using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using NUnit.Framework;


namespace addressbook_tests_autoit.tests
{
    [TestFixture]
    public class GroupRemovalTest : TestBase
    {
        [Test]
        public void TestGroupRemoval()
        {

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(oldGroups);

            List<GroupData> newGroups = app.Groups.GetGroupList();

          NUnit.Framework.Assert.AreEqual(oldGroups.Count - 1, newGroups.Count);

        }
        

    }
}
