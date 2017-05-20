﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests.tests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {

            GroupData newData = new GroupData("ddd");
            newData.Header = null;
            newData.Footer = null;

            if (!app.Groups.GroupExistCheck())
            {
                app.Groups.Create(newData);
            }

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];

            app.Groups.Modify(oldData, newData);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());


            List<GroupData> newGroups = GroupData.GetAll();
            oldData.Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}