using Lab4_OOP;
using System;

namespace Lab4_OOP
{
    class VectorUshort
    {
        protected ushort[] ArrayUShort;
        protected uint num;
        protected uint codeError;
        protected static uint num_vs = 0;

        public VectorUshort()
        {
            num = 1;
            ArrayUShort = new ushort[num];
            ArrayUShort[0] = 0;
            num_vs++;
        }

        public VectorUshort(uint size)
        {
            num = size;
            ArrayUShort = new ushort[num];
            for (int i = 0; i < num; i++) ArrayUShort[i] = 0;
            num_vs++;
        }

        public VectorUshort(uint size, ushort initValue)
        {
            num = size;
            ArrayUShort = new ushort[num];
            for (int i = 0; i < num; i++) ArrayUShort[i] = initValue;
            num_vs++;
        }

        ~VectorUshort()
        {
            Console.WriteLine("Деструктор VectorUshort викликано.");
        }

        public uint Size => num;

        public uint CodeError
        {
            get => codeError;
            set => codeError = value;
        }
        public ushort this[int index]
        {
            get
            {
                if (index < 0 || index >= num)
                {
                    codeError = 1;
                    return 0;
                }
                return ArrayUShort[index];
            }
            set
            {
                if (index < 0 || index >= num)
                {
                    codeError = 1;
                }
                else
                {
                    ArrayUShort[index] = value;
                }
            }
        }

        public void Input()
        {
            Console.WriteLine($"Введіть {num} елементів вектора (ushort):");
            for (int i = 0; i < num; i++)
            {
                Console.Write($"v[{i}] = ");
                ArrayUShort[i] = ushort.Parse(Console.ReadLine());
            }
        }

        public void Print(string name = "Vector")
        {
            Console.Write($"{name}: [ ");
            for (int i = 0; i < num; i++) Console.Write(ArrayUShort[i] + " ");
            Console.WriteLine("]");
        }

        public void SetAll(ushort value)
        {
            for (int i = 0; i < num; i++) ArrayUShort[i] = value;
        }

        public static uint CountVectors()
        {
            return num_vs;
        }

        public static VectorUshort operator ++(VectorUshort v)
        {
            VectorUshort res = new VectorUshort(v.num);
            for (int i = 0; i < v.num; i++) res[i] = (ushort)(v[i] + 1);
            return res;
        }

        public static VectorUshort operator --(VectorUshort v)
        {
            VectorUshort res = new VectorUshort(v.num);
            for (int i = 0; i < v.num; i++) res[i] = (ushort)(v[i] - 1);
            return res;
        }

        public static bool operator true(VectorUshort v)
        {
            if (v.num == 0) return false;
            for (int i = 0; i < v.num; i++)
            {
                if (v[i] == 0) return false;
            }
            return true;
        }

        public static bool operator false(VectorUshort v)
        {
            if (v.num == 0) return true;
            for (int i = 0; i < v.num; i++)
            {
                if (v[i] == 0) return true;
            }
            return false;
        }

        public static bool operator !(VectorUshort v)
        {
            return v.num != 0;
        }

        public static VectorUshort operator ~(VectorUshort v)
        {
            VectorUshort res = new VectorUshort(v.num);
            for (int i = 0; i < v.num; i++) res[i] = (ushort)(~v[i]);
            return res;
        }

        private static VectorUshort BinaryOp(VectorUshort v1, VectorUshort v2, Func<ushort, ushort, ushort> op)
        {
            uint maxLen = Math.Max(v1.num, v2.num);
            VectorUshort res = new VectorUshort(maxLen);
            for (int i = 0; i < maxLen; i++)
            {
                ushort val1 = (i < v1.num) ? v1[i] : (ushort)0;
                ushort val2 = (i < v2.num) ? v2[i] : (ushort)0;
                res[i] = op(val1, val2);
            }
            return res;
        }

        private static VectorUshort ScalarOp(VectorUshort v, ushort scalar, Func<ushort, ushort, ushort> op)
        {
            VectorUshort res = new VectorUshort(v.num);
            for (int i = 0; i < v.num; i++) res[i] = op(v[i], scalar);
            return res;
        }

        public static VectorUshort operator +(VectorUshort v1, VectorUshort v2) => BinaryOp(v1, v2, (a, b) => (ushort)(a + b));
        public static VectorUshort operator +(VectorUshort v, ushort s) => ScalarOp(v, s, (a, b) => (ushort)(a + b));

        public static VectorUshort operator -(VectorUshort v1, VectorUshort v2) => BinaryOp(v1, v2, (a, b) => (ushort)(a - b));
        public static VectorUshort operator -(VectorUshort v, ushort s) => ScalarOp(v, s, (a, b) => (ushort)(a - b));

        public static VectorUshort operator *(VectorUshort v1, VectorUshort v2) => BinaryOp(v1, v2, (a, b) => (ushort)(a * b));
        public static VectorUshort operator *(VectorUshort v, ushort s) => ScalarOp(v, s, (a, b) => (ushort)(a * b));

