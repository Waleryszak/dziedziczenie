using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace PersonXmlSerialization
{
    [XmlRoot("Person")]
    public class Person
    {
        [XmlAttribute("FirstName")]
        public string FirstName { get; set; }

        [XmlAttribute("LastName")]
        public string LastName { get; set; }

        [XmlAttribute("Age")]
        public int Age { get; set; }

        public Person() { }

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public override string ToString()
        {
            return $"FirstName: {FirstName}, LastName: {LastName}, Age: {Age}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person("John", "Doe", 30);

            XmlSerializer xs = new XmlSerializer(typeof(Person));

            using (FileStream s = new FileStream("osoba.xml", FileMode.Create))
            {
                xs.Serialize(s, p);
            }

            using (FileStream s = new FileStream("osoba.xml", FileMode.Open))
            {
                Person p2 = (Person)xs.Deserialize(s);
                Console.WriteLine(p2);
            }
        }
    }
}