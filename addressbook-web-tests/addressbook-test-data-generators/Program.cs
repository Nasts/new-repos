using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using System.Xml.Serialization;
using WebAddressBookTests;

namespace addressbook_test_data_generators
{
    class Program
    {

        static void Main(string[] args)
        {
            // количество тестовых данных
            int count = Convert.ToInt32(args[0]);
            //файл
            StreamWriter writer = new StreamWriter(args[1]);
            //формат
            string format = args[2];
            // тип данных
            string datatype = args[3];

            //<<dz
            if (datatype == "group")
            {
                //>>

            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(100),
                    Footer = TestBase.GenerateRandomString(100)
                });
            }

            if (format == "csv")
            {
                writeGroupsToCsvFile(groups, writer);
            }
            else if (format == "xml")
            {
                writeGroupsToXmlFile(groups, writer);
            }
            else if (format == "json")
            {
                writeGroupsToJsonFile(groups, writer);
            }

            else
            {
                System.Console.Out.Write("Unrecognized format " + format);
            }

            writer.Close();
            //<<dz
            }
            //>>dz
            if (datatype == "contact")
            {
                List<ContactData> contacts = new List<ContactData>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
                    {
                        Middlename = TestBase.GenerateRandomString(10)
                    });
                }

                if (format == "csv")
                {
                    writeContactsToCsvFile(contacts, writer);
                }
                else if (format == "xml")
                {
                    writeContactsToXmlFile(contacts, writer);
                }
                else if (format == "json")
                {
                    writeContactsToJsonFile(contacts, writer);
                }

                else
                {
                    System.Console.Out.Write("Unrecognized format " + format);
                }

                writer.Close();

            }

        }

        //<<dz реализация контакты
         static void writeContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(string.Format("${0},${1},${2}",
                    contact.Lastname, contact.Firstname, contact.Middlename));
            }
        }

         static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

         static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
        //>>dz

        //реализация группы
        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
            {
                foreach (GroupData group in groups)
                {
                    writer.WriteLine(string.Format("${0},${1},${2}",
                        group.Name, group.Header, group.Footer));
                }
            }

            static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
            {
                new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
            }

            static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
            {
                writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
            }

    }
}
