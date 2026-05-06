using System;
using System.Linq;

namespace Lab5_OOP
{
    abstract class Trans
    {
        public string Brand { get; set; }
        public string Number { get; set; }
        public double Speed { get; set; }
        protected double BaseCapacity;

        public Trans(string brand, string number, double speed, double baseCapacity)
        {
            Brand = brand;
            Number = number;
            Speed = speed;
            BaseCapacity = baseCapacity;
        }

        public abstract void ShowInfo();
        public abstract double GetCapacity();
    }

    class Car : Trans
    {
        public Car(string brand, string number, double speed, double capacity)
            : base(brand, number, speed, capacity) { }

        public override double GetCapacity() => BaseCapacity;

        public override void ShowInfo()
        {
            Console.WriteLine($"[Легкова] {Brand} (ДНЗ: {Number}) | Швидкість: {Speed} км/год | Вантажопідйомність: {GetCapacity()} кг");
        }
    }

    class Motorcycle : Trans
    {
        public bool HasSidecar { get; set; }

        public Motorcycle(string brand, string number, double speed, double capacity, bool hasSidecar)
            : base(brand, number, speed, capacity)
        {
            HasSidecar = hasSidecar;
        }

        public override double GetCapacity() => HasSidecar ? BaseCapacity : 0;

        public override void ShowInfo()
        {
            string sidecarStr = HasSidecar ? "з коляскою" : "без коляски";
            Console.WriteLine($"[Мотоцикл] {Brand} (ДНЗ: {Number}) | {sidecarStr} | Вантажопідйомність: {GetCapacity()} кг");
        }
    }

    class Truck : Trans
    {
        public bool HasTrailer { get; set; }

        public Truck(string brand, string number, double speed, double capacity, bool hasTrailer)
            : base(brand, number, speed, capacity)
        {
            HasTrailer = hasTrailer;
        }

        public override double GetCapacity() => HasTrailer ? BaseCapacity * 2 : BaseCapacity;

        public override void ShowInfo()
        {
            string trailerStr = HasTrailer ? "з причепом" : "без причепа";
            Console.WriteLine($"[Вантажівка] {Brand} (ДНЗ: {Number}) | {trailerStr} | Вантажопідйомність: {GetCapacity()} кг");
        }
    }

    class Program3
    {
        public static void Task3()
        {
            Console.WriteLine("\n--- ЗАВДАННЯ 3: Транспортні засоби ---");

            Trans[] garage = new Trans[]
            {
                new Car("Toyota Camry", "AA1234BB", 180, 450),
                new Motorcycle("Yamaha", "КА0001ВВ", 220, 150, false),
                new Motorcycle("Дніпро", "ІВ2222АА", 120, 200, true),
                new Truck("Volvo", "CE9999OO", 110, 5000, false),
                new Truck("MAN", "AM7777XX", 100, 8000, true)
            };

            Console.WriteLine("База всіх транспортних засобів:");
            foreach (var t in garage) t.ShowInfo();

            Console.Write("\nВведіть необхідну масу вантажу (в кг): ");
            if (double.TryParse(Console.ReadLine(), out double requiredCapacity))
            {
                Console.WriteLine($"\nТранспортні засоби, які можуть перевезти {requiredCapacity} кг:");
                var suitableTrans = garage.Where(t => t.GetCapacity() >= requiredCapacity).ToList();

                if (suitableTrans.Any())
                {
                    foreach (var t in suitableTrans) t.ShowInfo();
                }
                else
                {
                    Console.WriteLine("На жаль, підходящих транспортних засобів немає.");
                }
            }
            Console.WriteLine("----------------------------------------\n");
        }
    }
}
