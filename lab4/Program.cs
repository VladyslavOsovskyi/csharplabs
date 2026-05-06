using System;
using System.Text;

namespace Lab4_OOP
{
    class Romb
    {
        protected int a;
        protected int d1;
        protected int c;

        public Romb(int side, int diag, int color)
        {
            if (diag >= 2 * side)
                throw new ArgumentException("Такий ромб не може існувати!");
            a = side;
            d1 = diag;
            c = color;
        }

        public void Print()
        {
            Console.WriteLine($"Ромб: Сторона={a}, Діагональ={d1}, Колір={c}");
        }

        public bool IsSquare()
        {
            return (d1 * d1 == 2 * a * a);
        }

        public int this[int index]
        {
            get
            {
                return index switch
                {
                    0 => a,
                    1 => d1,
                    2 => c,
                    _ => throw new IndexOutOfRangeException("Помилка! Індекс має бути 0, 1 або 2.")
                };
            }
            set
            {
                if (index == 0) a = value;
                else if (index == 1) d1 = value;
                else if (index == 2) c = value;
                else throw new IndexOutOfRangeException("Помилка! Індекс має бути 0, 1 або 2.");
            }
        }

        // 2. ПЕРЕВАНТАЖЕННЯ ++ та --
        public static Romb operator ++(Romb r)
        {
            return new Romb(r.a + 1, r.d1 + 1, r.c);
        }

        public static Romb operator --(Romb r)
        {
            return new Romb(r.a - 1, r.d1 - 1, r.c);
        }
        public static bool operator true(Romb r)
        {
            return r.IsSquare();
        }

        public static bool operator false(Romb r)
        {
            return !r.IsSquare();
        }

        public static Romb operator *(Romb r, int scalar)
        {
            return new Romb(r.a * scalar, r.d1 * scalar, r.c);
        }
        public static implicit operator string(Romb r)
        {
            return $"{r.a},{r.d1},{r.c}";
        }

        public static explicit operator Romb(string str)
        {
            string[] parts = str.Split(',');
            if (parts.Length != 3) throw new FormatException("Рядок має бути у форматі 'a,d1,c'");
            return new Romb(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\n=============================");
                Console.WriteLine("       ЛАБОРАТОРНА №4        ");
                Console.WriteLine("=============================");
                Console.WriteLine("1 - Завдання 1 (Перевантаження Romb)");
                Console.WriteLine("2 - Завдання 2 (VectorUshort)");
                Console.WriteLine("3 - Завдання 3 (Стадіони)");
                Console.WriteLine("4 - Завдання 4 (MatrixUshort)");
                Console.WriteLine("0 - Вихід");
                Console.WriteLine("=============================");
                Console.Write("Оберіть номер: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": Task1(); break;
                    case "2":
                        Program2.Task2();
                        break;
                    case "3":
                        Program3.Task3();
                        break;
                    case "4":
                        Program4.Task4();
                        break;
                    case "0": return;
                    default: Console.WriteLine("В розробці або помилка."); break;
                }
            }
        }

        static void Task1()
        {
            Console.WriteLine("\n--- ТЕСТУВАННЯ ЗАВДАННЯ 1 ---");
            Romb r = new Romb(5, 6, 1);
            r.Print();

            Console.WriteLine("\n1. Індексатор:");
            Console.WriteLine($"Індекс 0 (Сторона) = {r[0]}");
            Console.WriteLine($"Індекс 2 (Колір) = {r[2]}");
            r[0] = 10; r[1] = 12; // Змінюємо через індексатор
            r.Print();

            Console.WriteLine("\n2. Перевантаження ++:");
            r++;
            r.Print();

            Console.WriteLine("\n3. Перевантаження true/false:");
            if (r) Console.WriteLine("Цей ромб є квадратом.");
            else Console.WriteLine("Цей ромб НЕ є квадратом.");

            Console.WriteLine("\n4. Перевантаження * (на 2):");
            Romb r2 = r * 2;
            r2.Print();

            Console.WriteLine("\n5. Перетворення типів (String <-> Romb):");
            string s = r2;
            Console.WriteLine($"У вигляді рядка: {s}");

            Romb r3 = (Romb)"15,20,3";
            Console.Write("З рядка '15,20,3' створено: ");
            r3.Print();

            Console.WriteLine("-----------------------------\n");
        }
    }
}
