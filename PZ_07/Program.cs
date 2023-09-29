namespace PZ_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int [,] arr = new int[10, 10];
            for(int i  = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    arr[i, j] = rand.Next(0, 10);
                }
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Введите число");
            int count = 0;
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (arr[i, j] == n)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine($"Число {n} повторяется  {count} раз");


        }
    }
}