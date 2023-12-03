namespace PZ_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            char[,] resultArray = arr(n);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(resultArray[i, j]);
                }
                Console.WriteLine();
            }
        }


        static char[,] arr(int n)
        {
            char[,] arr = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if  (i == n / 2 && j == n / 2)
                    {
                        arr[i, j] = 'о';
                    }
                    else if (i == j || i + j == n - 1)
                    {
                        arr[i, j] = '*';
                    }
                    else
                    {
                        arr[i, j] = '_'; 
                    }
                }
            }

            return arr;
        }
    }
}