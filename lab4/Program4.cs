using System;

namespace Lab4_OOP
{
    class MatrixUshort
    {
        protected ushort[,] ShortIntArray;
        protected int n, m;
        protected int codeError;
        protected static int num_m = 0;

        public MatrixUshort()
        {
            n = 1; m = 1;
            ShortIntArray = new ushort[n, m];
            ShortIntArray[0, 0] = 0;
            num_m++;
        }

        public MatrixUshort(int rows, int cols)
        {
            n = rows; m = cols;
            ShortIntArray = new ushort[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    ShortIntArray[i, j] = 0;
            num_m++;
        }

        public MatrixUshort(int rows, int cols, ushort initValue)
        {
            n = rows; m = cols;
            ShortIntArray = new ushort[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    ShortIntArray[i, j] = initValue;
            num_m++;
        }

        ~MatrixUshort()
        {
            Console.WriteLine("Деструктор MatrixUshort викликано.");
        }

        // --- Властивості ---
        public int Rows => n;
        public int Cols => m;
        public int CodeError
        {
            get => codeError;
            set => codeError = value;
        }
        public ushort this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= n || j < 0 || j >= m) { codeError = -1; return 0; }
                return ShortIntArray[i, j];
            }
            set
            {
                if (i < 0 || i >= n || j < 0 || j >= m) { codeError = -1; }
                else ShortIntArray[i, j] = value;
            }
        }

        public ushort this[int k]
        {
            get
            {
                int i = k / m; int j = k % m;
                return this[i, j];
            }
            set
            {
                int i = k / m; int j = k % m;
                this[i, j] = value;
            }
        }

