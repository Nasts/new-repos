using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using System.Xml;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;

namespace WebAddressBookTests
{
    [TestFixture]
    public class WebAddressBookTests : TestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 3; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Middlename = (GenerateRandomString(30)),
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromCsvFile()
        {
            List<ContactData> groups = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contacts.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new ContactData(parts[0],parts[1])
                {
                    Middlename = parts[2]
                });
            }
            return groups;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {

            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>))
                 .Deserialize(new StreamReader(@"contacts.xml"));

        }

        public static IEnumerable<ContactData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json"));
        }



        [Test, TestCaseSource("ContactDataFromXmlFile")]
        public void AddNewContactTest(ContactData contact)
        {
            //ContactData contact = new ContactData("Nast", "Pambukyan");
            //contact.Middlename = "pum";
            //contact.Lastname = ;

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.CreateContact(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }

    }
}
