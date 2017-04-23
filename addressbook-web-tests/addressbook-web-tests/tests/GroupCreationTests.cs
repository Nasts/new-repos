using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {

        [Test]
        public void GroupCreationTest()
        {

            GroupData group = new GroupData("nast");
            group.Header = "nast";
            group.Footer = "nast";
            app.Groups.Create(group);
            //driver.FindElement(By.LinkText("Logout")).Click();
        }

        [Test]
        public void EmptyGroupCreationTest()
        {

            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            app.Groups.Create(group);
            //driver.FindElement(By.LinkText("Logout")).Click();
        }

    }
}
