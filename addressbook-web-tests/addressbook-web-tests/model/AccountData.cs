using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    public class AccountData
    {
        private string username; //значения
        private string password;

        //конструктор для быстрого конструирования, в одну строку
        public AccountData(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        //свойства значений
        public string Username
        {
            //менять значения свойств
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

    }
}
