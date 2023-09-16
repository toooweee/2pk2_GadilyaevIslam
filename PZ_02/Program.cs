namespace PZ_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double s, t, v;
            Console.WriteLine("Введите перменную m");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите перменную x");
            double x = Convert.ToDouble(Console.ReadLine());
            if (m < 0)
            {
                s = m - (m * x * 1.0) * x * 1.0 / (x + 1);
            }
            else
            {
                s = -10.6 * x;
            }
            if (s <= -1)
            {
                t = m * s + Math.Sin(x) + m;
            }
            else
            {
                t = s - Math.Pow(Math.Cos(s / (x * 1.0)), 2);
            }
            v = x + (3 * 1.0 * m) * s - (s * (t * 1.0));
            Console.WriteLine("Вы ввели " + m);
            Console.WriteLine("Вы также ввели " + x);
            Console.WriteLine("Значение s = " + s);
            Console.WriteLine("Значение t = " + t);
            Console.WriteLine("Значение v = " + v);

        }
    }
}