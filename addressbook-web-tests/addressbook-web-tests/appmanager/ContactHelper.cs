using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager) : base(manager)
        {

        }



        public ContactHelper ContactModify(int v, ContactData newDataContact)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(v);
            InitContactModification();
            FillContactForm(newDataContact);
            SubmitContactModification();
            return this;
        }


        public ContactHelper RemoveContact(int v, ContactData newDataContact)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(v);
            RemoveContact();
            SubmitRemove();
            return this;
        }

        public ContactHelper CreateContact(ContactData contact)
        {
            InitNewContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            return this;
        }

        public bool ContactExistCheck()
        {
            return IsElementPresent(By.Name("selected[]"));
        }

        public void FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);

        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            return this;
        }


        public ContactHelper SubmitRemove()
        {
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
            //driver.SwitchTo().Alert();
            //return true;
        }

        public ContactHelper RemoveContact()
        {

            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public void InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        public void SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
        }

        /* public  ContactData NewDataContact()
         {
             ContactData newContact = new ContactData("Kate", "opopo");
             newContact.Middlename = "kits";
            // newContact.Lastname = "opopo";
             return newContact;
         }*/

        public ContactData NewDataContact()
        {
            ContactData contact = new ContactData("Nast", "Pambukyan");
            contact.Middlename = "pum";
            // contact.Lastname = "Pambukyan";
            return contact;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> entries = driver.FindElements(By.Name("entry"));

                foreach (IWebElement entry in entries)
                {
                    string firstName = entry.FindElements(By.TagName("td"))[2].Text;
                    string lastName = entry.FindElements(By.TagName("td"))[1].Text;
                    contactCache.Add(new ContactData(firstName, lastName));
                }
            }

            //List<ContactData> contacts = new List<ContactData>();
            return new List<ContactData>(contactCache);
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allemails = cells[4].Text;
            string allphones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Adress = address,
                AllPhones = allphones,
                AllEmails = allemails,
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModificationTables(0);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            //почта
            string emailAddress = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2Address = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3Address = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Adress = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                EmailAddress = emailAddress,
                Email2Address = email2Address,
                Email3Address = email3Address
            };
        }


        public void InitContactModificationTables(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                 .FindElements(By.TagName("td"))[7]
                 .FindElement(By.TagName("a")).Click();
        }
    }
}

