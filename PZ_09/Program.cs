﻿namespace PZ_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите ненормированную строку:");
            string input = Console.ReadLine();

            // удаляем пробелы в начале и в конце строки
            input = input.Trim();

            // массив символов из строки
            char[] inputChars = input.ToCharArray();
            int inputLength = inputChars.Length;

            // cоздаем новый массив для нормированной строки
            char[] normalChars = new char[inputLength];
            int normalIndex = 0;
            bool inWord = false;

            for (int i = 0; i < inputLength; i++)
            {
                // eсли текущий символ не пробел, добавляем его в новый массив
                if (inputChars[i] != ' ')
                {
                    normalChars[normalIndex++] = inputChars[i];
                    inWord = true;
                }
                // eсли текущий символ пробел и предыдущий символ был не пробел, добавляем пробел в новый массив
                else if (inWord)
                {
                    normalChars[normalIndex++] = ' ';
                    inWord = false;
                }
            }

            string normalString = new string(normalChars, 0, normalIndex);

            Console.WriteLine(normalString);
        }
    }
}