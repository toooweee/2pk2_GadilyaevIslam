namespace PZ_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите ненормированную строку");
            string str = Console.ReadLine();
            int count = 0;
            str = str.Trim(); //обрезка лишних пробелов с начала и конца строки
            List<char> list = new List<char>();

            for (int i = 0; i < str.Length; i++)
            {
                int j = 0;
                if (Char.IsWhiteSpace(str[i])) //если текущий символ является пробелом
                {
                    while (Char.IsWhiteSpace(str[i + j])) //пока все последующие символы являются пробелом
                    {
                        j++;
                    }
                    if (j == 1)
                    {
                        list.Add(str[i]);
                    }
                }
            }
            Console.WriteLine(list);
        }
    }
}