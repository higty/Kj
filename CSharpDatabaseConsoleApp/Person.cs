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
    public class Team
    {
        public String Name { get; set; }
        public String Location { get; set; }

        public Team() { }
        public Team(String name, String location)
        {
            this.Name = name;
            this.Location = location;
        }
    }

    public class PersonName
    {
        public String Name { get; set; }
    }
    public class PersonNameAge
    {
        public String Name { get; set; }
        public Int32 Age { get; set; }
    }
    public class PersonNameAddress
    {
        public String Name { get; set; }
        public String Address { get; set; }
    }

    class AnonymousClassSample1
    {
        public String Name { get; set; }
        public String Address { get; set; }
    }


    public class TaskRecord
    {
        public String Id { get; set; }
        public String Title { get; set; }
        public DateTime DueDate { get; set; }
        public String Description { get; set; }
    }
    public class ScheduleRecord
    {
        public Guid ScheduleCD { get; set; }
        public String Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1}-{2}", this.Title
                , this.StartDate.ToString("yyyy/MM/dd"), this.EndDate.ToString("yyyy/MM/dd"));
        }
    }

}
