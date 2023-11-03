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
        public Student(string name, string surname, DateTime dateOfBirth, string studentNumber) : base (name, surname, dateOfBirth) //Konstruktor
        {
            this.StudentNumber = studentNumber;
        }
    }
internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}