using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressBookTests
{
    [Table (Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;

        //конструктор
        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public ContactData()
        {
        }

        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }

        [Column(Name = "firstname")]
        public string Firstname { get; set; }

        [Column(Name = "middlename"), PrimaryKey]
        public string Middlename { get; set; }

        [Column(Name = "lastname")]
        public string Lastname { get; set; }

        [Column(Name = "address")]
        public string Adress { get; set; }

        [Column(Name = "home")]
        public string HomePhone { get; set; }

        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }

        [Column(Name = "work")]
        public string WorkPhone { get; set; }

        [Column(Name = "email")]
        public string EmailAddress { get; set; }

        [Column(Name = "email2")]
        public string Email2Address { get; set; }

        [Column(Name = "email3")]
        public string Email3Address { get; set; }

        public string AllContactsNames { get; set; }

        public string AllPhones {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (ClenUp(HomePhone) + ClenUp(MobilePhone) + ClenUp(WorkPhone)).Trim();
                }

            }
            set
            {
                allPhones = value;
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (ClenUpEmail(EmailAddress) + ClenUpEmail(Email2Address) + ClenUpEmail(Email3Address)).Trim();
                }

            }
            set
            {
                allEmails = value;
            }
        }
        //БД
        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts select c).ToList();
            }
        }
        //
        private string ClenUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
             
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "").
                Replace("H:","").Replace("M","").Replace(":","")+ "\r\n";
          //  return Regex.Replace(phone, "[ -()[A-Z]:]", "") + "\r\n";
        }


        private string ClenUpEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email + "\r\n";
        }




        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return false;
            }
            return Lastname == other.Lastname
                && Firstname == other.Firstname;
        }

        public override int GetHashCode()
        {
            return Lastname.GetHashCode() ^ Firstname.GetHashCode();
        }

        public override string ToString()
        {
            return "name = " + Lastname + " " + Firstname + "\nmiddlename = " + Middlename;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (!Object.ReferenceEquals(other.Lastname, Lastname))
            {
                return other.Lastname.CompareTo(Lastname);
            }

            else if (!Object.ReferenceEquals(other.Firstname, Firstname))
            {
                return other.Firstname.CompareTo(Firstname);
            }

            else
            {
                return 0;
            }

        }


    }
}
