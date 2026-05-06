using System;

namespace Lab6_OOP
{
    class Program4
    {
        public static void Task4()
        {
            Console.WriteLine("\n--- ЗАВДАННЯ 4: Перебір об'єктів через foreach ---");
            VectorUshort myVector = new VectorUshort(5, 42);

            myVector[1] = 100;
            myVector[3] = 777;

            Console.WriteLine("Тепер ми можемо перебирати наш власний об'єкт через foreach!");
            Console.Write("Вміст вектора: ");

            foreach (ushort item in myVector)
            {
                Console.Write($"{item}  ");
            }

            Console.WriteLine("\n\n--------------------------------------------------\n");
        }
    }
}
