using System;
using System.Text;

namespace Lab2_Var14
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
                Console.WriteLine("       ЛАБОРАТОРНА №2        ");
                Console.WriteLine("=============================");
                Console.WriteLine("1 - Завдання 1.14 (Не діляться на 7)");
                Console.WriteLine("2 - Завдання 2.14 (Мінімум з додатних у 2D масиві)");
                Console.WriteLine("3 - Завдання 3.14 (Симетрія матриці: 1D та 2D)");
                Console.WriteLine("4 - Завдання 4.14 (Східчастий масив і вектор X)");
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
            Console.WriteLine("\n--- Завдання 1.14 ---");
            Console.Write("Введіть розмірність масиву (n): ");
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            Console.WriteLine("Введіть елементи масиву:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"a[{i}] = ");
                arr[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("\nНомери (індекси) елементів, які НЕ діляться на 7:");
            bool found = false;

            for (int i = 0; i < n; i++)
            {
                if (arr[i] % 7 != 0)
                {
                    Console.Write($"{i} ");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Таких елементів немає.");
            }
            Console.WriteLine("\n---------------------\n");
        }
        static void Task2()
        {
            Console.WriteLine("\n--- Завдання 2.14 ---");
            Console.Write("Введіть кількість рядків масиву (n): ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Введіть кількість стовпців масиву (m): ");
            int m = int.Parse(Console.ReadLine());

            int[,] arr = new int[n, m];

            Console.WriteLine("Введіть елементи двовимірного масиву:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"a[{i},{j}] = ");
                    arr[i, j] = int.Parse(Console.ReadLine());
                }
            }

            int minPositive = int.MaxValue;
            bool foundPositive = false;

            Console.WriteLine("\nВаш масив:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{arr[i, j],5} ");

                    if (arr[i, j] > 0)
                    {
                        foundPositive = true;
                        if (arr[i, j] < minPositive)
                        {
                            minPositive = arr[i, j];
                        }
                    }
                }
                Console.WriteLine();
            }

            if (foundPositive)
            {
                Console.WriteLine($"\nРезультат: Мінімальний додатний елемент = {minPositive}");
            }
            else
            {
                Console.WriteLine("\nРезультат: У масиві немає додатних елементів.");
            }

            Console.WriteLine("---------------------\n");
        }
        static void Task3()
        {
            Console.WriteLine("\n--- Завдання 3.14 ---");
            Console.Write("Введіть розмірність квадратної матриці (n): ");
            int n = int.Parse(Console.ReadLine());

            int[,] arr2D = new int[n, n];
            int[] arr1D = new int[n * n];

            Console.WriteLine("Введіть елементи матриці:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"a[{i},{j}] = ");
                    int value = int.Parse(Console.ReadLine());

                    arr2D[i, j] = value;
                    arr1D[i * n + j] = value; 

                }
            }

            Console.WriteLine("\nВаша матриця:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{arr2D[i, j],5} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n=== Перевірка СПОСОБОМ 1 (Двовимірний масив) ===");
            bool isSymmetric2D = true;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++) 

                {
                    if (arr2D[i, j] != arr2D[j, i])
                    {
                        isSymmetric2D = false;
                        break; 

                    }
                }
            }
            Console.WriteLine(isSymmetric2D ? "Матриця СИМЕТРИЧНА відносно головної діагоналі." : "Матриця НЕ симетрична.");

            Console.WriteLine("\n=== Перевірка СПОСОБОМ 2 (Одновимірний масив) ===");
            bool isSymmetric1D = true;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {

                    if (arr1D[i * n + j] != arr1D[j * n + i])
                    {
                        isSymmetric1D = false;
                        break;
                    }
                }
            }
            Console.WriteLine(isSymmetric1D ? "Матриця СИМЕТРИЧНА відносно головної діагоналі." : "Матриця НЕ симетрична.");

            Console.WriteLine("---------------------\n");
        }
        static void Task4()
        {
            Console.WriteLine("\n--- Завдання 4.14 ---");
            Console.Write("Введіть кількість рядків східчастого масиву (n): ");
            int n = int.Parse(Console.ReadLine());

            int[][] arr = new int[n][];

            Console.WriteLine("\nВведення елементів східчастого масиву:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Скільки елементів буде у рядку {i}?: ");
                int m = int.Parse(Console.ReadLine());

                arr[i] = new int[m];

                for (int j = 0; j < m; j++)
                {
                    Console.Write($"a[{i}][{j}] = ");
                    arr[i][j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine($"\nВведення вектора X (повинен мати {n} елементів, щоб перекрити всі рядки):");
            int[] x = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"X[{i}] = ");
                x[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("\nПочатковий східчастий масив:");
            PrintJaggedArray(arr);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {

                    if (j % 2 != 0)
                    {
                        arr[i][j] = x[i]; 

                    }
                }
            }
            Console.WriteLine("\nМасив після заміни парних стовпців на вектор X:");
            PrintJaggedArray(arr);

            Console.WriteLine("---------------------\n");
        }
        static void PrintJaggedArray(int[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write($"{arr[i][j],5} ");
                }
                Console.WriteLine();
            }
        }
    }
}
