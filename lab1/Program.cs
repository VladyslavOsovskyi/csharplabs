using System;
using System.Text;

namespace Lab1_Var14
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
                Console.WriteLine("       ЛАБОРАТОРНА №1        ");
                Console.WriteLine("1 - Завдання 1.14 (Радіус кола)");
                Console.WriteLine("2 - Завдання 2.14 (Цифри числа)");
                Console.WriteLine("3 - Завдання 3.14 (Точка на графіку)");
                Console.WriteLine("4 - Завдання 4.14 (Східний календар)");
                Console.WriteLine("5 - Завдання 5.14 (Функція: квадрат різниці)");
                Console.WriteLine("6 - Завдання 6.14 (Обчислення виразу)");
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
                    case "3":
                        Task3();
                        break;
                    case "4":
                        Task4();
                        break;
                    case "5":
                        Task5();
                        break;
                    case "6":
                        Task6();
                        break;
                    case "0":
                        Console.WriteLine("Завершення роботи...");
                        return;
                    default:
                        Console.WriteLine("Помилка! Такого завдання немає. Спробуйте ще раз.");
                        break;
                }
            }
        }


        static void Task1()
        {
            Console.WriteLine("\n--- Завдання 1.14 ---");
            Console.Write("Введіть площу круга (S): ");

            double s = double.Parse(Console.ReadLine());
            double r = Math.Sqrt(s / Math.PI);

            Console.WriteLine($"Радіус кола (R) = {r}");
            Console.WriteLine("---------------------\n");
        }

        static void Task2()
        {
            Console.WriteLine("\n--- Завдання 2.14 ---");
            Console.Write("Введіть ціле тризначне число: ");

            int number = int.Parse(Console.ReadLine());
            number = Math.Abs(number);

            if (number >= 100 && number <= 999)
            {
                int firstDigit = number / 100;
                int secondDigit = (number / 10) % 10;

                Console.WriteLine($"Перша цифра: {firstDigit}, Друга цифра: {secondDigit}");

                if (firstDigit > secondDigit)
                    Console.WriteLine("Результат: Перша цифра БІЛЬША за другу.");
                else if (secondDigit > firstDigit)
                    Console.WriteLine("Результат: Друга цифра БІЛЬША за першу.");
                else
                    Console.WriteLine("Результат: Цифри однакові.");
            }
            else
            {
                Console.WriteLine("Помилка! Ви ввели не тризначне число.");
            }
            Console.WriteLine("---------------------\n");
        }

        static void Task3()
        {
            Console.WriteLine("\n--- Завдання 3.14 ---");
            Console.Write("Введіть координату x: ");
            double x = double.Parse(Console.ReadLine());

            Console.Write("Введіть координату y: ");
            double y = double.Parse(Console.ReadLine());

            if (x > -23 && y < 0 && y > x)
            {
                Console.WriteLine("Результат: Так (всередині)");
            }
            else if (x >= -23 && y <= 0 && y >= x)
            {
                Console.WriteLine("Результат: На межі");
            }

            else
            {
                Console.WriteLine("Результат: Ні (поза областю)");
            }

            Console.WriteLine("---------------------\n");
        }
        static void Task4()
        {
            Console.WriteLine("\n--- Завдання 4.14 ---");
            Console.Write("Введіть рік: ");
            int year = int.Parse(Console.ReadLine());

            if (year <= 0)
            {
                Console.WriteLine("Будь ласка, введіть додатній рік нашої ери.");
            }
            else
            {
                string animal = (year % 12) switch
                {
                    0 => "Мавпа",
                    1 => "Півень",
                    2 => "Собака",
                    3 => "Свиня",
                    4 => "Щур",
                    5 => "Бик",
                    6 => "Тигр",
                    7 => "Кролик",
                    8 => "Дракон",
                    9 => "Змія",
                    10 => "Кінь",
                    11 => "Коза (Вівця)",
                    _ => "Невідомо" 
                };

                Console.WriteLine($"Результат: {year} рік символізує {animal}.");
            }

            Console.WriteLine("---------------------\n");
        }

        static double CalcSquareOfDifference(double a, double b)
        {
            return Math.Pow(a - b, 2);
        }
        static void Task5()
        {
            Console.WriteLine("\n--- Завдання 5.14 ---");
            Console.Write("Введіть перше дійсне число (a): ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Введіть друге дійсне число (b): ");
            double b = double.Parse(Console.ReadLine());

            double result = CalcSquareOfDifference(a, b);

            Console.WriteLine($"Результат: ({a} - {b})^2 = {result}");
            Console.WriteLine("---------------------\n");
        }
        static void Task6()
        {
            Console.WriteLine("\n--- Завдання 6.14 ---");
            Console.Write("Введіть дійсне число (a): ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Введіть дійсне число (b): ");
            double b = double.Parse(Console.ReadLine());


            double denominator1 = (a * a) + (a * b) + 1;
            double denominator2 = (b * b) + (a * b) 
                
                + 1;

            if (denominator1 == 0 || denominator2 == 0)
            {
                Console.WriteLine("Помилка! Знаменник дорівнює нулю, ділення неможливе.");
            }
            else
            {
                double result = (1 / denominator1) - (1 / denominator2);
                Console.WriteLine($"Результат виразу = {Math.Round(result, 4)}");
            }

            Console.WriteLine("---------------------\n");
        }
    }
}
