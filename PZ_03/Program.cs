namespace PZ_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер месяца");
            int month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Праздники в этом месяце:");
            switch (month)
            {
                case 1:
                    Console.WriteLine("1 января - Новый год");
                    Console.WriteLine("7 января - Рождество");
                    break;
                case 2:
                    Console.WriteLine("23  февраля - День защитника Отечества");
                    break;
                case 3:
                    Console.WriteLine("8 марта - Международный женский день");
                    break;
                case 4:
                    Console.WriteLine("Нет государственных праздников");
                    break;
                case 5:
                    Console.WriteLine("1 мая - Праздник весны и труда");
                    Console.WriteLine("9 мая - День Победы");
                    break;
                case 6:
                    Console.WriteLine("12 июня - День России");
                    break;
                case 7:
                    Console.WriteLine("Нет государственных праздников");
                    break;
                case 8:
                    Console.WriteLine("Нет государственных праздников");
                    break;
                case 9:
                    Console.WriteLine("Нет государственных праздников");
                    break;
                case 10:
                    Console.WriteLine("Нет государственных праздников");
                    break;
                case 11:
                    Console.WriteLine("4 ноября - День Народного Единства");
                    break;
                case 12:
                    Console.WriteLine("Нет государственных праздников");
                    break;
                default:
                    Console.WriteLine("Ты ввел не то");
                    break;
            }
        }
    }
}