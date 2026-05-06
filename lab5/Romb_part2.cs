using System;

namespace Lab5_OOP
{

    sealed partial class Romb
    {
        public void Print()
        {
            Console.WriteLine($"Ромб: Сторона={a}, Діагональ={d1}, Колір={c}");
        }

        public bool IsSquare()
        {
            return (d1 * d1 == 2 * a * a);
        }

        public double Area()
        {
            double d2 = Math.Sqrt(4 * a * a - d1 * d1);
            return (d1 * d2) / 2.0;
        }

    }
}
