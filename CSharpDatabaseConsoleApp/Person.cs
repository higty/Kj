using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDatabase
{
    public enum Gender
    {
        Man,
        Woman,
    }
    public class Person
    {
        public String Name { get; set; }
        public Int32 Age { get; set; }
        public Gender Gender { get; set; } 
        public String Sports { get; set; }
        public String Address { get; set; }
        public String Description { get; set; }

        public Person() { }
        public Person(String name, Int32 age, Gender gender, String sprots)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
            this.Sports = sprots;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} ({3})"
                , this.Name, this.Age, this.Gender.ToString(), this.Sports);
        }
    }

    public class PersonName
    {
        public String Name { get; set; }
    }
}
