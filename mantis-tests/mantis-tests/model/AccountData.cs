using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace mantis_tests
{
    public class AccountData
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}