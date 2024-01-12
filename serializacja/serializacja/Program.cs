using System;
using System.IO;
using System.Xml.Serialization;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}

public class XmlSerializerExample
{
    public static void Main()
    {
        // Utwórz obiekt klasy Person
        Person person = new Person { FirstName = "Franek", LastName = "Kowalski", Age = 20 };

        // Utwórz obiekt klasy XmlSerializer
        XmlSerializer serializer = new XmlSerializer(typeof(Person));

        // Utwórz obiekt klasy FileStream
        using (FileStream fs = new FileStream("osoba.xml", FileMode.Create, FileAccess.Write))
        {
            // Zserializuj obiekt Person i zapisz go do pliku
            serializer.Serialize(fs, person);
        }

        // Wydrukuj informację o zakończeniu zapisu do pliku
        Console.WriteLine("Dane osoby zostały zserializowane i zapisane w pliku osoba.xml.");
    }
}