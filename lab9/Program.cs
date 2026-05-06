using System;
using System.Collections;
using System.IO;
using System.Text;

namespace Lab9Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\n================ ЛАБОРАТОРНА РОБОТА №9 ================");
                Console.WriteLine("1. Завдання 1.4 (Stack: чи є рядок s2 зворотним до s1)");
                Console.WriteLine("2. Завдання 2.4 (Queue: числа з файлу, спочатку додатні, потім від'ємні)");
                Console.WriteLine("3. Завдання 3 (ArrayList: задачі 1 і 2 через динамічний масив)");
                Console.WriteLine("4. Завдання 4 (Hashtable: Каталог музичних компакт-дисків)");
                Console.WriteLine("0. Вихід");
                Console.Write("Виберіть завдання (0-4): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Lab9T1 task1 = new Lab9T1();
                        task1.Run();
                        break;
                    case "2":
                        Lab9T2 task2 = new Lab9T2();
                        task2.Run();
                        break;
                    case "3":
                        Lab9T3 task3 = new Lab9T3();
                        task3.Run();
                        break;
                    case "4":
                        Lab9T4 task4 = new Lab9T4();
                        task4.Run();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }
    }

    public class Lab9T1
    {
        public void Run()
        {
            Console.WriteLine("\n--- Завдання 1.4: Перевірка зворотного рядка через Стек ---");
            Console.Write("Введіть рядок s1: ");
            string s1 = Console.ReadLine();
            Console.Write("Введіть рядок s2: ");
            string s2 = Console.ReadLine();

            if (s1.Length != s2.Length)
            {
                Console.WriteLine("Результат: Рядки різної довжини, s2 НЕ є зворотним до s1.");
                return;
            }

            Stack stack = new Stack();

            foreach (char c in s1)
            {
                stack.Push(c);
            }

            bool isReverse = true;

            foreach (char c in s2)
            {
                if ((char)stack.Pop() != c)
                {
                    isReverse = false;
                    break;
                }
            }

            if (isReverse)
                Console.WriteLine("Результат: Так, рядок s2 є зворотним до s1.");
            else
                Console.WriteLine("Результат: Ні, рядок s2 НЕ є зворотним до s1.");
        }
    }

    public class Lab9T2
    {
        public void Run()
        {
            Console.WriteLine("\n--- Завдання 2.4: Сортування чисел з файлу через Чергу ---");
            string fileName = "numbers.txt";

            if (!File.Exists(fileName))
            {
                File.WriteAllText(fileName, "15 -8 42 -4 0 7 -19 100 -2");
                Console.WriteLine($"[Створено тестовий файл {fileName} з числами]");
            }

            string text = File.ReadAllText(fileName);
            Console.WriteLine($"Вміст файлу: {text}");

            string[] tokens = text.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            Queue positiveQueue = new Queue();
            Queue negativeQueue = new Queue();

            foreach (string token in tokens)
            {
                if (int.TryParse(token, out int number))
                {
                    if (number >= 0)
                        positiveQueue.Enqueue(number);
                    else
                        negativeQueue.Enqueue(number);
                }
            }

            Console.Write("Результат (спочатку додатні, потім від'ємні): ");
            while (positiveQueue.Count > 0)
            {
                Console.Write(positiveQueue.Dequeue() + " ");
            }
            while (negativeQueue.Count > 0)
            {
                Console.Write(negativeQueue.Dequeue() + " ");
            }
            Console.WriteLine();
        }
    }

    public class Lab9T3
    {
        public void Run()
        {
            Console.WriteLine("\n--- Завдання 3: Ті ж задачі, але через ArrayList ---");

            Console.WriteLine("\n[Підзадача 1: Зворотній рядок]");
            Console.Write("Введіть рядок s1: ");
            string s1 = Console.ReadLine();
            Console.Write("Введіть рядок s2: ");
            string s2 = Console.ReadLine();

            ArrayList list1 = new ArrayList();
            foreach (char c in s1) list1.Add(c);

            list1.Reverse();

            string reversedS1 = "";
            foreach (char c in list1) reversedS1 += c;

            if (reversedS1 == s2)
                Console.WriteLine("Результат: Так, рядок s2 є зворотним до s1.");
            else
                Console.WriteLine("Результат: Ні, рядок s2 НЕ є зворотним до s1.");

            Console.WriteLine("\n[Підзадача 2: Числа з файлу]");
            string fileName = "numbers.txt";
            if (File.Exists(fileName))
            {
                string text = File.ReadAllText(fileName);
                string[] tokens = text.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                ArrayList posList = new ArrayList();
                ArrayList negList = new ArrayList();

                foreach (string token in tokens)
                {
                    if (int.TryParse(token, out int num))
                    {
                        if (num >= 0) posList.Add(num);
                        else negList.Add(num);
                    }
                }

                Console.Write("Результат: ");
                foreach (int n in posList) Console.Write(n + " ");
                foreach (int n in negList) Console.Write(n + " ");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Файл numbers.txt не знайдено. Спочатку виконайте Завдання 2.");
            }
        }
    }

    public class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public override string ToString() => $"'{Title}' (Виконавець: {Artist})";
    }

    public class Lab9T4
    {
        private Hashtable catalog = new Hashtable();

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n--- КАТАЛОГ КОМПАКТ-ДИСКІВ (Hashtable) ---");
                Console.WriteLine("1. Додати диск");
                Console.WriteLine("2. Видалити диск");
                Console.WriteLine("3. Додати пісню на диск");
                Console.WriteLine("4. Видалити пісню з диска");
                Console.WriteLine("5. Переглянути весь каталог");
                Console.WriteLine("6. Переглянути один диск");
                Console.WriteLine("7. Пошук пісень за виконавцем");
                Console.WriteLine("0. Повернутися до головного меню");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddDisk(); break;
                    case "2": RemoveDisk(); break;
                    case "3": AddSong(); break;
                    case "4": RemoveSong(); break;
                    case "5": ViewCatalog(); break;
                    case "6": ViewDisk(); break;
                    case "7": SearchArtist(); break;
                    case "0": return;
                    default: Console.WriteLine("Невірний вибір."); break;
                }
            }
        }

        private void AddDisk()
        {
            Console.Write("Введіть назву нового диска: ");
            string diskName = Console.ReadLine();
            if (!catalog.ContainsKey(diskName))
            {
                catalog.Add(diskName, new ArrayList());
                Console.WriteLine($"Диск '{diskName}' успішно додано.");
            }
            else Console.WriteLine("Диск з такою назвою вже існує!");
        }

        private void RemoveDisk()
        {
            Console.Write("Введіть назву диска для видалення: ");
            string diskName = Console.ReadLine();
            if (catalog.ContainsKey(diskName))
            {
                catalog.Remove(diskName);
                Console.WriteLine($"Диск '{diskName}' видалено.");
            }
            else Console.WriteLine("Диск не знайдено.");
        }

        private void AddSong()
        {
            Console.Write("Введіть назву диска: ");
            string diskName = Console.ReadLine();
            if (catalog.ContainsKey(diskName))
            {
                Console.Write("Введіть назву пісні: ");
                string title = Console.ReadLine();
                Console.Write("Введіть ім'я виконавця: ");
                string artist = Console.ReadLine();

                ArrayList songs = (ArrayList)catalog[diskName];
                songs.Add(new Song { Title = title, Artist = artist });
                Console.WriteLine("Пісню додано.");
            }
            else Console.WriteLine("Диск не знайдено.");
        }

        private void RemoveSong()
        {
            Console.Write("Введіть назву диска: ");
            string diskName = Console.ReadLine();
            if (catalog.ContainsKey(diskName))
            {
                Console.Write("Введіть назву пісні для видалення: ");
                string title = Console.ReadLine();
                ArrayList songs = (ArrayList)catalog[diskName];

                Song toRemove = null;
                foreach (Song s in songs)
                {
                    if (s.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                    {
                        toRemove = s;
                        break;
                    }
                }

                if (toRemove != null)
                {
                    songs.Remove(toRemove);
                    Console.WriteLine("Пісню видалено.");
                }
                else Console.WriteLine("Пісню не знайдено на цьому диску.");
            }
            else Console.WriteLine("Диск не знайдено.");
        }

        private void ViewCatalog()
        {
            if (catalog.Count == 0) { Console.WriteLine("Каталог порожній."); return; }

            Console.WriteLine("\nВМІСТ КАТАЛОГУ:");
            foreach (DictionaryEntry entry in catalog)
            {
                string diskName = (string)entry.Key;
                ArrayList songs = (ArrayList)entry.Value;
                Console.WriteLine($"Диск: [{diskName}] (Пісень: {songs.Count})");
                foreach (Song s in songs)
                {
                    Console.WriteLine($"  - {s}");
                }
            }
        }

        private void ViewDisk()
        {
            Console.Write("Введіть назву диска: ");
            string diskName = Console.ReadLine();
            if (catalog.ContainsKey(diskName))
            {
                ArrayList songs = (ArrayList)catalog[diskName];
                Console.WriteLine($"\nВміст диска [{diskName}]:");
                if (songs.Count == 0) Console.WriteLine("  (Диск порожній)");
                foreach (Song s in songs)
                {
                    Console.WriteLine($"  - {s}");
                }
            }
            else Console.WriteLine("Диск не знайдено.");
        }

        private void SearchArtist()
        {
            Console.Write("Введіть ім'я виконавця для пошуку: ");
            string artist = Console.ReadLine();
            bool found = false;

            Console.WriteLine($"\nРезультати пошуку для '{artist}':");
            foreach (DictionaryEntry entry in catalog)
            {
                string diskName = (string)entry.Key;
                ArrayList songs = (ArrayList)entry.Value;
                foreach (Song s in songs)
                {
                    if (s.Artist.Equals(artist, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"  - Пісня '{s.Title}' знайдена на диску [{diskName}]");
                        found = true;
                    }
                }
            }
            if (!found) Console.WriteLine("Пісень цього виконавця не знайдено.");
        }
    }
}
