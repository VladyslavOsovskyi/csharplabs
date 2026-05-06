using System;
using System.Linq;
using System.Text;

namespace Lab3_OOP
{
    class Romb
    {
        protected int a;
        protected int d1;
        protected int c;

        public Romb(int side, int diag, int color)
        {
            if (diag >= 2 * side)
            {
                throw new ArgumentException("Такий ромб не може існувати (діагональ занадто велика)!");
            }
            a = side;
            d1 = diag;
            c = color;
        }
        public int Side
        {
            get { return a; }
            set { if (d1 < 2 * value) a = value; }
        }

        public int Diagonal
        {
            get { return d1; }
            set { if (value < 2 * a) d1 = value; }
        }

        public int Color
        {
            get { return c; }
        }
        public void PrintLengths()
        {
            Console.WriteLine($"Ромб [Колір: {c}]: Сторона = {a}, Діагональ 1 = {d1}");
        }

        public double Perimeter()
        {
            return 4 * a;
        }

        public double Area()
        {
            double d2 = Math.Sqrt(4 * a * a - d1 * d1);
            return (d1 * d2) / 2.0;
        }

        public bool IsSquare()
        {
            return (d1 * d1 == 2 * a * a);
        }
    }
    class Animal
    {
        protected string Name;
        protected int Age;

        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public virtual void Show()
        {
            Console.WriteLine($"[Тварина] Ім'я: {Name}, Вік: {Age}");
        }
    }

    class Mammal : Animal
    {
        protected string Habitat;

        public Mammal(string name, int age, string habitat) : base(name, age)
        {
            Habitat = habitat;
        }

        public override void Show()
        {
            Console.WriteLine($"[Савець] Ім'я: {Name}, Вік: {Age}, Середовище: {Habitat}");
        }
    }

    class Bird : Animal
    {
        protected bool CanFly;

        public Bird(string name, int age, bool canFly) : base(name, age)
        {
            CanFly = canFly;
        }

        public override void Show()
        {
            string flying = CanFly ? "Літає" : "Не літає";
            Console.WriteLine($"[Птах] Ім'я: {Name}, Вік: {Age}, Вміння літати: {flying}");
        }
    }

    class Artiodactyl : Mammal
    {
        protected bool HasHorns;

        public Artiodactyl(string name, int age, string habitat, bool hasHorns) : base(name, age, habitat)
        {
            HasHorns = hasHorns;
        }

        public override void Show()
        {
            string horns = HasHorns ? "Є роги" : "Немає рогів";
            Console.WriteLine($"[Парнокопитне] Ім'я: {Name}, Вік: {Age}, Середовище: {Habitat}, Ознака: {horns}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\n=============================");
                Console.WriteLine("       ЛАБОРАТОРНА №3        ");
                Console.WriteLine("=============================");
                Console.WriteLine("1 - Завдання 1 (Масив ромбів)");
                Console.WriteLine("2 - Завдання 2 (Ієрархія тварин)");
                Console.WriteLine("0 - Вихід з програми");
                Console.WriteLine("=============================");
                Console.Write("Оберіть номер завдання: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Task1();
                        break;
                    case "2":
                        Task2();
                        break;
                    case "0":
                        Console.WriteLine("Завершення роботи...");
                        return;
                    default:
                        Console.WriteLine("Помилка! Такого завдання немає.");
                        break;
                }
            }
        }

        static void Task1()
        {
            Console.WriteLine("\n--- Завдання 1.4: Ромби ---");

            Romb[] rombs = new Romb[]
            {
                new Romb(5, 6, 2),
                new Romb(10, 14, 1),
                new Romb(8, 10, 3),
                new Romb(7, 7, 1)
            };

            Console.WriteLine("\nВпорядковані за КОЛЬОРОМ:");
            var byColor = rombs.OrderBy(r => r.Color).ToArray();
            foreach (var r in byColor) r.PrintLengths();

            Console.WriteLine("\nВпорядковані за ПЛОЩЕЮ:");
            var byArea = rombs.OrderBy(r => r.Area()).ToArray();
            foreach (var r in byArea)
            {
                r.PrintLengths();
                Console.WriteLine($"   Площа: {r.Area():F2}");
            }

            Console.WriteLine("\nВпорядковані за ПЕРИМЕТРОМ:");
            var byPerimeter = rombs.OrderBy(r => r.Perimeter()).ToArray();
            foreach (var r in byPerimeter)
            {
                r.PrintLengths();
                Console.WriteLine($"   Периметр: {r.Perimeter()}");
            }

            Console.WriteLine("\nКількість квадратів у масиві:");
            int squareCount = rombs.Count(r => r.IsSquare());
            Console.WriteLine(squareCount);

            Console.WriteLine("---------------------\n");
        }

        static void Task2()
        {
            Console.WriteLine("\n--- Завдання 2.14: Ієрархія Тварин ---");
            Animal[] animals = new Animal[]
            {
                new Animal("Невідома тварина", 10),
                new Mammal("Ведмідь", 5, "Ліс"),
                new Bird("Орел", 3, true),
                new Bird("Пінгвін", 4, false),
                new Artiodactyl("Олень", 6, "Лісостеп", true),
                new Mammal("Кит", 15, "Океан")
            };

            Console.WriteLine("Початковий список тварин:");
            foreach (var animal in animals)
            {
                animal.Show();
            }
            Console.WriteLine("\nСписок тварин, ВПОРЯДКОВАНИЙ ЗА ТИПАМИ КЛАСУ:");
            var sortedAnimals = animals.OrderBy(a => a.GetType().Name).ToArray();

            foreach (var animal in sortedAnimals)
            {
                animal.Show();
            }

            Console.WriteLine("---------------------\n");
        }
    }
}
