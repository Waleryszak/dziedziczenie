using System.Diagnostics;
using System.Net;

namespace zadanieOpjęciaObiektowe
{
    /*
    •	Napisz program w języku C#, który ilustruje pojęcia programowania obiektowego, takie jak klasy, dziedziczenie, pola, właściwości i metody.
    •	Zdefiniuj klasę bazową Person, która ma pola name, surname i dateOfBirth oraz konstruktor przyjmujący te wartości jako parametry.
    •	Dodaj do klasy Person metodę GetFullName, która zwraca pełne imię i nazwisko osoby, oraz właściwość Age, która oblicza wiek osoby na podstawie daty urodzenia.
    •	Zdefiniuj klasę Address, która ma pola city, street, houseNumber i postalCode jako właściwości oraz konstruktor przyjmujący te wartości jako parametry.
    •	Dodaj do klasy Person pole address typu Address i zmodyfikuj konstruktor klasy Person, aby przyjmował obiekt klasy Address jako parametr.
    •	Zdefiniuj klasę pochodną Student, która dziedziczy po klasie Person i ma dodatkowe pole studentNumber oraz konstruktor przyjmujący te wartości jako parametry.
    •	Zdefiniuj klasę pochodną Teacher, która dziedziczy po klasie Person i ma dodatkowe pole subjects typu List<string> oraz konstruktor przyjmujący te wartości jako parametry.
    •	Utwórz obiekty każdej klasy, używając słowa kluczowego new i podając odpowiednie wartości w konstruktorach.
    •	Wyświetl dane utworzonych obiektów, używając metody Console.WriteLine i właściwości obiektów.
    */
    class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Adress Adress { get; set; } // Pola klasy person typu adres

        public Person(string name, string surname, DateTime dateOfBirth) //Konstruktor
        {
            this.Name = name;
            this.Surname = surname;
            this.DateOfBirth = dateOfBirth;
        }

        public Person(string name, string surname,DateTime dateOfBirth, Adress adress) : this(name,surname,dateOfBirth)//Konstruktor
        {
            this.Adress = adress;
        }

        public string getFullName()
        {
            return this.Name + " " + this.Surname;
        }

        public int Age //właściwość
        {
            get
            {
                /*DateTime today = DateTime.Today;
                byte age = today.Year - DateOfBirth.Year;
                if (DateOfBirth > today.AddYears(-age))
                    age--;
                return age;*/
                TimeSpan difference = DateTime.Now - this.DateOfBirth;
                return (int)(difference.Days / 356.25);
            }
        }
    }
    class Adress
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string HouseNumber { get; set; }

        public Adress (string city, string street, string postalCode, string houseNumber) //Konstruktor klasy adres
        {
            City = city;
            Street = street;
            PostalCode = postalCode;
            HouseNumber = houseNumber;
        }
    }

    class Student : Person
        {
            public string StudentNumber { get; set; }
        public Student(string name, string surname, DateTime dateOfBirth, string studentNumber, Adress adress) : base (name, surname, dateOfBirth,adress) //Konstruktor
        {
            this.StudentNumber = studentNumber;
        }
    }

    class Teacher : Person
    {
        public List<string> Subjects { get; set; }
        public Teacher(string name, string surname, DateTime dateOfBirth,Adress adress, List<string> subjects) : base(name, surname, dateOfBirth,adress) //Konstruktor
        {
            Subjects = subjects;

        }
    }
    internal class Program
    {
        public static List<Person> users = new List<Person> ();
        static int DisplayMenu()
        {
            Console.WriteLine("\nProgram do zarzadzania uzytkowanikami \n Wybierz opcje:\n");
            Console.WriteLine("1. Dodaj Uzytkownika");
            Console.WriteLine("2. Odczytaj uzytkownikow");
            Console.WriteLine("3. usun uzytkownikow");
            Console.WriteLine("4. wyjscie");
              
            return int.Parse(Console.ReadLine());
        }
        static void AddUser()
        {
            Console.Clear();
            Console.WriteLine("Wybierz typ uzytkownika");
            Console.WriteLine("1. Osoba");
            Console.WriteLine("2. Student");
            Console.WriteLine("3. Nauczyciel");
            Console.WriteLine("4. wyjscie");

            int opcja = Convert.ToInt32(Console.ReadLine());

            switch (opcja)
            {
                case 1:
                    Console.WriteLine("Imie:");
                    string firstname = Console.ReadLine();
                    Console.WriteLine("Nazwisko:");
                    string lastname = Console.ReadLine();
                    Console.WriteLine("Data urodzenia (YYYY-MM-DD):");
                    DateTime dateofbirth = DateTime.Parse(Console.ReadLine());
                    Person user = new Person(firstname,lastname,dateofbirth);
                    users.Add(user);
                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:
                    return;
            }
        }

        static void DisplayUsers()
        {
            Console.Clear();
            if(users.Count == 0)
            {
                Console.WriteLine("W bazie nie ma żadnych użytkownikow \n");
            }
            else
            {
                Console.WriteLine("\nLista uzytkownikow");

                int count = 1;
                foreach(Person users in users)
                {
                    Console.WriteLine($"Użytkownik{count}:");
                    Console.WriteLine($"Imie i nazwisko: {users.Name} {users.Surname},\n Data urodzenia: {users.DateOfBirth.ToShortDateString()} \n");
                    count++;
                }
            }
        }
        static void Clearusers()
        {
            users.Clear();
        }
        static void Main(string[] args)
        {
            while (true)
            {
                switch (DisplayMenu())
                {
                    case 1:
                        AddUser();
                        break;
                    case 2:
                        DisplayUsers();
                        break;
                    case 3:
                        Clearusers();
                        Console.WriteLine("Wszyscy uzytkownicy zostali usunięci \n");
                        break;
                    case 4:
                        Console.WriteLine("Dzięki za skorzystanie z programu");
                        Thread.Sleep(2000);
                        return;
                    default:
                        Console.WriteLine("Nie prawidłowa opcja");
                        break;
                }

            }
            /* Person person = new Person("Jan","Kowalski", new DateTime(2000,01,01), new Adress("Poznań", "Polna", "10", "12-345")); ;
             Student student = new Student("Dominik","Waleryszak", new DateTime(2002,11,18),"pzx110673", new Adress("Kostrzyn","Wrzesińska","69","62-025"));
             Teacher teacher = new Teacher("Wiesław","Paleta", new DateTime(1975,01,18), new Adress("Poznań", "szkolna", "2137", "12-345"),new List<string>() { "Matematyka","Programowanie"});

             Console.WriteLine($"Imie:{student.Name} Nazwisko: {student.Surname} Data urodzenia: {student.DateOfBirth.ToShortDateString()} Nr: {student.StudentNumber}\n Miasto: {student.Adress.City} Ul: {student.Adress.Street} Kod: {student.Adress.PostalCode}");
             Console.WriteLine($"Imie:{person.Name} Nazwisko: {person.Surname} Data urodzenia: {person.DateOfBirth.ToShortDateString()} \n Miasto: {person.Adress.City} Ul: {person.Adress.Street} Kod: {person.Adress.PostalCode}");
             Console.WriteLine($"Imie:{teacher.Name} Nazwisko: {teacher.Surname} Data urodzenia: {teacher.DateOfBirth.ToShortDateString()}\n Miasto: {teacher.Adress.City} Ul: {teacher.Adress.Street} Kod: {teacher.Adress.PostalCode} Przedmioty: {string.Join(", ", teacher.Subjects)}");
            */

        }
    }
}
