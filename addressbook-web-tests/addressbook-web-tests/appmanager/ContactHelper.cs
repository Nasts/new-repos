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

        public ContactHelper AddContactToGroup(int v)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(v);
            new GroupHelper(manager).SelectGroup(v);
            SubmitAddContactToGroup();
            //manager.Navigator.GoToGroupsPage();
            return this;
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();

            manager.Navigator.GoToHomePage();

            ICollection<IWebElement> entries = driver.FindElements(By.Name("entry"));
           

            foreach (IWebElement entry in entries)
            {
                string firstName = entry.FindElements(By.TagName("td"))[2].Text;
                string lastName = entry.FindElements(By.TagName("td"))[1].Text;
                contacts.Add(new ContactData(firstName, lastName));
            }
            return contacts;
           
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
            return this;
        }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            return this;
        }

        public ContactHelper SubmitAddContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
            return this;
        }



        public ContactHelper SubmitRemove()
        {
            driver.SwitchTo().Alert().Accept();
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
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }

        public void InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        public void SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
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
    }
}
