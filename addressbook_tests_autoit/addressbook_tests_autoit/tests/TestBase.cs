using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    public class TestBase
    {
        public ApplicationManager app;

        [TestFixtureSetUp] //один раз перед всеми методами
         public void InitApplication()
        {
            app = new ApplicationManager();
        }

        //
        [TestFixtureTearDown]
        public void StopApplication()
        {
            app.Stop();
        }

    }
}
