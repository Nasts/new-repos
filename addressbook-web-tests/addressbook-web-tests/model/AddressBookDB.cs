using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 using LinqToDB;

namespace WebAddressBookTests
{
    //класс по соединению с бд
    public class AddressBookDB : LinqToDB.Data.DataConnection
    {
        //вызов конструктора базового класса и указание бд
        public AddressBookDB() : base("AddressBook") { }

        //методы
        public ITable<GroupData> Groups { get { return GetTable<GroupData>(); } }

        public ITable<ContactData> Contacts { get { return GetTable<ContactData>(); } }

        //извлекаем из промежуточной
       public ITable<GroupContactRelation> GCR { get { return GetTable<GroupContactRelation>(); } }
    }
}
