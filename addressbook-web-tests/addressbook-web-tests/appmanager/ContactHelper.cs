﻿using System;
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
            //SelectContact(v);
            InitContactModification();
            FillContactForm(newDataContact);
            SubmitContactModification();
            return this;
        }

        public void DeleteContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            SelectGroupToDelFrom(group.Name);
            SelectContactToDelFrom(contact.Id);
            CommitDelContactFromGroup();
        }

        private void CommitDelContactFromGroup() 
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        private void SelectContactToDelFrom(string contactId)
        {
            driver.FindElement(By.Id(contactId)).Click();
        }

        private void SelectGroupToDelFrom(string name)
        {
            //new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
         
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
            // driver.FindElement(By.Id("51")).Click();
            // driver.FindElement(By.Name("group")).Click();

        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContactToAdd(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);

        }

        public void SelectContactToAdd(string contactId)
        {
            driver.FindElement(By.Id(contactId)).Click();
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        public ContactHelper ContactModify(ContactData contact, ContactData newDataContact)
        {
            manager.Navigator.GoToHomePage();
            //SelectContact(contact.Id);
            InitContactModification(contact.Id);
            FillContactForm(newDataContact);
            SubmitContactModification();
            return this;
        }

    
        public ContactHelper RemoveContact(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(contact.Id);
            RemoveContact();
            SubmitRemove();
            return this;
        }

      

        public ContactHelper RemoveContact(int v)
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

        public ContactHelper InitContactModification(string id)
        {
            driver.FindElement(By.XPath(String.Format("//a[@href='edit.php?id={0}']", id))).Click();
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

       public ContactHelper SelectContact(string id)
       {
            // driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (id) + "]")).Click();
           driver.FindElement(By.XPath($"//input[@name='selected[]'][@id={id}]")).Click();
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

        //для сравнений с детальной формой
       // public ContactData GetContactInformationFromEditFormForDetails(int index)
       // {
           // manager.Navigator.GoToHomePage();
         //   InitContactModificationTables(0);

         //   string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
          //  string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            

       // }

        // таблица свойств контакта
        public ContactData GetContactInformationFromDetailTable(int v)
        {
            manager.Navigator.GoToHomePage();
            InitContactDetailsForm(0);

            //string allContactsNames = driver.FindElement(By.CssSelector("div#content")).Text;
            //string[] parts = allContactsNames.Split('\n');

            //string allName = parts[0].ToString();
            //string[] words = allName.Split(new char[] { ' ' });
            //string firstName = words[0];
            //string lastName = words[1].Trim();
            //string allemails = parts[5].ToString() + "\n" + parts[6].ToString();
            //string allphones = parts[2].ToString() + parts[3].ToString();

            //надо брать информацию полностью
            string allContactsNames = driver.FindElement(By.CssSelector("div#content")).Text;
            return new ContactData()
            {
                AllContactsNames = allContactsNames
        };

    }
    //return new ContactData(firstName, lastName)
    //{

    //AllPhones = allphones,
    // AllEmails = allemails,
    //};




    public void InitContactModificationTables(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                 .FindElements(By.TagName("td"))[7]
                 .FindElement(By.TagName("a")).Click();
        }
        
        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();

            string text = driver.FindElement(By.TagName("span")).Text;
            return Int32.Parse(text);

        }

        public int GetContactCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        private void InitContactDetailsForm(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                 .FindElements(By.TagName("td"))[6]
                 .FindElement(By.TagName("a")).Click();
        }
    }
}

