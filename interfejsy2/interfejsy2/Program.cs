using System.Globalization;

namespace interfejsy2
{
    class EngineFailureException : Exception
    {
        public EngineFailureException(string message) : base(message)
        {

        }
    }

    interface IMovable
    {
        void Drive(int distance);
        event EventHandler<Car> Broken;
    }

    class Car : IMovable
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public string Color { get; set; }
        public int Capacity { get; set; }
        public int Mileage { get; set; }

        public Car(string brand, string model, string color, int capacity)
        {
            Brand = brand;
            Model = model;
            Color = color;  
            Capacity = capacity;
            Broken += (sender, args) => Console.WriteLine("Samochód rozjebał sie na amen");
        }

        public void Drive(int distance)
        {
            Mileage += distance;
            Random rand = new Random();
            int num = rand.Next(1, 100);
            if (num < 10) 
            {
                throw new EngineFailureException("Silnik kaput sznela niśt worken!");            
            }
        }

        public event EventHandler<Car> Broken;

        public void OnBroken()
        {
            if (Broken != null) 
            {
                Broken(this, this);
            }
        }

        public override string ToString()
        {
            return $"{Brand},{Model},{Capacity},{Mileage}";
        }
    }

    class Mechanic
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }

        public Mechanic(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public delegate bool Repair(Car c);

        public void PerformRepair(Car c, Repair r )
        {
            bool result = r(c);
            Console.WriteLine($"{Name}, {Surname} Naprawiał {c.Brand} {c.Model} {(result ? "naprawiony" : "nie naprawiony")}");
        }
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}