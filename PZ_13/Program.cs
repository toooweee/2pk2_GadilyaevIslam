namespace PZ_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задание 1
            Console.WriteLine($"Задание 1 \nВведите значение n:");
            double n = Convert.ToDouble(Console.ReadLine());
            double a1 = -1000;
            double d = -100;
            double An = getArithmeticProgression(a1, d, n);
            Console.WriteLine($"значение {n}-го члена: {An} ");
            Console.WriteLine();

            //задание 2
            Console.WriteLine($"Задание 2 \nВведите значение n:");
            double n2 = Convert.ToDouble(Console.ReadLine());
            double b1 = 7;
            double q = -0.2;
            double Bn = getGeometricProgression(b1, q, n2);
            Console.WriteLine($"значение {n}-го члена: {Bn} ");
            Console.WriteLine();

            //задание 3
            Console.WriteLine("задание 3");
            int A = 2;
            int B = 45;

            if (A < B)
            {
                getInter(A, B);
            }
            if (A > B)
            {
                getInter(A, B);
            }
            Console.WriteLine();


            //задание 4
            Console.WriteLine("Задание 4");
            Console.WriteLine("Введите число:");
            int v = Convert.ToInt32(Console.ReadLine());
            int summ = sum(v);
            Console.WriteLine($"Сумма чисел от одного до: {v}: \n{summ}");
        }

        // Метод для задания 1
        static double getArithmeticProgression(double a1, double d, double n)
        {
            double An = 0;
            if (n != 0)
            {
                An = a1 + d * (n - 1);

                getArithmeticProgression(a1, d, n - 1);
            }
            return An;
        }

        //метод для задания 2
        static double getGeometricProgression(double b1, double q, double h)
        {
            double Bn = 0;
            if (h != 0)
            {
                Bn = b1 * Math.Pow(q, h - 1);
                getGeometricProgression(b1, q, h - 1);
            }
            return Bn;
        }


        //метод для задания 3:
        static void getInter(int a, int b)
        {

            if (a <= b)
            {
                Console.Write(a + " ");
                getInter(a + 1, b);
            }
        }

        //метод для задания 4
        static int sum(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return n + sum(n - 1);
            }
        }

    }
}