using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        
        //конструктор
        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }


        //свойстви знаечний
        public string Firstname { get; set; }
       

        public string Middlename { get; set; }
        
        public string Lastname { get; set; }
        

  
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
