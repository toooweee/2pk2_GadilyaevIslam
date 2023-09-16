namespace PZ_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 60; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            Console.WriteLine("ЕСЛИ У ВАС ЕСТЬ ЗНАЧЕНИЕ ПИ, ВВОДИТЕ ЕГО ТРЕТЬИМ ЗНАЧЕНИЕМ");
            Console.WriteLine("АНГЛИЙСКИМ ЛИТЕРОМ. ПРИМЕР: PI || pi");
            for (int i = 0; i < 60; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();

            double pi = Math.PI;
            Console.WriteLine("Введите первое значение");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите второе значение");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите третье значение");
            string j = Console.ReadLine();
            double c = 1.0;
            if (j.ToLower() == "pi")
            {
                c = Math.PI;
            }
            else if (j.ToLower() == "pi/2")
            {
                c = Math.PI / 2;
            }
            else if (j.ToLower() == "pi/2")
            {
                c = Math.PI / 4;
            }
            else { c = Convert.ToDouble(j); }

            double step1 = Math.Log(5.0) / Math.Sin(c) - Math.Sqrt(Math.Abs(-2.5 - Math.Pow(a, 2.0)));
            double step2 = Math.Pow(10.0, 3.0) * a - b * 1.0 / Math.Cos(b) + Math.Pow(Math.Abs(-5.0 - a * a), 1.0 / 3.0) - 2.5 * c;
            Console.WriteLine("Ответ");
            Console.WriteLine(Math.Round(step1 - step2));
        }
    }
}