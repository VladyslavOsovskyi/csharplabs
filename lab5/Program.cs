using System;
using System.Linq;

namespace Lab5_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            RunTasks();

            Console.WriteLine("\n[Система] Викликаємо збирач сміття...");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.ReadLine();
        }

        static void RunTasks()
        {

            Console.WriteLine("--- ЗАВДАННЯ 1 ТА 2: Ієрархія Тварин ---");

            Animal[] zoo = new Animal[]
            {
                new Bird(),
                new Bird("Страус", 5, false),
                new Mammal("Слон", "Океан"),
                new Artiodactyl("Олень", 4, "Ліс", true),
                new Artiodactyl("Кабан", "Лісостеп", false)
            };

            Console.WriteLine("\nНевідсортований масив:");
            foreach (var animal in zoo)
            {
                animal.Show();
            }

            Console.WriteLine("\nМасив, відсортований за Віком (поле базового класу):");
            var sortedZoo = zoo.OrderBy(a => a.Age).ToArray();

            foreach (var animal in sortedZoo)
            {
                animal.Show();
            }
            Console.WriteLine("----------------------------------------");

            Program3.Task3();
        }
    }
}   
