using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
        private string middlename = "";
        private string lastname = "";

        //конструктор
        public ContactData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }


        //свойстви знаечний
        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        public string Middlename
        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
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
            return "name = " + Lastname + " " + Firstname;
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
