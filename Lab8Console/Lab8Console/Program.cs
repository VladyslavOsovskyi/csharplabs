using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab8Console
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\n================ ЛАБОРАТОРНА РОБОТА №8 ================");
                Console.WriteLine("1. Завдання 1.14 (Координати вектора)");
                Console.WriteLine("2. Завдання 2.14 (Видалення ідентифікаторів)");
                Console.WriteLine("3. Завдання 3.14 (Вставка тексту після слова)");
                Console.WriteLine("4. Завдання 4.14 (Двійковий файл, символи без пунктуації)");
                Console.WriteLine("5. Завдання 5 (Робота з файловою системою)");
                Console.WriteLine("0. Вихід");
                Console.Write("Виберіть завдання (0-5): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": Task1(); break;
                    case "2": Task2(); break;
                    case "3": Task3(); break;
                    case "4": Task4(); break;
                    case "5": Task5(); break;
                    case "0": return;
                    default: Console.WriteLine("Невірний вибір. Спробуйте ще раз."); break;
                }
            }
        }

        static void Task1()
        {
            string inputFile = "task1.txt";
            string outputFile = "task1_out.txt";

            if (!File.Exists(inputFile))
                File.WriteAllText(inputFile, "Точка A має вектор (10; -5; 0), а точка B лежить на (-3; 4; 15). Тут є ще текст.");

            string text = File.ReadAllText(inputFile);
            Console.WriteLine($"\n[Початковий текст]: {text}");

            string pattern = @"\(\s*-?\d+\s*;\s*-?\d+\s*;\s*-?\d+\s*\)";
            MatchCollection matches = Regex.Matches(text, pattern);

            Console.WriteLine($"[Знайдено векторів]: {matches.Count}");
            foreach (Match m in matches)
            {
                Console.WriteLine($" - {m.Value}");
            }

            string newText = Regex.Replace(text, pattern, "[ВЕКТОР_ВИДАЛЕНО]");
            File.WriteAllText(outputFile, newText);

            Console.WriteLine($"[Результат записано у файл {outputFile}]: {newText}");
        }

        static void Task2()
        {
            string inputFile = "task2.txt";
            string outputFile = "task2_out.txt";

            if (!File.Exists(inputFile))
                File.WriteAllText(inputFile, "Тут є змінні: int _myVar1 = 10; string textValue; та просто слова українською.");

            string text = File.ReadAllText(inputFile);
            Console.WriteLine($"\n[Початковий текст]: {text}");

            string pattern = @"\b[a-zA-Z_][a-zA-Z0-9_]*\b";

            string newText = Regex.Replace(text, pattern, "");
            File.WriteAllText(outputFile, newText);

            Console.WriteLine($"[Результат записано у файл {outputFile}]:\n{newText}");
        }

        static void Task3()
        {
            string inputFile = "task3.txt";
            string outputFile = "task3_out.txt";

            if (!File.Exists(inputFile))
                File.WriteAllText(inputFile, "Сьогодні гарна погода. Погода завжди впливає на настрій.");

            string text1 = File.ReadAllText(inputFile);
            Console.WriteLine($"\n[Текст 1 (з файлу)]: {text1}");

            Console.Write("Введіть слово, після якого вставляти текст: ");
            string targetWord = Console.ReadLine();

            Console.Write("Введіть Текст 2 (що вставляти): ");
            string text2 = Console.ReadLine();

            string pattern = $@"\b({targetWord})\b";
            string newText = Regex.Replace(text1, pattern, $"$1 {text2}");

            File.WriteAllText(outputFile, newText);
            Console.WriteLine($"[Результат записано у файл {outputFile}]:\n{newText}");
        }

        static void Task4()
        {
            Console.Write("\nВведіть пропозицію (речення): ");
            string sentence = Console.ReadLine();
            string datFile = "task4.dat";

            using (BinaryWriter bw = new BinaryWriter(new FileStream(datFile, FileMode.Create)))
            {
                foreach (char c in sentence)
                {

                    if (!char.IsPunctuation(c))
                    {
                        bw.Write(c);
                    }
                }
            }
            Console.WriteLine("Дані записано у двійковий файл.");

            Console.Write("[Вміст двійкового файлу]: ");
            using (BinaryReader br = new BinaryReader(new FileStream(datFile, FileMode.Open)))
            {

                while (br.BaseStream.Position != br.BaseStream.Length)
                {
                    char c = br.ReadChar();
                    Console.Write(c);
                }
            }
            Console.WriteLine();
        }

        static void Task5()
        {

            string baseDir = @"C:\temp24";

            Console.Write("\nВведіть ваше прізвище (щоб програма знайшла папки 1 та 2): ");
            string surname = Console.ReadLine();

            string dir1 = Path.Combine(baseDir, surname + "1");
            string dir2 = Path.Combine(baseDir, surname + "2");
            string dirAll = Path.Combine(baseDir, "ALL");

            try
            {

                if (!Directory.Exists(baseDir)) Directory.CreateDirectory(baseDir);
                Directory.CreateDirectory(dir1);
                Directory.CreateDirectory(dir2);
                Console.WriteLine($"[ОК] Знайдено або створено папки: {dir1} та {dir2}");

                string file1 = Path.Combine(dir1, "t1.txt");
                string file2 = Path.Combine(dir1, "t2.txt");

                File.WriteAllText(file1, "<Шевченко Степан Іванович, 2001> року народження, місце проживання <м. Суми>");
                File.WriteAllText(file2, "<Комар Сергій Федорович, 2000 > року народження, місце проживання <м. Київ>");
                Console.WriteLine("[ОК] Файли t1.txt та t2.txt створено в папці 1.");

                string file3 = Path.Combine(dir2, "t3.txt");
                string content1 = File.ReadAllText(file1);
                string content2 = File.ReadAllText(file2);
                File.WriteAllText(file3, content1 + "\n" + content2);
                Console.WriteLine("[ОК] Тексти злито у t3.txt в папці 2.");

                FileInfo fi1 = new FileInfo(file1);
                Console.WriteLine($"\n[Інфо {fi1.Name}]: Розмір {fi1.Length} байт, Створено: {fi1.CreationTime}");

                string newFile2 = Path.Combine(dir2, "t2.txt");
                if (File.Exists(newFile2)) File.Delete(newFile2);
                File.Move(file2, newFile2);

                string newFile1 = Path.Combine(dir2, "t1.txt");
                File.Copy(file1, newFile1, true);
                Console.WriteLine("[ОК] Файл t2.txt переміщено, а t1.txt скопійовано у папку 2.");

                if (Directory.Exists(dirAll)) Directory.Delete(dirAll, true);
                Directory.Move(dir2, dirAll);

                Directory.Delete(dir1, true);

                Console.WriteLine("[ОК] Папку 2 перейменовано на ALL. Папку 1 видалено.");

                Console.WriteLine("\n[Повна інформація про папку ALL]:");
                DirectoryInfo dirInfoAll = new DirectoryInfo(dirAll);
                foreach (FileInfo f in dirInfoAll.GetFiles())
                {
                    Console.WriteLine($"- {f.Name} ({f.Length} байт), Змінено: {f.LastWriteTime}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[ПОМИЛКА]: {ex.Message}");
                Console.WriteLine("Перевірте, чи правильно введено прізвище, щоб воно співпадало з назвою папок!");
            }
        }
    }
}