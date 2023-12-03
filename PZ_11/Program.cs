namespace PZ_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите радиус планеты");
            double rad = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Её площадь равна " + getSquare(rad));
            Console.WriteLine("Её длина равна " + getLength(rad));
        }

        public static double getSquare (double x)
        {
            return 4 * Math.PI * Math.Pow(x, 2);
        }
        public static double getLength(double x)
        {
            return 2 * Math.PI * x;
        }
    }
}