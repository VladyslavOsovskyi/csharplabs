using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4_OOP
{
    struct StadiumStruct
    {
        public string Name;
        public string Address;
        public int Capacity;
        public string Sports;

        public StadiumStruct(string n, string a, int c, string s)
        {
            Name = n; Address = a; Capacity = c; Sports = s;
        }

        public override string ToString() => $"[Структура] {Name}, {Address} | Місткість: {Capacity} | Види: {Sports}";
    }

    record StadiumRecord(string Name, string Address, int Capacity, string Sports)
    {
        public override string ToString() => $"[Запис] {Name}, {Address} | Місткість: {Capacity} | Види: {Sports}";
    }

    class Program3
    {
        public static void Task3()
        {
            Console.WriteLine("\n--- ЗАВДАННЯ 3.14: СТАДІОНИ (Трьома способами) ---\n");

            RunStructDemo();
            RunTupleDemo();
            RunRecordDemo();

            Console.WriteLine("--------------------------------------------------\n");
        }
        static void RunStructDemo()
        {
            Console.WriteLine(">>> СПОСІБ 1: СТРУКТУРИ (STRUCT)");
            List<StadiumStruct> list = new List<StadiumStruct>
            {
                new StadiumStruct("Олімпійський", "Київ", 70000, "Футбол, Атлетика"),
                new StadiumStruct("Арена Львів", "Львів", 34000, "Футбол"),
                new StadiumStruct("Динамо", "Київ", 16000, "Футбол")
            };

            string nameToRemove = "Арена Львів";
            list.RemoveAll(s => s.Name == nameToRemove);
            Console.WriteLine($"Видалено стадіон '{nameToRemove}'");

            int targetIndex = 0;
            if (targetIndex >= 0 && targetIndex < list.Count)
            {
                list.Insert(targetIndex + 1, new StadiumStruct("Спартак", "Одеса", 10000, "Регбі"));
                list.Insert(targetIndex + 2, new StadiumStruct("Авангард", "Ужгород", 12000, "Футбол"));
            }

            foreach (var item in list) Console.WriteLine(item);
            Console.WriteLine();
        }
        static void RunTupleDemo()
        {
            Console.WriteLine(">>> СПОСІБ 2: КОРТЕЖІ (TUPLE)");
            List<(string Name, string Address, int Capacity, string Sports)> list = new List<(string, string, int, string)>
            {
                ("Олімпійський", "Київ", 70000, "Футбол, Атлетика"),
                ("Арена Львів", "Львів", 34000, "Футбол"),
                ("Динамо", "Київ", 16000, "Футбол")
            };

            string nameToRemove = "Арена Львів";
            list.RemoveAll(s => s.Name == nameToRemove);
            int targetIndex = 0;
            if (targetIndex >= 0 && targetIndex < list.Count)
            {
                list.Insert(targetIndex + 1, ("Спартак", "Одеса", 10000, "Регбі"));
                list.Insert(targetIndex + 2, ("Авангард", "Ужгород", 12000, "Футбол"));
            }

            foreach (var item in list)
                Console.WriteLine($"[Кортеж] {item.Name}, {item.Address} | Місткість: {item.Capacity} | Види: {item.Sports}");
            Console.WriteLine();
        }
        static void RunRecordDemo()
        {
            Console.WriteLine(">>> СПОСІБ 3: ЗАПИСИ (RECORD)");
            List<StadiumRecord> list = new List<StadiumRecord>
            {
                new StadiumRecord("Олімпійський", "Київ", 70000, "Футбол, Атлетика"),
                new StadiumRecord("Арена Львів", "Львів", 34000, "Футбол"),
                new StadiumRecord("Динамо", "Київ", 16000, "Футбол")
            };

            string nameToRemove = "Арена Львів";
            list.RemoveAll(s => s.Name == nameToRemove);

            int targetIndex = 0;
            if (targetIndex >= 0 && targetIndex < list.Count)
            {
                list.Insert(targetIndex + 1, new StadiumRecord("Спартак", "Одеса", 10000, "Регбі"));
                list.Insert(targetIndex + 2, new StadiumRecord("Авангард", "Ужгород", 12000, "Футбол"));
            }

            foreach (var item in list) Console.WriteLine(item);
            Console.WriteLine();
        }
    }
}