        public static VectorUshort operator /(VectorUshort v1, VectorUshort v2) => BinaryOp(v1, v2, (a, b) => b == 0 ? (ushort)0 : (ushort)(a / b));
        public static VectorUshort operator /(VectorUshort v, ushort s) => ScalarOp(v, s, (a, b) => b == 0 ? (ushort)0 : (ushort)(a / b));

        public static VectorUshort operator %(VectorUshort v1, VectorUshort v2) => BinaryOp(v1, v2, (a, b) => b == 0 ? (ushort)0 : (ushort)(a % b));
        public static VectorUshort operator %(VectorUshort v, ushort s) => ScalarOp(v, s, (a, b) => b == 0 ? (ushort)0 : (ushort)(a % b));

        public static VectorUshort operator |(VectorUshort v1, VectorUshort v2) => BinaryOp(v1, v2, (a, b) => (ushort)(a | b));
        public static VectorUshort operator |(VectorUshort v, ushort s) => ScalarOp(v, s, (a, b) => (ushort)(a | b));

        public static VectorUshort operator ^(VectorUshort v1, VectorUshort v2) => BinaryOp(v1, v2, (a, b) => (ushort)(a ^ b));
        public static VectorUshort operator ^(VectorUshort v, ushort s) => ScalarOp(v, s, (a, b) => (ushort)(a ^ b));

        public static VectorUshort operator &(VectorUshort v1, VectorUshort v2) => BinaryOp(v1, v2, (a, b) => (ushort)(a & b));
        public static VectorUshort operator &(VectorUshort v, ushort s) => ScalarOp(v, s, (a, b) => (ushort)(a & b));

        public static VectorUshort operator >>(VectorUshort v1, int shift) => ScalarOp(v1, (ushort)shift, (a, b) => (ushort)(a >> b));
        public static VectorUshort operator <<(VectorUshort v1, int shift) => ScalarOp(v1, (ushort)shift, (a, b) => (ushort)(a << b));

        public static bool operator ==(VectorUshort v1, VectorUshort v2)
        {
            if (ReferenceEquals(v1, null) || ReferenceEquals(v2, null)) return ReferenceEquals(v1, v2);
            if (v1.num != v2.num) return false;
            for (int i = 0; i < v1.num; i++) if (v1[i] != v2[i]) return false;
            return true;
        }

        public static bool operator !=(VectorUshort v1, VectorUshort v2) => !(v1 == v2);

        public static bool operator >(VectorUshort v1, VectorUshort v2)
        {
            uint minLen = Math.Min(v1.num, v2.num);
            for (int i = 0; i < minLen; i++) if (v1[i] <= v2[i]) return false;
            return true;
        }

        public static bool operator <(VectorUshort v1, VectorUshort v2)
        {
            uint minLen = Math.Min(v1.num, v2.num);
            for (int i = 0; i < minLen; i++) if (v1[i] >= v2[i]) return false;
            return true;
        }

        public static bool operator >=(VectorUshort v1, VectorUshort v2)
        {
            uint minLen = Math.Min(v1.num, v2.num);
            for (int i = 0; i < minLen; i++) if (v1[i] < v2[i]) return false;
            return true;
        }

        public static bool operator <=(VectorUshort v1, VectorUshort v2)
        {
            uint minLen = Math.Min(v1.num, v2.num);
            for (int i = 0; i < minLen; i++) if (v1[i] > v2[i]) return false;
            return true;
        }

        public override bool Equals(object obj) => this == (obj as VectorUshort);
        public override int GetHashCode() => ArrayUShort.GetHashCode();
    }
}
class Program2
{
    public static void Task2()
    {
        Console.WriteLine("\n--- ТЕСТУВАННЯ ЗАВДАННЯ 2 (VectorUshort) ---");

        VectorUshort v1 = new VectorUshort(3, 10);
        VectorUshort v2 = new VectorUshort(3, 5);

        v1.Print("Вектор 1");
        v2.Print("Вектор 2");

        Console.WriteLine("\nАрифметичні операції:");
        VectorUshort vAdd = v1 + v2;
        vAdd.Print("v1 + v2");

        VectorUshort vSubScalar = v1 - (ushort)2;
        vSubScalar.Print("v1 - 2 (Скаляр)");

        Console.WriteLine("\nУнарні операції:");
        VectorUshort vInc = ++v2;
        vInc.Print("++v2");

        Console.WriteLine("\nПобітові операції:");
        VectorUshort vShift = v1 >> 1;
        vShift.Print("v1 >> 1");

        Console.WriteLine("\nПорівняння:");
        Console.WriteLine($"v1 > v2 : {v1 > v2}");
        Console.WriteLine($"v1 == v2 : {v1 == v2}");

        Console.WriteLine($"\nВсього створено векторів: {VectorUshort.CountVectors()}");
        Console.WriteLine("-----------------------------\n");
    }
}
