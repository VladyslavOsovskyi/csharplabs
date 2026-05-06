using System;

namespace Lab6_OOP
{

    public interface IAnimal
    {
        string Name { get; set; }
        void Show();
    }

    public interface IMammal : IAnimal
    {
        void FeedMilk();

    }

    public interface IBird : IAnimal
    {
        void LayEggs();

    }

    public class Mammal : IMammal
    {
        public string Name { get; set; }
        public string Habitat { get; set; }

        public Mammal(string name, string habitat)
        {
            Name = name;
            Habitat = habitat;
        }

        public void Show()
        {
            Console.WriteLine($"[Савець] Ім'я: {Name}, Середовище: {Habitat}");
        }

        public void FeedMilk()
        {
            Console.WriteLine($"   -> {Name} годує малят молоком.");
        }
    }

    public class Artiodactyl : IMammal
    {
        public string Name { get; set; }
        public bool HasHorns { get; set; }

        public Artiodactyl(string name, bool hasHorns)
        {
            Name = name;
            HasHorns = hasHorns;
        }

        public void Show()
        {
            string horns = HasHorns ? "з рогами" : "без рогів";
            Console.WriteLine($"[Парнокопитне] Ім'я: {Name}, Особливість: {horns}");
        }

        public void FeedMilk()
        {
            Console.WriteLine($"   -> {Name} годує малят молоком (і жує траву).");
        }

        public void RunWithHooves()
        {
            Console.WriteLine($"   -> {Name} голосно цокає копитами!");
        }
    }

    public class Bird : IBird
    {
        public string Name { get; set; }
        public bool CanFly { get; set; }

        public Bird(string name, bool canFly)
        {
            Name = name;
            CanFly = canFly;
        }

        public void Show()
        {
            string fly = CanFly ? "літає" : "не літає";
            Console.WriteLine($"[Птах] Ім'я: {Name}, Здібність: {fly}");
        }

        public void LayEggs()
        {
            Console.WriteLine($"   -> {Name} відкладає яйця у гніздо.");
        }
    }

    class Program1
    {
        public static void Task1()
        {
            Console.WriteLine("\n--- ЗАВДАННЯ 1: Інтерфейси та Патерни типів ---");

            IAnimal[] zoo = new IAnimal[]
            {
                new Mammal("Слон", "Савана"),
                new Bird("Орел", true),
                new Artiodactyl("Олень", true),
                new Bird("Пінгвін", false)
            };

            Console.WriteLine("Виклик спільного методу Show() для всіх:");
            foreach (IAnimal animal in zoo)
            {
                animal.Show();
            }

            Console.WriteLine("\nВикористання ПАТЕРНІВ ТИПІВ (Type Patterns) для унікальних методів:");
            foreach (IAnimal animal in zoo)
            {
                animal.Show();

                switch (animal)
                {
                    case Artiodactyl artio:

                        artio.FeedMilk();
                        artio.RunWithHooves();
                        break;

                    case IMammal mammal:

                        mammal.FeedMilk();
                        break;

                    case IBird bird:

                        bird.LayEggs();
                        break;

                    case null:
                        Console.WriteLine("Об'єкт порожній.");
                        break;
                }
                Console.WriteLine();
            }
            Console.WriteLine("----------------------------------------------\n");
        }
    }
}
