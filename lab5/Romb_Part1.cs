using System;

namespace Lab5_OOP
{

    sealed partial class Romb
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

        public int Side { get { return a; } }
        public int Diagonal { get { return d1; } }
        public int Color { get { return c; } }
    }
}
