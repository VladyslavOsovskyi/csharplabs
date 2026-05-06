using System;

namespace Lab6_OOP
{

    public class VectorMathException : Exception
    {
        public VectorMathException(string message) : base(message) { }
    }

    class Program3
    {
        public static void Task3()
        {
            Console.WriteLine("\n--- ЗАВДАННЯ 3: Обробка винятків (Помилок) ---");

            Console.WriteLine("Сценарій 1: Спроба неправильного перетворення типів...");
            try
            {
                object myData = "Текстовий рядок";

                int number = (int)myData;
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine($"[ПЕРЕХОПЛЕНО СТАНДАРТНУ ПОМИЛКУ]: {ex.Message}");
            }

            Console.WriteLine("\nСценарій 2: Симуляція математичної помилки у векторі...");
            try
            {
                int vectorSize = -5;

                if (vectorSize < 0)
                {

                    throw new VectorMathException("Розмір вектора не може бути меншим за нуль!");
                }
            }
            catch (VectorMathException ex)
            {
                Console.WriteLine($"[ПЕРЕХОПЛЕНО ВЛАСНУ ПОМИЛКУ]: {ex.Message}");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"[НЕВІДОМА ПОМИЛКА]: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\n[Блок Finally] Завершення перевірки помилок. Звільнення ресурсів.");
            }

            Console.WriteLine("----------------------------------------------\n");
        }
    }
}
