using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10Console
{
    class Program
    {

        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("================ ЛАБОРАТОРНА РОБОТА №10 ================");
            Console.WriteLine("Тема: Події. Варіант 4: Життя коня (+ Асинхронність, Черги, Пріоритети)");
            Console.WriteLine("========================================================\n");

            Lab10T2 lab10task2 = new Lab10T2();
            await lab10task2.RunAsync();

            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }

    public enum Priority { Low, Normal, Critical }
    public enum NeedType { Food, Play, Health }

    public class HorseEventArgs : EventArgs
    {
        public NeedType Need { get; }
        public Priority TaskPriority { get; }
        public string Message { get; }
        public string Result { get; set; }

        public HorseEventArgs(NeedType need, Priority priority, string message)
        {
            Need = need;
            TaskPriority = priority;
            Message = message;
        }
    }

    public delegate void HorseEventHandler(object sender, HorseEventArgs e);

    public class Horse
    {
        public string Name { get; }
        private Random rnd = new Random();

        public event HorseEventHandler OnNeedHelp;

        public Horse(string name)
        {
            Name = name;
        }

        public void LiveOneDay(int day)
        {
            Console.WriteLine($"\n[День {day}] Сонце встало. Кінь {Name} гуляє в леваді...");

            int chance = rnd.Next(1, 100);

            if (chance < 15)

            {
                TriggerEvent(NeedType.Health, Priority.Critical, $"Кінь {Name} шкутильгає! Потрібен ветеринар.");
            }
            else if (chance < 50)

            {
                TriggerEvent(NeedType.Food, Priority.Normal, $"Кінь {Name} голодний. Б'є копитом об годівницю.");
            }
            else if (chance < 80)

            {
                TriggerEvent(NeedType.Play, Priority.Low, $"Кінь {Name} нудьгує і хоче бігати.");
            }
            else
            {
                Console.WriteLine($"[Спокій] Кінь {Name} мирно пасеться. Потреб немає.");
            }
        }

        protected virtual void TriggerEvent(NeedType need, Priority priority, string message)
        {
            if (OnNeedHelp != null)
            {
                HorseEventArgs args = new HorseEventArgs(need, priority, message);
                OnNeedHelp(this, args);

            }
        }
    }

    public class StableDispatcher
    {

        private List<HorseEventArgs> eventQueue = new List<HorseEventArgs>();

        private Dictionary<NeedType, int> statistics = new Dictionary<NeedType, int>
        {
            { NeedType.Food, 0 },
            { NeedType.Play, 0 },
            { NeedType.Health, 0 }
        };

        public void HandleHorseEvent(object sender, HorseEventArgs e)
        {
            Console.WriteLine($"[ПОДІЯ]: {e.Message} (Пріоритет: {e.TaskPriority})");
            eventQueue.Add(e);

        }

        public async Task ProcessQueueAsync()
        {
            if (eventQueue.Count == 0) return;

            eventQueue = eventQueue.OrderByDescending(e => e.TaskPriority).ToList();

            Console.WriteLine($"\n--- Початок роботи служб стайні (В черзі завдань: {eventQueue.Count}) ---");

            foreach (var task in eventQueue)
            {
                switch (task.Need)
                {
                    case NeedType.Health:
                        Console.WriteLine(">> [Ветеринар] виїхав на виклик...");
                        await Task.Delay(1000);

                        task.Result = "Успішно поліковано.";
                        Console.WriteLine($"<< [Ветеринар] завершив роботу: {task.Result}");
                        break;

                    case NeedType.Food:
                        Console.WriteLine(">> [Конюх] несе овес та сіно...");
                        await Task.Delay(500);

                        task.Result = "Коня нагодовано.";
                        Console.WriteLine($"<< [Конюх] завершив роботу: {task.Result}");
                        break;

                    case NeedType.Play:
                        Console.WriteLine(">> [Тренер] бере сідло для тренування...");
                        await Task.Delay(300);

                        task.Result = "Кінь побігав і щасливий.";
                        Console.WriteLine($"<< [Тренер] завершив роботу: {task.Result}");
                        break;
                }

                statistics[task.Need]++;
            }

            eventQueue.Clear();
            Console.WriteLine("--- Всі завдання виконано ---\n");
        }

        public void PrintStatistics()
        {
            Console.WriteLine("================ СТАТИСТИКА ЗА МІСЯЦЬ ================");
            Console.WriteLine($"Кількість годувань (Середній пріоритет): {statistics[NeedType.Food]}");
            Console.WriteLine($"Кількість тренувань/ігор (Низький пріоритет): {statistics[NeedType.Play]}");
            Console.WriteLine($"Виклики ветеринара (Критичний пріоритет): {statistics[NeedType.Health]}");
            Console.WriteLine("======================================================");
        }
    }

    public class Lab10T2
    {
        public async Task RunAsync()
        {
            Horse myHorse = new Horse("Орлик");
            StableDispatcher stable = new StableDispatcher();

            myHorse.OnNeedHelp += stable.HandleHorseEvent;

            int daysToSimulate = 10;

            for (int day = 1; day <= daysToSimulate; day++)
            {

                myHorse.LiveOneDay(day);

                await stable.ProcessQueueAsync();

                await Task.Delay(200);

            }

            myHorse.OnNeedHelp -= stable.HandleHorseEvent;

            stable.PrintStatistics();
        }
    }
}
