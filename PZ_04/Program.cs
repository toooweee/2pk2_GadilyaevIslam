namespace PZ_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1");
            Console.WriteLine();
            for(int i = 20; i < 91; i += 2) {
                Console.WriteLine(i);
            }

            ///////////////////////////

            Console.WriteLine();
            Console.WriteLine("Задание 2");
            Console.WriteLine();

            char h = 'h';
            for(int i = h; i < h + 6; i++)
            {
                Console.Write((char)i + " ");
            }

            ///////////////////////////

            Console.WriteLine();
            Console.WriteLine("Задание 3");
            Console.WriteLine();

            for (int i = 0; i < 6; i++)
            {
                for (int z = 0; z < 6; z++)
                {
                    Console.Write('#');
                }
                Console.WriteLine();
            }

            ///////////////////////////

            Console.WriteLine();
            Console.WriteLine("Задание 4");
            Console.WriteLine();

            int count = 0;
            for(int i = - 500; i <= -200; i++)
            {
                if(i % 2 == 0)
                {
                    count += 1;
                }
            }
            Console.WriteLine(count);

            ///////////////////////////

            Console.WriteLine();
            Console.WriteLine("Задание 5");
            Console.WriteLine();

            int j = 40;
            for(int i = 4; i < j; i++)
            {
                Console.WriteLine(i);
                Console.WriteLine(j);
                j--;
                if(i - j == 13)
                {
                    break;
                }
            }

        }
    }
}