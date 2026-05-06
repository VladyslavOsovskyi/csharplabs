using System;
using System.Text;
using System.Collections;

namespace Lab6_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\n=============================");
                Console.WriteLine("       ЛАБОРАТОРНА №6        ");
                Console.WriteLine("=============================");
                Console.WriteLine("1 - Завдання 1 (Інтерфейси тварин + Патерни)");
                Console.WriteLine("2 - Завдання 2 (Транспорт + IComparable)");
                Console.WriteLine("3 - Завдання 3 (Обробка винятків) ");
                Console.WriteLine("4 - Завдання 4 (IEnumerable для вектора) ");
                Console.WriteLine("0 - Вихід");
                Console.WriteLine("=============================");
                Console.Write("Оберіть номер: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": Program1.Task1(); break;
                    case "2": Program2.Task2(); break;
                    case "3": Program3.Task3(); break;
                    case "4": Program4.Task4(); break;
                    case "0": return;
                    default: Console.WriteLine("Помилка вводу."); break;
                }
            }
        }
    }
}