        public void Input()
        {
            Console.WriteLine($"Введіть елементи матриці ({n}x{m}):");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"a[{i},{j}] = ");
                    ShortIntArray[i, j] = ushort.Parse(Console.ReadLine());
                }
            }
        }

        public void Print(string name = "Matrix")
        {
            Console.WriteLine($"{name}:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{ShortIntArray[i, j],5} ");
                }
                Console.WriteLine();
            }
        }

        public void SetAll(ushort value)
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    ShortIntArray[i, j] = value;
        }

        public static int CountMatrices() => num_m;

        public static MatrixUshort operator ++(MatrixUshort mat)
        {
            MatrixUshort res = new MatrixUshort(mat.n, mat.m);
            for (int k = 0; k < mat.n * mat.m; k++) res[k] = (ushort)(mat[k] + 1);
            return res;
        }

        public static MatrixUshort operator --(MatrixUshort mat)
        {
            MatrixUshort res = new MatrixUshort(mat.n, mat.m);
            for (int k = 0; k < mat.n * mat.m; k++) res[k] = (ushort)(mat[k] - 1);
            return res;
        }

        public static bool operator true(MatrixUshort mat)
        {
            if (mat.n == 0 || mat.m == 0) return false;
            for (int k = 0; k < mat.n * mat.m; k++) if (mat[k] == 0) return false;
            return true;
        }

        public static bool operator false(MatrixUshort mat)
        {
            if (mat.n == 0 || mat.m == 0) return true;
            for (int k = 0; k < mat.n * mat.m; k++) if (mat[k] == 0) return true;
            return false;
        }

        public static bool operator !(MatrixUshort mat) => mat.n != 0 && mat.m != 0;

        public static MatrixUshort operator ~(MatrixUshort mat)
        {
            MatrixUshort res = new MatrixUshort(mat.n, mat.m);
            for (int k = 0; k < mat.n * mat.m; k++) res[k] = (ushort)(~mat[k]);
            return res;
        }

        private static MatrixUshort ElementWiseOp(MatrixUshort m1, MatrixUshort m2, Func<ushort, ushort, ushort> op)
        {
            if (m1.n != m2.n || m1.m != m2.m) return m1;

            MatrixUshort res = new MatrixUshort(m1.n, m1.m);
            for (int k = 0; k < m1.n * m1.m; k++) res[k] = op(m1[k], m2[k]);
            return res;
        }

        private static MatrixUshort ScalarOp(MatrixUshort mat, ushort scalar, Func<ushort, ushort, ushort> op)
        {
            MatrixUshort res = new MatrixUshort(mat.n, mat.m);
            for (int k = 0; k < mat.n * mat.m; k++) res[k] = op(mat[k], scalar);
            return res;
        }

        public static MatrixUshort operator +(MatrixUshort m1, MatrixUshort m2) => ElementWiseOp(m1, m2, (a, b) => (ushort)(a + b));
        public static MatrixUshort operator +(MatrixUshort mat, ushort s) => ScalarOp(mat, s, (a, b) => (ushort)(a + b));

        public static MatrixUshort operator -(MatrixUshort m1, MatrixUshort m2) => ElementWiseOp(m1, m2, (a, b) => (ushort)(a - b));
        public static MatrixUshort operator -(MatrixUshort mat, ushort s) => ScalarOp(mat, s, (a, b) => (ushort)(a - b));

        public static MatrixUshort operator /(MatrixUshort m1, MatrixUshort m2) => ElementWiseOp(m1, m2, (a, b) => b == 0 ? (ushort)0 : (ushort)(a / b));
        public static MatrixUshort operator /(MatrixUshort mat, ushort s) => ScalarOp(mat, s, (a, b) => b == 0 ? (ushort)0 : (ushort)(a / b));

        public static MatrixUshort operator %(MatrixUshort m1, MatrixUshort m2) => ElementWiseOp(m1, m2, (a, b) => b == 0 ? (ushort)0 : (ushort)(a % b));
        public static MatrixUshort operator %(MatrixUshort mat, ushort s) => ScalarOp(mat, s, (a, b) => b == 0 ? (ushort)0 : (ushort)(a % b));

        public static MatrixUshort operator |(MatrixUshort m1, MatrixUshort m2) => ElementWiseOp(m1, m2, (a, b) => (ushort)(a | b));
        public static MatrixUshort operator |(MatrixUshort mat, ushort s) => ScalarOp(mat, s, (a, b) => (ushort)(a | b));

        public static MatrixUshort operator ^(MatrixUshort m1, MatrixUshort m2) => ElementWiseOp(m1, m2, (a, b) => (ushort)(a ^ b));
        public static MatrixUshort operator ^(MatrixUshort mat, ushort s) => ScalarOp(mat, s, (a, b) => (ushort)(a ^ b));

        public static MatrixUshort operator &(MatrixUshort m1, MatrixUshort m2) => ElementWiseOp(m1, m2, (a, b) => (ushort)(a & b));
        public static MatrixUshort operator &(MatrixUshort mat, ushort s) => ScalarOp(mat, s, (a, b) => (ushort)(a & b));

        public static MatrixUshort operator >>(MatrixUshort mat, int shift) => ScalarOp(mat, (ushort)shift, (a, b) => (ushort)(a >> b));
        public static MatrixUshort operator <<(MatrixUshort mat, int shift) => ScalarOp(mat, (ushort)shift, (a, b) => (ushort)(a << b));

        public static MatrixUshort operator *(MatrixUshort m1, MatrixUshort m2)
        {
            if (m1.m != m2.n) return m1;
            MatrixUshort res = new MatrixUshort(m1.n, m2.m);
            for (int i = 0; i < m1.n; i++)
            {
                for (int j = 0; j < m2.m; j++)
                {
                    ushort sum = 0;
                    for (int k = 0; k < m1.m; k++) sum += (ushort)(m1[i, k] * m2[k, j]);
                    res[i, j] = sum;
                }
            }
            return res;
        }
        public static VectorUshort operator *(MatrixUshort mat, VectorUshort vec)
        {
            if (mat.m != vec.Size) return vec;
            VectorUshort res = new VectorUshort((uint)mat.n);
            for (int i = 0; i < mat.n; i++)
            {
                ushort sum = 0;
                for (int j = 0; j < mat.m; j++) sum += (ushort)(mat[i, j] * vec[j]);
                res[i] = sum;
            }
            return res;
        }

        public static MatrixUshort operator *(MatrixUshort mat, ushort scalar) => ScalarOp(mat, scalar, (a, b) => (ushort)(a * b));

        public static bool operator ==(MatrixUshort m1, MatrixUshort m2)
        {
            if (ReferenceEquals(m1, null) || ReferenceEquals(m2, null)) return ReferenceEquals(m1, m2);
            if (m1.n != m2.n || m1.m != m2.m) return false;
            for (int k = 0; k < m1.n * m1.m; k++) if (m1[k] != m2[k]) return false;
            return true;
        }

        public static bool operator !=(MatrixUshort m1, MatrixUshort m2) => !(m1 == m2);

        public static bool operator >(MatrixUshort m1, MatrixUshort m2)
        {
            if (m1.n != m2.n || m1.m != m2.m) return false;
            for (int k = 0; k < m1.n * m1.m; k++) if (m1[k] <= m2[k]) return false;
            return true;
        }

        public static bool operator <(MatrixUshort m1, MatrixUshort m2)
        {
            if (m1.n != m2.n || m1.m != m2.m) return false;
            for (int k = 0; k < m1.n * m1.m; k++) if (m1[k] >= m2[k]) return false;
            return true;
        }

        public static bool operator >=(MatrixUshort m1, MatrixUshort m2)
        {
            if (m1.n != m2.n || m1.m != m2.m) return false;
            for (int k = 0; k < m1.n * m1.m; k++) if (m1[k] < m2[k]) return false;
            return true;
        }

        public static bool operator <=(MatrixUshort m1, MatrixUshort m2)
        {
            if (m1.n != m2.n || m1.m != m2.m) return false;
            for (int k = 0; k < m1.n * m1.m; k++) if (m1[k] > m2[k]) return false;
            return true;
        }

        public override bool Equals(object obj) => this == (obj as MatrixUshort);
        public override int GetHashCode() => ShortIntArray.GetHashCode();
    }

    // Клас для тестування
    class Program4
    {
        public static void Task4()
        {
            Console.WriteLine("\n--- ТЕСТУВАННЯ ЗАВДАННЯ 4 (MatrixUshort) ---");

            MatrixUshort m1 = new MatrixUshort(2, 2, 5);
            MatrixUshort m2 = new MatrixUshort(2, 2, 2);

            m1[0, 1] = 10;
            m2[3] = 4;

            m1.Print("Матриця 1");
            m2.Print("Матриця 2");

            Console.WriteLine("\nДодавання (m1 + m2):");
            MatrixUshort mAdd = m1 + m2;
            mAdd.Print("Результат");

            Console.WriteLine("\nМноження матриць (m1 * m2):");
            MatrixUshort mMult = m1 * m2;
            mMult.Print("Результат");

            Console.WriteLine("\nМноження матриці на вектор (із Завдання 2):");
            VectorUshort v = new VectorUshort(2, 3);
            v.Print("Вектор");
            VectorUshort resVec = m1 * v;
            resVec.Print("Матриця * Вектор");

            Console.WriteLine($"\nВсього створено матриць: {MatrixUshort.CountMatrices()}");
            Console.WriteLine("-------------------------------------------\n");
        }
    }
}
