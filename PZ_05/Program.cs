namespace PZ_05
{
    internal class Program
    {
        static int FibonacciSequence(int n)
        {
            if (n <= 1)
                return n;

            int prev = 0;
            int current = 1;
            int result = 0;

            for (int i = 2; i <= n; i++)
            {
                result = prev + current;
                prev = current;
                current = result;
            }

            return result;
        }

        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            int number = Convert.ToInt32(Console.ReadLine());

            int count = 0;
            int fibNumber = 0;

            while (fibNumber < number)
            {
                count++;
                fibNumber = FibonacciSequence(count);
            }

            if (fibNumber == number)
            {
                Console.WriteLine($"{number} является {count}-ым числом Фибоначчи");
            }
            else
            {
                Console.WriteLine($"{number} не является числом Фибоначчи");
            }
        }
    }
}