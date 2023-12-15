namespace _15._12
{
    class Book : IComparable<Book>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }

        public Book(string title, string author, int year, int price) 
        { 
            this.Title = title;
            this.Author = author;
            this.Year = year;
            this.Price = price;
        }
        public int CompareTo(Book? other)
        {
            if (other == null) return 1;
            return Price.CompareTo(other.Price);
        }
        public override string ToString()
        {
            return $"{this.Title},{this.Author},{this.Year}, cenus:{this.Price}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();
            Console.WriteLine(" ksiazki:");
            books.Add(new Book("Mały ksiazke","Szymon",1999,1112));
            books.Add(new Book("aaaa", "Władek", 1789, 20));
            books.Add(new Book("bbbbb", "Jan", 2001, 30));
            books.Add(new Book("cccc", "Dominik", 1670, 40));

            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine("\n");
            books.Sort();
            Console.WriteLine("Posortowane ksiazki:\n");

            foreach (Book book in books)
            {
                Console.WriteLine(book.ToString());
            }

            Console.WriteLine("\n sortowanie rok");
            var sortedByYear =  books.OrderBy(x => x.Year);
            foreach (Book book in sortedByYear)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine("\n sortowanie tytul");
            var sortedBytitle = books.OrderByDescending(x => x.Title);
            foreach (Book book in sortedBytitle)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine("\n sortowanie ceny nie rosnaco a nastepnie według roku od najstarszej ksiazki");
            var sortedByPriceThenYear = books.OrderByDescending(x => x.Price).ThenBy(x =>x.Year);
            foreach (Book book in sortedByPriceThenYear)
            {
                Console.WriteLine(book);
            }
        }
    }
}