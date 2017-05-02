﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
      
        public GroupData(string name)
        {
            //присваивание в свойство
            Name = name;
        }
        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other,null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return false;
            }
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name = " + Name;
        }

        //other - второй объект, с которым сравниваем текущий
        //1 - текущий объект this больше, 0 - равны
        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }


        public string Name { get; set; }
       
        public string Header { get; set; }

        public string Footer { get; set; }

        public string Id { get; set; }
        
    }
}
