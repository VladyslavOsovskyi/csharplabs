using System;

namespace Lab6_OOP
{

    public interface ITrans : IComparable<ITrans>
    {
        string Brand { get; set; }
        string Number { get; set; }
        double Speed { get; set; }
        double BaseCapacity { get; set; }

        double GetCapacity();
        void ShowInfo();
    }

    public abstract class BaseTrans : ITrans
    {
        public string Brand { get; set; }
        public string Number { get; set; }
        public double Speed { get; set; }
        public double BaseCapacity { get; set; }

        public BaseTrans(string brand, string number, double speed, double baseCapacity)
        {
            Brand = brand; Number = number; Speed = speed; BaseCapacity = baseCapacity;
        }

        public abstract double GetCapacity();
        public abstract void ShowInfo();

        public int CompareTo(ITrans other)
        {
            if (other == null) return 1;
            return this.GetCapacity().CompareTo(other.GetCapacity());
        }
    }

    public class Car : BaseTrans
    {
        public Car(string b, string n, double s, double c) : base(b, n, s, c) { }
        public override double GetCapacity() => BaseCapacity;
        public override void ShowInfo() => Console.WriteLine($"[Легкова] {Brand} ({Number}) | Вантаж: {GetCapacity()} кг");
    }

    public class Motorcycle : BaseTrans
    {
        public bool HasSidecar { get; set; }
        public Motorcycle(string b, string n, double s, double c, bool sidecar) : base(b, n, s, c) { HasSidecar = sidecar; }
        public override double GetCapacity() => HasSidecar ? BaseCapacity : 0;
        public override void ShowInfo() => Console.WriteLine($"[Мотоцикл] {Brand} ({Number}) | Вантаж: {GetCapacity()} кг");
    }

    public class Truck : BaseTrans
    {
        public bool HasTrailer { get; set; }
        public Truck(string b, string n, double s, double c, bool trailer) : base(b, n, s, c) { HasTrailer = trailer; }
        public override double GetCapacity() => HasTrailer ? BaseCapacity * 2 : BaseCapacity;
        public override void ShowInfo() => Console.WriteLine($"[Вантажівка] {Brand} ({Number}) | Вантаж: {GetCapacity()} кг");
    }

    class Program2
    {
        public static void Task2()
        {
            Console.WriteLine("\n--- ЗАВДАННЯ 2: Транспорт та IComparable ---");

            ITrans[] garage = new ITrans[]
            {
                new Truck("MAN", "AM7777XX", 100, 8000, true),

                new Motorcycle("Yamaha", "КА0001ВВ", 220, 150, false),

                new Car("Toyota Camry", "AA1234BB", 180, 450),

                new Truck("Volvo", "CE9999OO", 110, 5000, false)

            };

            Console.WriteLine("База ДО сортування:");
            foreach (var t in garage) t.ShowInfo();

            Array.Sort(garage);

            Console.WriteLine("\nБаза ПІСЛЯ сортування (за вантажопідйомністю):");
            foreach (var t in garage) t.ShowInfo();

            Console.WriteLine("--------------------------------------------\n");
        }
    }
}
