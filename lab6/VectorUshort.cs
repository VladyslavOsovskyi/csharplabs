using System;
using System.Collections; 

namespace Lab6_OOP
{

    class VectorUshort : IEnumerable
    {
        protected ushort[] ArrayUShort;
        protected uint num;
        protected uint codeError;
        protected static uint num_vs = 0;

        public VectorUshort(uint size, ushort initValue)
        {
            num = size;
            ArrayUShort = new ushort[num];
            for (int i = 0; i < num; i++) ArrayUShort[i] = initValue;
            num_vs++;
        }

        public ushort this[int index]
        {
            get
            {
                if (index < 0 || index >= num) { codeError = 1; return 0; }
                return ArrayUShort[index];
            }
            set
            {
                if (index < 0 || index >= num) codeError = 1;
                else ArrayUShort[index] = value;
            }
        }

        public void Print(string name = "Vector")
        {
            Console.Write($"{name}: [ ");
            for (int i = 0; i < num; i++) Console.Write(ArrayUShort[i] + " ");
            Console.WriteLine("]");
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < num; i++)
            {

                yield return ArrayUShort[i];
            }
        }
    }
}
