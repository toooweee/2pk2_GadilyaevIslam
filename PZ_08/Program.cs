using System;
using System.Diagnostics.Metrics;

namespace PZ_08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random ran = new Random();
            int height = 10;
            double[][] arr = new double[height][];           
            Random rand = new Random();

            // 1

            for (int i = 0; i < height; i++)
            {
                int length = rand.Next(8, 21);
                arr[i] = new double[length];
                for (int j = 0; j < length; j++)
                {
                    arr[i][j] = Math.Round(rand.NextDouble() * 10.0, 2);                    
                }
            }

            // 2

            Console.WriteLine("Номер 2");

            for (int i = 0; i < height; i++)
            {
                for(int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + " ");    
                }
                Console.WriteLine();
            }

            // 3

            Console.WriteLine("Номер 3");

            double[] newArr = new double[10];
            for (int i = 0; i < 10; i++)
            {
                newArr[i] = arr[i][arr[i].Length - 1];
            }

            Console.WriteLine("Последние элементы зубчатого массива: ");
            foreach (double v in newArr)
            {
                Console.Write(v + " ");
            }
            Console.WriteLine();


            // 4 

            Console.WriteLine("Номер 4");

            double[][] copyArr = arr;

            for (int i = 0; i < 10; i++)
            {
                Array.Sort(copyArr[i]);
            }

            Console.WriteLine("Максимальные значения каждой строки массива: ");
            for (int i = 0; i < 10; i++)
            {
                newArr[i] = copyArr[i][copyArr[i].Length - 1];
                Console.Write(newArr[i] + " ");
            }
            Console.WriteLine();

            // 5
            Console.WriteLine("Номер 5 ");
            int forFirst = 0;
            int forMax = 0;
            int[] maxElements = new int[10];
            int[] FirstNum = new int[10];
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] == FirstNum[forFirst])
                    {
                        arr[i][j] = maxElements[forFirst];

                    }
                    else if (arr[i][j] == maxElements[forMax])
                    {
                        arr[i][j] = FirstNum[forMax];
                    }
                    Console.Write(arr[i][j] + " ");
                }
                forFirst++;
                forMax++;
                Console.WriteLine();
            }

            //6

            Console.WriteLine("Номер 6");

            for (int i = 0; i < arr.Length; i++)
            {
                Array.Reverse(arr[i]);
            }

            // Выводим реверсированный зубчатый массив
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + " ");
                }
                Console.WriteLine();
            }

            //7

            Console.WriteLine("Номер 7");
            double sr = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    sr += arr[i][j];
                                                   
                }
                sr /= arr[i].Length;
                Console.WriteLine(sr);
                sr = 0;
            }
        }
    }
}